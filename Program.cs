using System.Text;
using seeharp_interpreter.lexer;
using seeharp_interpreter.parser;
using seeharp_interpreter.parser.Interfaces;

namespace seeharp_interpreter;
public class Program : INode
{
  public List<IStatement> Statements { get; set; } = new();
  public static void Main()
  {
    Repl.Start();
  }

  public string TokenLiteral() => Statements.Count > 0 ? Statements[0].TokenLiteral() : "";

  public override string ToString() => string.Join("\n", Statements.Select(s => s.ToString()));
}
