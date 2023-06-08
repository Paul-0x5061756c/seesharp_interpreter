using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seeharp_interpreter.parser.Statements;
public class ExpressionStatement : BaseStatement
{
    public override string ToString() => Value?.ToString() ?? string.Empty;
}