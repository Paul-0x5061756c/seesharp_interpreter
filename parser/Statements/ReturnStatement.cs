using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seeharp_interpreter.parser.Statements;
public class ReturnStatement : BaseStatement
{
  public override string ToString() => $"{TokenLiteral()} {Value?.ToString() ?? string.Empty};";
}