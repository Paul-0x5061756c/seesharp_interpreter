namespace seeharp_interpreter.lexer;

public class Lexer
{
  string Input;
  int Position;

  int ReadPosition;
  char Ch;

  public Lexer(string input)
  {
    Input = input;
    ReadChar();

  }
  public Token NextToken()
  {
    SkipWhitespace();

    if (char.IsAsciiDigit(Ch))
    {
      return new Token(TokenType.Int, ReadNumber());
    }

    if (char.IsAsciiLetter(Ch))
    {
      string ident = ReadIdentifier();
      return new Token(LookUpIdent(ident), ident);
    }

    Token token = Ch switch
    {
      '=' => new Token(TokenType.Assign, "="),
      ';' => new Token(TokenType.Semicolon, ";"),
      '(' => new Token(TokenType.LParen, "("),
      ')' => new Token(TokenType.RParen, ")"),
      ',' => new Token(TokenType.Comma, ","),
      '+' => new Token(TokenType.Plus, "+"),
      '{' => new Token(TokenType.LBrace, "{"),
      '}' => new Token(TokenType.RBrace, "}"),
      '\0' => new Token(TokenType.Eof, ""),
      _ => throw new System.NotImplementedException()
    };

    ReadChar();
    return token;
  }

  private void SkipWhitespace()
  {
    while (char.IsWhiteSpace(Ch))
    {
      ReadChar();
    }
  }


  private TokenType LookUpIdent(string ident)
  {
    return ident switch
    {
      "fn" => TokenType.Function,
      "let" => TokenType.Let,
      _ => TokenType.Ident
    };
  }

  private string ReadNumber()
  {
    int position = Position;
    while (char.IsAsciiDigit(Ch))
    {
      ReadChar();
    }
    return Input[position..Position];
  }

  private string ReadIdentifier()
  {
    int position = Position;
    while (char.IsAsciiLetter(Ch))
    {
      ReadChar();
    }
    return Input[position..Position];
  }

  private void ReadChar()
  {
    Ch = (ReadPosition >= Input.Length) ? '\0' : Input[ReadPosition];
    Position = ReadPosition;
    ReadPosition += 1;
  }
}