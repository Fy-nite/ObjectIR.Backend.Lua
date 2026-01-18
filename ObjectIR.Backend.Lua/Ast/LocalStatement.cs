namespace ObjectIR.Backend.Lua.Ast;

public sealed class LocalStatement(CaptureList<Identifier> variables, CaptureList<Expression> expressions) : Statement
{
    public CaptureList<Identifier> Variables { get; } = variables;
    public CaptureList<Expression> Expressions { get; } = expressions;
    
    public override void Render(IWriter writer)
    {
        writer.WriteIndent();
        writer.Write("local ");
        Variables.Render(writer);
        writer.Write(" = ");
        Expressions.Render(writer);
        writer.WriteLine();
    }
}