namespace ObjectIR.Backend.Lua.AST;

public class Identifier(string name) : Expression
{
    public string Value { get; } = name;

    public override void Render(IWriter writer)
    {
        writer.Write(Value);
    }
}
