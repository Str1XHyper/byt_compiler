// See https://aka.ms/new-console-template for more information

using byt_compiler;

if (args.Length != 3)
{
    Console.Error.WriteLine("Wrong number of arguments.");
    Console.Error.WriteLine(string.Join(", ", args));
    #if DEBUG
    Console.WriteLine("Usage: dotnet .\\byt_compiler\\ <input file> <output file>");
    #elif RELEASE
    Console.WriteLine("Usage: dotnet byt_compiler.dll <input file> <output file>");
    #endif
    return;
}

var text = File.ReadAllText(args[1]);

var tokenizer = new Tokenizer(text);
var tokens = tokenizer.Tokenize();
var parser = new Parser(tokens);
var codeGenerator = new CodeGenerator(parser.Parse());

File.WriteAllText(args[2], codeGenerator.Generate());
// Console.WriteLine("Hello, World!");