namespace ObjectIR.Backend.Lua.Ast;

public sealed class StringLiteral(string value) : Expression
{
    public string Value { get; } = value.ToString();
    
    public override void Render(IWriter writer)
    {
        writer.Write('"');
        writer.Write(Value);
        writer.Write('"');
    }
}