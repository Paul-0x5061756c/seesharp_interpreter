namespace seeharp_interpreter.lexer;

public readonly struct Token
{
  public readonly TokenType Type;
  public readonly string? Literal;

  public Token(TokenType type, string? literal = default)
  {
    Type = type;
    Literal = literal;
  }

}