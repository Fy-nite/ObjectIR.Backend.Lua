using ObjectIR.Ast.Parser;
using Xunit.Abstractions;

namespace ObjectIR.Backend.Lua.Tests;

public class OIRParserTests
{
    private readonly ITestOutputHelper _output;

    public OIRParserTests(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
    public void Test()
    {
        var src = @"
        module CalculatorApp

        class Calculator {
            field history: List<int32>
            field lastResult: int32
            
            method Add(a: int32, b: int32) -> int32 {
                local result: int32
                
                ldarg a
                ldarg b
                add
                stloc result
                ldloc result
                ret
            }
        }
        ";

        var result = TextIrParser.ParseModule(src.Trim());
        _output.WriteLine($"Module: {result.Name}\nVersion: {result.Version}");
    }
}