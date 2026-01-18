namespace ObjectIR.Backend.Lua.Ast;

public sealed class TableConstructorExpression(CaptureList<TableElement> values) : Expression
{
    public CaptureList<TableElement> Values { get; } = values;
    
    public override void Render(IWriter writer)
    {
        values.Render(writer);
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