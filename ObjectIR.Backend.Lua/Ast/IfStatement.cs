namespace ObjectIR.Backend.Lua.Ast;

public sealed class IfStatement(Expression condition, Block block, Block? elseBlock) : Statement
{
    public Expression Condition { get; } = condition;
    public Block Block { get; } = block;
    public Block? ElseBlock { get; } = elseBlock;
    
    public override void Render(IWriter writer)
    {
        writer.WriteIndent();
        writer.Write("if ");
        Condition.Render(writer);
        writer.WriteLine(" then ");
        writer.PushIndent();
        Block.Render(writer);
        writer.PopIndent();
        if (ElseBlock != null)
        {
            writer.WriteLine("else");
            writer.PushIndent();
            ElseBlock?.Render(writer);
            writer.PopIndent();
        }
        writer.WriteLine("end");
    }
}