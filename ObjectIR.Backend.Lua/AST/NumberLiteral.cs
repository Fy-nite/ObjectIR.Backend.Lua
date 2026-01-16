namespace ObjectIR.Backend.Lua.AST;

public sealed class NumberLiteral(int value) : Expression
{
    public string Value { get; } = value.ToString();
    
    public override void Render(IWriter writer)
    {
        writer.Write(Value);
    }
}