using System;

namespace dotnet_roslyn_code_generation.builders
{
    public class MethodDeclaration
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Tuple<string, string>[] Parameters { get; set;}
    }
}
