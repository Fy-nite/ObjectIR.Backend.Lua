namespace ObjectIR.Backend.Lua.Ast;

public sealed class Identifier(string name) : Expression
{
    public string Value { get; } = name;

    public override void Render(IWriter writer)
    {
        writer.Write(Value);
    }
}
