using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using seeharp_interpreter.lexer;
using seeharp_interpreter.parser.Interfaces;

namespace seeharp_interpreter.parser.Statements;
public class BaseStatement : IStatement
{
  public Token Token { get; set; }
  public Identifier Name { get; set; } = new();

  public Expression? Value { get; set; }
  public string TokenLiteral() => Token.Literal ?? string.Empty;

}