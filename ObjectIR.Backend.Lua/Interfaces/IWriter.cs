namespace ObjectIR.Backend.Lua;

public interface IWriter
{
    public int IndentSize { get; }
    public int Indent { get;  }

    public void PushIndent();
    public void PopIndent();
    public void Write(string value);
    public void Write(char value);
    public void WriteLine();
    public void WriteLine(string value);
    public void WriteIndent();
    public void Remove(int length);
}