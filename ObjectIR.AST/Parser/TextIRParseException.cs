namespace ObjectIR.Ast.Parser;

public sealed class TextIrParseException : Exception
{
    public TextIrParseException(string message) : base(message) { }
}