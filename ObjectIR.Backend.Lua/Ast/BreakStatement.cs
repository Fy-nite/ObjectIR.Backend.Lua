namespace ObjectIR.Backend.Lua.Ast;

public sealed class BreakStatement : Statement
{
    public override void Render(IWriter writer)
    {
        writer.WriteIndent();
        writer.WriteLine("break");
    }
}