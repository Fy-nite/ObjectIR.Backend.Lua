namespace ObjectIR.Backend.Lua.Ast;

public class ForNumericStatement(Identifier var, int start, int stop, int step, Block block) : Statement
{
    public Identifier Var { get; } = var;
    public int Start { get; } = start;
    public int Stop { get; } = stop;
    public int Step { get; } = step;
    public Block Block { get; } = block;
    
    public override void Render(IWriter writer)
    {
        writer.WriteIndent();
        writer.Write("for ");
        var.Render(writer);
        writer.WriteLine($" = {start},{stop},{step} do");
        writer.PushIndent();
        Block.Render(writer);
        writer.PopIndent();
        writer.WriteLine("end");
    }
}