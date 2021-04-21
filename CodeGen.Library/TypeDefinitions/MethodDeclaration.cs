using System;

namespace codegen.library.definitions
{
    public class MethodDeclaration
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public Tuple<string, string>[] Parameters { get; set;}
        public string[] Modifiers { get; set; }
    }
}
