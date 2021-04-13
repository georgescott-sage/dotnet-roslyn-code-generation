using System;
using System.Collections.Generic;
using dotnet_roslyn_code_generation.builders;

namespace dotnet_roslyn_code_generation.commands.definitions
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
