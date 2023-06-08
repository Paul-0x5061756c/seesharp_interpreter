using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using seeharp_interpreter.lexer;
using seeharp_interpreter.parser.Interfaces;

namespace seeharp_interpreter.parser;
public class InfixParseFn : Dictionary<TokenType, Func<IExpression, IExpression>>
{

}