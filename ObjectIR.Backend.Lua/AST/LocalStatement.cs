namespace ObjectIR.Backend.Lua.AST;

public class LocalStatement : Statement
{
    public IEnumerable<Identifier> Variables { get; } = new List<Identifier>();
    public IEnumerable<Expression> Expressions { get; } = new List<Expression>();
    
    public override void Render(IWriter writer)
    {
        
    }
}