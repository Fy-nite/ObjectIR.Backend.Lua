namespace ObjectIR.Backend.Lua.Ast;

public sealed class AssignmentStatement(CaptureList<Expression> variables, CaptureList<Expression> expressions) : Statement
{
    public CaptureList<Expression> Variables { get; } = variables;
    public CaptureList<Expression> Expressions { get; } = expressions;
    
    public override void Render(IWriter writer)
    {
        writer.WriteIndent();
        Variables.Render(writer);
        writer.Write(" = ");
        Expressions.Render(writer);
        writer.WriteLine();
    }
}