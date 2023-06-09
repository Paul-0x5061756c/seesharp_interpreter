using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using seeharp_interpreter.lexer;
using seeharp_interpreter.parser.Interfaces;
using seeharp_interpreter.parser.Statements;
using Xunit;

namespace seeharp_interpreter.parser.tests;
public class ParserTests
{
  [Fact]
  public void TestLetStatements()
  {
    var input = @"
            let x = 5;
            let y = 10;
            let foobar = 838383;";

    var lexer = new Lexer(input);
    var parser = new Parser(lexer);

    var program = parser.ParseProgram();
    Assert.NotNull(program);
    Assert.Equal(3, program.Statements.Count);
    CheckParserErrors(parser);

    var tests = new string[]
    {
      ("x"),
      ("y"),
      ("foobar"),
    };

    foreach (var (i, test) in tests.Select((value, i) => (i, value)))
    {
      var stmt = program.Statements[i];
      Assert.True(TestLetStatement(stmt, test));
    }
  }

  private static bool TestLetStatement(IStatement stmt, string name)
  {
    Assert.Equal(TokenType.Let, stmt.Token.Type);
    var letStmt = (LetStatement)stmt;
    Assert.Equal(name, letStmt.Name!.Value);
    Assert.Equal(name, letStmt.Name!.TokenLiteral());
    return true;
  }

  private static void CheckParserErrors(Parser parser)
  {
    var errors = parser.Errors;
    if (errors.Count == 0) return;

    Console.WriteLine($"parser has {errors.Count} errors");
    foreach (var msg in errors)
    {
      Console.WriteLine($"parser error: {msg}");
    }
    Assert.True(false);
  }

  [Fact]
  public void TestReturnStatements()
  {
    var input = @"
            return 5;
            return 10;
            return 993322;";

    var lexer = new Lexer(input);
    var parser = new Parser(lexer);

    var program = parser.ParseProgram();
    Assert.NotNull(program);
    Assert.Equal(3, program.Statements.Count);
    CheckParserErrors(parser);

    foreach (var stmt in program.Statements)
    {
      Assert.Equal(TokenType.Return, stmt.Token.Type);
    }

  }

  [Fact]
  public void TestString()
  {
    var Program = new Program()
    {
      Statements = new(){
        new LetStatement(){
          Token = new(TokenType.Let, "let"),
          Name = new(){
            Token = new(TokenType.Ident, "myVar"),
            Value = "myVar"
          },
          Value = new(){
            Token = new(TokenType.Ident, "anotherVar"),
            Value = "anotherVar"
          }
        }
      }
    };

    Assert.Equal("let myVar = anotherVar;", Program.ToString());
  }

  [Fact]
  public void TestIdentifierExpression()
  {
    var input = "foobar;";

    var lexer = new Lexer(input);
    var parser = new Parser(lexer);

    var program = parser.ParseProgram();
    Assert.NotNull(program);
    Assert.Single(program.Statements);
    CheckParserErrors(parser);

    var stmt = program.Statements[0];
    Assert.Equal(TokenType.Ident, stmt.Token.Type);
    Assert.Equal("foobar", stmt.Token.Literal);
  }
}