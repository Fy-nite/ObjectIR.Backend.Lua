namespace ObjectIR.Backend.Lua.Ast;

public abstract class Node
{
    public List<Node> Children { get; } = [];
    public abstract void Render(IWriter writer);

    protected void AddChild(Node child)
    {
        Children.Add(child);
    }

    protected void AddChildren(IEnumerable<Node> children)
    {
        foreach (var child in children)
        {
            AddChild(child);
        }
    }
}

public abstract class Expression : Node;
public abstract class Statement : Node;