namespace seeharp_interpreter.lexer;
public class Lexer
{
  readonly string Input;
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

    if (char.IsAsciiDigit(Ch)) return new(TokenType.Int, ReadNumber());
    else if (char.IsAsciiLetter(Ch))
    {
      string ident = ReadIdentifier();
      return new Token(LookUpIdent(ident), ident);
    }
    else if (IsDoubleCharToken()) return ReadDoubleCharToken();
    else
    {

      Token token = GetSingleCharToken();
      ReadChar();
      return token;
    }
  }

  private bool IsDoubleCharToken() => (Ch == '=' && PeekChar() == '=') || (Ch == '!' && PeekChar() == '=');


  private Token ReadDoubleCharToken()
  {
    char ch = Ch;
    ReadChar();
    string literal = $"{ch}{Ch}";
    ReadChar();

    return ch == '=' ? new(TokenType.Eq, literal) : new(TokenType.NotEq, literal);
  }

  private TokenType LookUpIdent(string ident) => TokenMap.TokenIdentMap.TryGetValue(ident, out Token foundToken) ? foundToken.Type : TokenType.Ident;
  private Token GetSingleCharToken() => TokenMap.TokenCharMap.TryGetValue(Ch, out Token foundToken) ? foundToken : new(TokenType.Illegal, Ch.ToString());

  private void SkipWhitespace()
  {
    while (char.IsWhiteSpace(Ch))
    {
      ReadChar();
    }
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

  private char PeekChar() => (ReadPosition >= Input.Length) ? '\0' : Input[ReadPosition];
}
