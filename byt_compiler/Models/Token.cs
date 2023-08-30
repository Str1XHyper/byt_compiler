using byt_compiler.enums;

namespace byt_compiler.Models;

public class Token
{
    public TokenType Type { get; set; }
    public string? Value { get; set; }
    public override string ToString()
    {
        return $"Type: {Type}, Value: {Value}";
    }
}