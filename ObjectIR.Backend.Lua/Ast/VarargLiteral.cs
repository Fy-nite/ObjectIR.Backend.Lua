namespace ObjectIR.Backend.Lua.Ast;

public sealed class VarargLiteral : Expression
{
    public override void Render(IWriter writer)
    {
        writer.Write("...");
    }
}