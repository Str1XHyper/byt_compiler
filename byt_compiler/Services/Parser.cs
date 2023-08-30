using System.Data;
using byt_compiler.enums;
using byt_compiler.Models;
using byt_compiler.Models.Nodes;

namespace byt_compiler;

public class Parser
{
    private readonly List<Token> _tokens;
    private int _position = -1;

    public Parser(List<Token> tokens)
    {
        _tokens = tokens;
    }

    public Exit Parse()
    {
        Exit exit = null;
        while (Peek() is not null)
        {
            if (Peek().Type is TokenType._exit)
            {
                if (Expression.TryParse(Peek(2), out var expression))
                {
                    _position += 2;
                    exit = new Exit()
                    {
                        Expression = expression
                    };
                }
                else
                {
                    throw new SyntaxErrorException("Invalid expression");
                }

                if (Peek().Type is not TokenType._semi)
                {
                    _position++;
                    throw new SyntaxErrorException("Missing semicolon");
                }
                else
                {
                    _position++;
                }
            }
        }
        _position = -1;
        if (exit is null)
        {
            throw new Exception();
        }
        return exit;
    }
    
    private Token? Peek(int peekCount = 1)
    {
        return _position + peekCount >= _tokens.Count ? null : _tokens[_position + peekCount];
    }
    

    private bool Parse_Expression(out Expression expression)
    {
        expression = new Expression();
        return true;
    }
}