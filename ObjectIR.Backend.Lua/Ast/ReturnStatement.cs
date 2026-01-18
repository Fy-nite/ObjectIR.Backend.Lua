namespace ObjectIR.Backend.Lua.Ast;

public sealed class ReturnStatement(Expression? expression) : Statement
{
    public Expression? Expression { get; } = expression;
    public override void Render(IWriter writer)
    {
        writer.WriteIndent();
        writer.Write("return");
        Expression?.Render(writer);
        writer.WriteLine();
    }
}