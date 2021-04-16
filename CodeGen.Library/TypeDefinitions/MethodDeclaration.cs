using System;

namespace codegen.definitions.commands.definitions
{
    public class MethodDeclaration
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Tuple<string, string>[] Parameters { get; set;}
        public string[] Modifiers { get; set; }
    }
}
