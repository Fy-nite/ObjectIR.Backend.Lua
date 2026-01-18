namespace ObjectIR.Backend.Lua.Ast;

public sealed class CallExpression(Expression function, CaptureList<Expression> arguments) : Expression
{
    public Expression Function { get; } = function;
    public CaptureList<Expression> Arguments { get; } = arguments;

    public override void Render(IWriter writer)
    {
        Function.Render(writer);
        Arguments.Render(writer);
    }
}