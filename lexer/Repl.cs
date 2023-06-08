using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seeharp_interpreter.lexer;
public class Repl
{
  public static void Start()
  {
    while (true)
    {
      var input = Console.ReadLine();
      var lexer = new Lexer($"{input}");
      Token token;
      while ((token = lexer.NextToken()).Type != TokenType.Eof)
      {
        Console.WriteLine(token.Type + " " + token.Literal);
      }
    }
  }
}