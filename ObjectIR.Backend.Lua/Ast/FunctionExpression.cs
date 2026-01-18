namespace ObjectIR.Backend.Lua.Ast;

public sealed class FunctionExpression(CaptureList<Identifier> arguments, Block body) : Expression
{
    public CaptureList<Identifier> Arguments { get; } = arguments;
    public Block Body { get; } = body;
    
    public override void Render(IWriter writer)
    {
        writer.Write("function(");
        Arguments.Render(writer);
        writer.WriteLine(")");
        Body.Render(writer);
        writer.WriteLine("end");
    }
}