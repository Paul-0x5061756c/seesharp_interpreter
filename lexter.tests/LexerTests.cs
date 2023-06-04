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
let result = add(five, ten);";

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
