using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seeharp_interpreter.parser.Interfaces;
public interface INode
{
  string TokenLiteral();
  string ToString();
}