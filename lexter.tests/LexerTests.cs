using seeharp_interpreter.lexer;
using Xunit;

namespace seeharp_interpreter.lexter.tests;

public class LexerTests
{

  [Fact]
  public void TestNextToken()
  {
    string input = @"let five = 5;
let ten = 10;
let add = fn(x, y) {
    x + y;
};
let result = add(five, ten);
!-/*5;
5 < 10 > 5;

if (5 < 10) {
    return true;
    } else {
        return false;
    }
10 == 10;
10 != 9;";

    (TokenType expectedType, string expectedLiteral)[] tests =
     {
        (TokenType.Let, "let"),
        (TokenType.Ident, "five"),
        (TokenType.Assign, "="),
        (TokenType.Int, "5"),
        (TokenType.Semicolon, ";"),
        (TokenType.Let, "let"),
        (TokenType.Ident, "ten"),
        (TokenType.Assign, "="),
        (TokenType.Int, "10"),
        (TokenType.Semicolon, ";"),
        (TokenType.Let, "let"),
        (TokenType.Ident, "add"),
        (TokenType.Assign, "="),
        (TokenType.Function, "fn"),
        (TokenType.LParen, "("),
        (TokenType.Ident, "x"),
        (TokenType.Comma, ","),
        (TokenType.Ident, "y"),
        (TokenType.RParen, ")"),
        (TokenType.LBrace, "{"),
        (TokenType.Ident, "x"),
        (TokenType.Plus, "+"),
        (TokenType.Ident, "y"),
        (TokenType.Semicolon, ";"),
        (TokenType.RBrace, "}"),
        (TokenType.Semicolon, ";"),
        (TokenType.Let, "let"),
        (TokenType.Ident, "result"),
        (TokenType.Assign, "="),
        (TokenType.Ident, "add"),
        (TokenType.LParen, "("),
        (TokenType.Ident, "five"),
        (TokenType.Comma, ","),
        (TokenType.Ident, "ten"),
        (TokenType.RParen, ")"),
        (TokenType.Semicolon, ";"),
        (TokenType.Bang, "!"),
        (TokenType.Minus, "-"),
        (TokenType.Slash, "/"),
        (TokenType.Asterisk, "*"),
        (TokenType.Int, "5"),
        (TokenType.Semicolon, ";"),
        (TokenType.Int, "5"),
        (TokenType.Lt, "<"),
        (TokenType.Int, "10"),
        (TokenType.Gt, ">"),
        (TokenType.Int, "5"),
        (TokenType.Semicolon, ";"),
        (TokenType.If, "if"),
        (TokenType.LParen, "("),
        (TokenType.Int, "5"),
        (TokenType.Lt, "<"),
        (TokenType.Int, "10"),
        (TokenType.RParen, ")"),
        (TokenType.LBrace, "{"),
        (TokenType.Return, "return"),
        (TokenType.True, "true"),
        (TokenType.Semicolon, ";"),
        (TokenType.RBrace, "}"),
        (TokenType.Else, "else"),
        (TokenType.LBrace, "{"),
        (TokenType.Return, "return"),
        (TokenType.False, "false"),
        (TokenType.Semicolon, ";"),
        (TokenType.RBrace, "}"),
        (TokenType.Int, "10"),
        (TokenType.Eq, "=="),
        (TokenType.Int, "10"),
        (TokenType.Semicolon, ";"),
        (TokenType.Int, "10"),
        (TokenType.NotEq, "!="),
        (TokenType.Int, "9"),
        (TokenType.Semicolon, ";"),
        (TokenType.Eof, "")
};

    Lexer l = new Lexer(input);
    for (int i = 0; i < tests.Length; i++)
    {
      Token tok = l.NextToken();

      if (tok.Type != tests[i].expectedType)
      {
        Assert.Fail($"tests[{i}] - tokentype wrong. expected={tests[i].expectedType}, got={tok.Type}");
      }

      if (tok.Literal != tests[i].expectedLiteral)
      {
        Assert.Fail($"tests[{i}] - literal wrong. expected={tests[i].expectedLiteral}, got={tok.Literal}");
      }
    }
  }

}
