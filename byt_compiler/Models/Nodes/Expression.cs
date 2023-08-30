using byt_compiler.enums;

namespace byt_compiler.Models.Nodes;

public class Expression
{
    public Token IntLiteral { get; set; }

    public static bool TryParse(object input, out Expression? expression)
    {
        if(input is not Token token)
        {
            expression = null;
            return false;
        }
        if(token.Type is not TokenType._int_literal)
        {
            expression = null;
            return false;
        }
        expression = new Expression()
        {
            IntLiteral = token
        };
        return true;
    }
}