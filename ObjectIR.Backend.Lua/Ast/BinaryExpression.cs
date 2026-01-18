namespace ObjectIR.Backend.Lua.Ast;

public sealed class BinaryExpression(Expression left, string @operator, Expression right) : Expression
{
    public Expression Left { get; } = left;
    public Expression Right { get; } = right;
    public string Operator { get; } = @operator;
    
    public override void Render(IWriter writer)
    {
        Left.Render(writer);
        writer.Write($" {Operator} ");
        Right.Render(writer);
    }
}