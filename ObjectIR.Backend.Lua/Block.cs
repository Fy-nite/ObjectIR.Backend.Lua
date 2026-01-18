using ObjectIR.Backend.Lua.Ast;

namespace ObjectIR.Backend.Lua;

public sealed class Block(List<Statement> statements) : Node
{
    public IList<Statement> Statements { get; } = statements;

    public Block() : this(new List<Statement>()) { }

    public void Add(Statement statement)
    {
        Statements.Add(statement);
    }

    public override void Render(IWriter writer)
    {
        writer.PushIndent();
        foreach (var statement in Statements)
        {
            writer.WriteIndent();
            statement.Render(writer);
        }
        writer.PopIndent();
    }
}