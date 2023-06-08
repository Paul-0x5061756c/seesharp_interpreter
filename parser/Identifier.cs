using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using seeharp_interpreter.lexer;
using seeharp_interpreter.parser.Interfaces;

namespace seeharp_interpreter.parser;
public class Identifier : INode
{
  public Token Token { get; set; }
  public string Value { get; set; } = string.Empty;

  public string TokenLiteral() => Token.Literal ?? string.Empty;

  public override string ToString() => Value;
}