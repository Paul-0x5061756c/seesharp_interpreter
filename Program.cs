using seeharp_interpreter.lexer;

while (true)
{
  var input = Console.ReadLine();
  var lexer = new Lexer(input);
  while (true)
  {
    var token = lexer.NextToken();
    if (token.Type == TokenType.Eof)
    {
      break;
    }
    Console.WriteLine(token.Type + " " + token.Literal);
  }
}