namespace ObjectIR.Backend.Lua.Ast;

public sealed class BooleanLiteral(bool value) : Expression
{
    public BooleanLiteral(string value) : this(value == "true") { }

    public bool Value { get; } = value;

    public override void Render(IWriter writer)
    {
        writer.Write(Value ? "true" : "false");
    }
}