using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using seeharp_interpreter.parser.Interfaces;

namespace seeharp_interpreter.parser.Statements;
public class LetStatement : BaseStatement
{
  public override string ToString() => $"{TokenLiteral()} {Name} = {Value};";
}
