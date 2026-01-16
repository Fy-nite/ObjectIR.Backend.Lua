namespace ObjectIR.Backend.Lua.AST;

public class ParenthesizedExpression(Expression value) : Expression
{
    public Expression Value { get; } = value;

    public override void Render(IWriter writer)
    {
        writer.Write('(');
        Value.Render(writer);
        writer.Write(')');
    }
}