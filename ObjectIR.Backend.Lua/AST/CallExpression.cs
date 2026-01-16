namespace ObjectIR.Backend.Lua.AST;

public class CallExpression(Expression function, IEnumerable<Expression> arguments) : Expression
{
    public Expression Function { get; } = function;
    public IEnumerable<Expression> Arguments { get; } = arguments;

    public override void Render(IWriter writer)
    {
        Function.Render(writer);
        for (int i = 0; i < Arguments.Count(); i++)
        {
            Arguments.ElementAt(i).Render(writer);
            
            if (i < Arguments.Count() - 1)
            {
                writer.Write(", ");
            }
        }
    }
}