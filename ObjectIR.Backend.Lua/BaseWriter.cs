using System.Text;

namespace ObjectIR.Backend.Lua;

public class BaseWriter : IWriter
{
    private int _indent;
    public int IndentSize => 4;
    public int Indent => _indent;

    private readonly StringBuilder _output = new();
    
    public void PushIndent() => _indent++;
    public void PopIndent() => _indent--;

    public void Write(string value)
    {
        _output.Append(value);
    }

    public void Write(char value)
    {
        _output.Append(value);
    }

    public void WriteLine()
    {
        _output.AppendLine();
    }
    
    public void WriteLine(string value)
    {
        _output.AppendLine(value);
    }

    public void WriteLine(char value)
    {
        _output.AppendLine(value.ToString());
    }

    public void WriteIndent()
    {
        _output.Append(' ', _indent * IndentSize);
    }

    public void Remove(int length)
    {
        _output.Remove(length, _indent * IndentSize);
    }
}