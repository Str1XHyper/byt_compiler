using byt_compiler.Models.Nodes;

namespace byt_compiler;

public class CodeGenerator
{
    private readonly Exit _exit;
    private const string defaultAsm = ".386\n" +
                                      ".model flat,stdcall\n" +
                                      ".stack 4096\n" +
                                      "option casemap :none\n\n" +
                                      "include \\masm32\\include\\kernel32.inc\n" +
                                      "include \\masm32\\include\\masm32.inc\n" +
                                      "includelib \\masm32\\lib\\kernel32.lib\n" +
                                      "includelib \\masm32\\lib\\masm32.lib\n\n" +
                                      ".code\n" +
                                      "main:\n";
    private const string defaultAsmEnd = @"end main";

    public CodeGenerator(Exit exit)
    {
        _exit = exit;
    }

    public string Generate()
    {
        var output = defaultAsm;

        output += $"    invoke ExitProcess, {_exit.Expression.IntLiteral.Value}\n";
        
        output += defaultAsmEnd;
        return output;
    }
}