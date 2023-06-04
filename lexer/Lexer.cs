namespace seeharp_interpreter.lexer;

public class Lexer
{
  string Input;
  int Position;

  int ReadPosition;
  char ch;

  public Lexer(string input)
  {
    Input = input;
    ReadChar();

  }
  public Token NextToken()
  {
    Token token = ch switch
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
      _ => char.IsAsciiLetter(ch) ? new Token(TokenType.Ident, ReadIdentifier()) : new Token(TokenType.Illegal, ch.ToString())
    };

    ReadChar();
    return token;
  }

  public string ReadIdentifier()
  {
    int position = Position;
    while (char.IsLetter(ch))
    {
      ReadChar();
    }
    return Input[position..Position];
  }

  private void ReadChar()
  {
    ch = (ReadPosition >= Input.Length) ? '\0' : Input[ReadPosition];
    Position = ReadPosition;
    ReadPosition += 1;
  }
}