using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using seeharp_interpreter.lexer;
using seeharp_interpreter.parser.Interfaces;
using seeharp_interpreter.parser.Statements;

namespace seeharp_interpreter.parser;
public class Parser
{
  public Lexer Lexer { get; set; }
  public Token CurrentToken { get; set; }
  public Token PeekToken { get; set; }
  public List<string> Errors { get; set; } = new();

  public PrefixParseFn PrefixParseFns { get; set; } = new();
  public InfixParseFn InfixParseFns { get; set; } = new();

  public Parser(Lexer lexer)
  {
    Lexer = lexer;
    NextToken();
    NextToken();
  }

  public void NextToken()
  {
    CurrentToken = PeekToken;
    PeekToken = Lexer.NextToken();
  }

  public Program ParseProgram()
  {
    var program = new Program
    {
      Statements = new List<IStatement>()
    };

    while (CurrentToken.Type != TokenType.Eof)
    {
      var stmt = ParseStatement();
      if (stmt != null)
      {
        program.Statements.Add(stmt);
      }
      NextToken();
    }

    return program;
  }

  private IStatement? ParseStatement()
  {
    return CurrentToken.Type switch
    {
      TokenType.Let => ParseLetStatement(),
      TokenType.Return => ParseReturnStatement(),
      _ => ParseExpresionStatement(),
    };
  }

  private IStatement? ParseExpresionStatement()
  {
    var stmt = new ExpressionStatement { Token = CurrentToken };
    stmt.Expression = ParseExpression();
    if (PeekToken.Type == TokenType.Semicolon)
    {
      NextToken();
    }
    return stmt;
  }


  private Expression? ParseExpression(int precedence = 0)
  {
    var prefix = PrefixParseFns[CurrentToken.Type];
    if (prefix is null)
    {
      return null;
    }

    var leftExp = prefix();

    return (Expression?)leftExp;

  }

  private IStatement? ParseReturnStatement()
  {
    var stmt = new ReturnStatement { Token = CurrentToken };
    NextToken();
    while (!CurrentTokenIs(TokenType.Semicolon))
    {
      NextToken();
    }
    return stmt;
  }

  private bool CurrentTokenIs(TokenType semicolon) => CurrentToken.Type == semicolon;

  private IStatement? ParseLetStatement()
  {
    var stmt = new LetStatement { Token = CurrentToken };

    if (!ExpectPeek(TokenType.Ident))
    {
      return null;
    }

    if (CurrentToken.Literal is not null)
    {
      stmt.Name = new Identifier { Token = CurrentToken, Value = CurrentToken.Literal };
    }

    if (!ExpectPeek(TokenType.Assign))
    {
      return null;
    }

    while (!CurrentTokenIs(TokenType.Semicolon))
    {
      NextToken();
    }
    return stmt;
  }

  private bool ExpectPeek(TokenType type)
  {
    if (PeekToken.Type == type)
    {
      NextToken();
      return true;
    }
    else
    {
      PeekError(type);
      return false;
    }
  }

  private void PeekError(TokenType type)
  {
    var msg = $"expected next token to be {type}, got {PeekToken.Type} instead";
    Errors.Add(msg);
  }

  private void RegisterPrefix(TokenType tokenType, Func<IExpression> fn)
  {
    PrefixParseFns.Add(tokenType, fn);
  }

  private void RegisterInfix(TokenType tokenType, Func<IExpression, IExpression> fn)
  {
    InfixParseFns.Add(tokenType, fn);
  }
}
