# ByT_compiler
A compiler for the ByT language.

## Compiling
```sh 
dotnet run .\byt_compiler\ <inputfile>.byt <outputfile>.asm
```

## Assembling and Linking
```sh
ml /c /coff <outputfile>.asm
link /subsystem:console <outputfile>.obj
```

## Running
```sh
<outputfile>.exe
```