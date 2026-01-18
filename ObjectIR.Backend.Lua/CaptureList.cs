using ObjectIR.Backend.Lua.Ast;

namespace ObjectIR.Backend.Lua;


public sealed class CaptureList<T>(List<T> values) : Node where T : Node
{
    public IList<T> Values { get; } = values;

    public CaptureList(T value) : this(new List<T> { value }) { }
    public CaptureList() : this(new List<T>()) { }

    public void Add(T value)
    {
        Values.Add(value);
    }

    public override void Render(IWriter writer)
    {
        Render(writer, ", ");
    }

    public void Render(IWriter writer, string separator)
    {
        for (int i = 0; i < Values.Count(); i++)
        {
            Values.ElementAt(i).Render(writer);
            if (i < Values.Count() - 1)
            {
                writer.Write(separator);
            }
        }
    }
}