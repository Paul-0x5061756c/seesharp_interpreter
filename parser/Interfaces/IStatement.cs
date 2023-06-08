using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using seeharp_interpreter.lexer;

namespace seeharp_interpreter.parser.Interfaces;
public interface IStatement : INode
{

  Token Token { get; set; }
  Identifier? Name { get; set; }

}