namespace ObjectIR.Backend.Lua.AST;

public sealed class VarargLiteral : Expression
{
    public override void Render(IWriter writer)
    {
        writer.Write("...");
    }
}