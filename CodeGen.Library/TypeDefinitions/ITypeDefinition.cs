using System;
using System.Collections.Generic;

namespace codegen.definitions.commands.definitions
{
    public interface ITypeDefinition
    {
        string Namespace();

        IEnumerable<string> Usings();

        string Name();

        string Summary();

        string BaseType();

        MethodDeclaration[] MethodDeclarations();
    }
}
