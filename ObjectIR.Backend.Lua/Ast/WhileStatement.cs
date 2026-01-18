namespace ObjectIR.Backend.Lua.Ast;

public sealed class WhileStatement(Expression condition, Block block) : Statement
{
    public Expression Condition { get; } = condition;
    public Block Block { get; } = block;

    public override void Render(IWriter writer)
    {
        writer.Write("while ");
        Condition.Render(writer);
        writer.Write(" do");
        writer.WriteLine();
        Block.Render(writer);
        writer.WriteLine("end");
    }
}