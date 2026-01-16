namespace ObjectIR.Backend.Lua.AST;

public sealed class NilLiteral : Expression
{
    public override void Render(IWriter writer)
    {
        writer.Write("nil");
    }
}