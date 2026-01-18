namespace ObjectIR.Backend.Lua.Ast;

public sealed class AstTree(List<Statement> statements) : Node
{
    public List<Statement> Statements { get; } = statements;

    public override void Render(IWriter writer)
    {
        foreach (var statement in Statements)
        {
            statement.Render(writer);
        }
    }
}