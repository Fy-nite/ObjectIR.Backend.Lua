namespace ObjectIR.Backend.Lua.Ast;

public sealed class MemberExpression(Expression @object, Expression field) : Expression
{
    public Expression Object { get; } = @object;
    public Expression Field { get; } = field;

    public override void Render(IWriter writer)
    {
        Object.Render(writer);
        writer.Write('.');
        Field.Render(writer);
    }
}