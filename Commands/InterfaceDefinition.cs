using System;
using System.Collections.Generic;
namespace dotnet_roslyn_code_generation.commands.definitions
{
    public interface InterfaceDefinition
    {
        string Namespace();

        IEnumerable<string> Usings();

        string Name();

        string Summary();

        string BaseType();

        Tuple<string, Type>[] MethodDeclarations();
    }
}
