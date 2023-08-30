using System.Data;
using byt_compiler.enums;
using byt_compiler.Models;

namespace byt_compiler;

public class Tokenizer
{
    private readonly string _inputString;
    private int _position = -1;

    public Tokenizer(string inputString)
    {
        _inputString = inputString;
    }

    private char? Peek(int peekCount = 1)
    {
        if (_position + peekCount >= _inputString.Length)
            return null;
        return _inputString[_position + peekCount];
    }

    private char Consume()
    {
        _position++;
        return _inputString[_position];
    }
    
    public List<Token> Tokenize()
    {
        var buffer = "";
        List<Token> tokens = new();
        
        while(Peek() is not null)
        {
            if (char.IsLetter(Peek().Value))
            {
                buffer += Consume();
                while (Peek() is not null && char.IsLetterOrDigit(Peek().Value))
                {
                    buffer += Consume();
                }

                if (buffer == "exit")
                {
                    tokens.Add(new Token()
                    {
                        Type = TokenType._exit,
                        Value = null
                    });
                    buffer = "";
                    
                }
                else
                {
                    throw new SyntaxErrorException("Unknown keyword");
                }
            } else if (char.IsNumber(Peek().Value))
            {
                buffer += Consume();
                while (Peek() is not null && char.IsNumber(Peek().Value))
                {
                    buffer += Consume();
                }
                tokens.Add(new Token()
                {
                    Type = TokenType._int_literal,
                    Value = buffer
                });
                buffer = "";
            } else if (Peek() is ';')
            {
                Consume();
                tokens.Add(new Token()
                {
                    Type = TokenType._semi,
                    Value = null
                });
            }else if (char.IsWhiteSpace(Peek().Value))
            {
                Consume();
                continue;
            }
        }
        _position = -1;
        return tokens;
    }
}