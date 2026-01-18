namespace ObjectIR.Backend.Lua.Ast;

public sealed class DoStatement(Block block): Statement
{
    public Block Block { get; } = block;

    public override void Render(IWriter writer)
    {
        writer.WriteLine("do");
        writer.PushIndent();
        Block.Render(writer);
        writer.PopIndent();
        writer.WriteLine("end");
    }
}