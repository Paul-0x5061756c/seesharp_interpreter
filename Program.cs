using seeharp_interpreter.lexer;
using seeharp_interpreter.parser;
using seeharp_interpreter.parser.Interfaces;

public class Program : INode
{
  public List<IStatement> Statements { get; set; } = new();
  public static void Main(string[] args)
  {
    Repl.Start();
  }

  public string TokenLiteral()
  {
    if (Statements.Count > 0)
    {
      return Statements[0].TokenLiteral();
    }
    else
    {
      return "";
    }
  }
}