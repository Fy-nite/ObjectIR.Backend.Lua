namespace ObjectIR.Backend.Lua.Ast;

public sealed class ExpressionStatement(Expression expression) : Statement
{
    public Expression Expression { get; } = expression;

    public override void Render(IWriter writer)
    {
        writer.WriteIndent();
        Expression.Render(writer);
        writer.WriteLine();
    }
}