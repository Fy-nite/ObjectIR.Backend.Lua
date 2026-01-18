using ObjectIR.Ast;
using ObjectIR.Backend.Lua.Ast;
using Statement = ObjectIR.Backend.Lua.Ast.Statement;
using EvalStack = System.Collections.Generic.Stack<ObjectIR.Backend.Lua.Ast.Statement>;

namespace ObjectIR.Backend.Lua;

public static class LuaResolver
{
    public static AstTree ResolveModule(ModuleNode module)
    {
        var statements = new List<Statement>();
        return new AstTree(statements);
    }

    public static void ResolveClass(ClassNode c, ref List<Statement> statements)
    {
        // local [ident] = {}
        statements.Add(new LocalStatement(
            new CaptureList<Identifier>(new Identifier(c.Name)),
            new CaptureList<Expression>(new TableConstructorExpression(new CaptureList<TableElement>()))
        ));
        
        // [ident].__index = [ident]
        statements.Add(new AssignmentStatement(
            new CaptureList<Expression>(new MemberExpression(new Identifier(c.Name), new Identifier("__index"))),
            new CaptureList<Expression>(new Identifier(c.Name))
        ));

        foreach (var method in c.Methods)
        {
            ResolveMethod(c, method, ref statements);
        }
    }

    private static void ResolveMethod(ClassNode c, MethodNode m, ref List<Statement> statements)
    {
        // [class].[method] = function(<static? self>, <args...>) [block] end
        var left = new MemberExpression(new Identifier(c.Name), new Identifier(m.Name));
        var args = new CaptureList<Identifier>();
        
        if (!m.IsStatic) args.Add(new Identifier("self"));
        foreach (var param in m.Parameters)
        {
            args.Add(new Identifier(param.Name));
        }
        
        var body = ResolveBlock(m.Body, new EvalStack());
        var right = new FunctionExpression(args, body);
        statements.Add(new AssignmentStatement(new CaptureList<Expression>(left), new CaptureList<Expression>(right)));
    }

    private static Block ResolveBlock(BlockStatement block, EvalStack stack)
    {
        return new Block(block.Statements.Select(v => ResolveStatement(v, stack)).ToList());
    }

    private static Statement ResolveStatement(ObjectIR.Ast.Statement statement, EvalStack stack)
    {
        return statement switch
        {
            InstructionStatement i => ResolveStatement(i, stack),
            ObjectIR.Ast.IfStatement i => ResolveStatement(i, stack),
            ObjectIR.Ast.WhileStatement w => ResolveStatement(w, stack),
            LocalDeclarationStatement l => ResolveStatement(l, stack),
            _ => throw new Exception($"Statement {statement} is not supported.")
        };
    }

    private static Statement ResolveStatement(InstructionStatement statement, EvalStack stack)
    {
        return ResolveInstruction(statement.Instruction, stack);
    }

    private static Statement ResolveStatement(ObjectIR.Ast.IfStatement statement, EvalStack stack)
    {
        throw new NotImplementedException();
    }

    private static Statement ResolveStatement(ObjectIR.Ast.WhileStatement statement, EvalStack stack)
    {
        throw new NotImplementedException();
    }

    private static Statement ResolveStatement(LocalDeclarationStatement statement, EvalStack stack)
    {
        throw new NotImplementedException();
    }

    private static Statement ResolveInstruction(Instruction instruction, EvalStack stack)
    {
        return instruction switch
        {
            CallInstruction call => ResolveInstruction(call, stack),
            NewObjInstruction newObj => ResolveInstruction(newObj, stack),
            SimpleInstruction simple => ResolveInstruction(simple, stack),
            _ => throw new Exception($"Instruction {instruction} is not supported.")
        };
    }

    private static Statement ResolveInstruction(CallInstruction instruction, EvalStack stack)
    {
        throw new NotImplementedException();
    }

    private static Statement ResolveInstruction(NewObjInstruction instruction, EvalStack stack)
    {
        throw new NotImplementedException();
    }

    private static Statement ResolveInstruction(SimpleInstruction instruction, EvalStack stack)
    {
        throw new NotImplementedException();
    }
}