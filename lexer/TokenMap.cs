using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seeharp_interpreter.lexer;
public static class TokenMap
{
  public static readonly Dictionary<char, Token> TokenCharMap = new()
  {
    ['='] = new(TokenType.Assign, "="),
    [';'] = new(TokenType.Semicolon, ";"),
    ['('] = new(TokenType.LParen, "("),
    [')'] = new(TokenType.RParen, ")"),
    [','] = new(TokenType.Comma, ","),
    ['+'] = new(TokenType.Plus, "+"),
    ['{'] = new(TokenType.LBrace, "{"),
    ['}'] = new(TokenType.RBrace, "}"),
    ['-'] = new(TokenType.Minus, "-"),
    ['!'] = new(TokenType.Bang, "!"),
    ['*'] = new(TokenType.Asterisk, "*"),
    ['/'] = new(TokenType.Slash, "/"),
    ['<'] = new(TokenType.Lt, "<"),
    ['>'] = new(TokenType.Gt, ">"),
    ['\0'] = new(TokenType.Eof, ""),
  };
  public static readonly Dictionary<string, Token> TokenIdentMap = new()
  {
    ["fn"] = new(TokenType.Function, "fn"),
    ["let"] = new(TokenType.Let, "let"),
    ["return"] = new(TokenType.Return, "return"),
    ["true"] = new(TokenType.True, "true"),
    ["false"] = new(TokenType.False, "false"),
    ["if"] = new(TokenType.If, "if"),
    ["else"] = new(TokenType.Else, "else"),
  };

}