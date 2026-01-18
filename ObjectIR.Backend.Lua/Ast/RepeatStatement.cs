namespace ObjectIR.Backend.Lua.Ast;

public sealed class RepeatStatement(Expression condition, Block block) : Statement
{
    public Expression Condition { get; } = condition;
    public Block Block { get; } = block;

    public override void Render(IWriter writer)
    {
        writer.WriteIndent();
        writer.WriteLine("repeat");
        writer.PushIndent();
        Block.Render(writer);
        writer.PopIndent();
        writer.Write("until ");
        Condition.Render(writer);
        writer.WriteLine();
    }
}