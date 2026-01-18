namespace ObjectIR.Backend.Lua.Ast;

public sealed class NilLiteral : Expression
{
    public override void Render(IWriter writer)
    {
        writer.Write("nil");
    }
}