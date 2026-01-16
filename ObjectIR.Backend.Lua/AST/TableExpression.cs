namespace ObjectIR.Backend.Lua.AST;

public sealed class TableConstructorExpression : Expression
{
    public IEnumerable<TableElement> Values { get; } = new List<TableElement>();
    
    public override void Render(IWriter writer)
    {
        for (int i = 0; i < Values.Count(); i++)
        {
            Values.ElementAt(i).Render(writer);
            if (i < Values.Count() - 1)
            {
                writer.Write(", ");
            }
        }
    }
}

public abstract class TableElement :  Expression;

public sealed class TableKey(Expression key, Expression value) : TableElement
{
    public Expression Key { get; } = key;
    public Expression Value { get; } = value;
    
    public override void Render(IWriter writer)
    {
        if (Key is Identifier)
        {
            Key.Render(writer);
            writer.Write(" = ");
            Value.Render(writer);
        }
        else
        {
            writer.Write('[');
            Key.Render(writer);
            writer.Write("] = ");
            Value.Render(writer);
        }
    }
}

public sealed class TableValue(Expression value) : TableElement
{
    public Expression Value { get;  } = value;

    public override void Render(IWriter writer)
    {
        Value.Render(writer);
    }
}