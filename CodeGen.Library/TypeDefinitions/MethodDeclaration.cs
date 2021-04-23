using System;
using System.Collections.Generic;

namespace codegen.library.definitions
{
    public class MethodDeclaration
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public List<Parameter> Parameters { get; set; }
        public List<string> Modifiers { get; set; }
    }
}
