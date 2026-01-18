namespace ObjectIR.Backend.Lua.Ast;

public class ForGenericStatement(CaptureList<Identifier> values, Expression iterator, Block block) : Statement
{
    public CaptureList<Identifier> Values { get; } = values;
    public Expression Iterator { get; } = iterator;
    public Block Block { get; } = block;

    public override void Render(IWriter writer)
    {
        writer.WriteIndent();
        writer.Write("for ");
        Values.Render(writer);
        writer.Write(" in ");
        Iterator.Render(writer);
        writer.WriteLine(" do");
        writer.PushIndent();
        Block.Render(writer);
        writer.PopIndent();
        writer.WriteLine("end");
    }
}