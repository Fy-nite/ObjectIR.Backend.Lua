namespace ObjectIR.Backend.Lua.AST;

public class IndexExpression(Expression @object, Expression index) : Expression
{
    public Expression Object { get; } = @object;
    public Expression Index { get; } = index;

    public override void Render(IWriter writer)
    {
        Object.Render(writer);
        writer.Write('.');
        Index.Render(writer);
    }
}