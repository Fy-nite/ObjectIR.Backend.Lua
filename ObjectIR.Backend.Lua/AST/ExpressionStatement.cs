namespace ObjectIR.Backend.Lua.AST;

public class ExpressionStatement(Expression expression) : Statement
{
    public Expression Expression { get; } = expression;

    public override void Render(IWriter writer)
    {
        Expression.Render(writer);
        writer.WriteLine();
    }
}