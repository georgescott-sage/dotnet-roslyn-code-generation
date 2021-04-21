using System;

namespace codegen.library.definitions
{
    public class MethodDeclarationBuilder
    {
        private MethodDeclaration method { get; set; }

        public MethodDeclarationBuilder()
        {
            this.method = new MethodDeclaration();
        }

        public MethodDeclaration Build =>  this.method;
        
        public MethodDeclarationBuilder WithName(string name)
        {
            method.Name = name;
            return this;
        }

        public MethodDeclarationBuilder WithReturnType(string returnType)
        {
            method.ReturnType = returnType;
            return this;
        }

        public MethodDeclarationBuilder WithParameter(Tuple<string, string> parameter)
        {
            method.Parameters.Add(parameter);
            return this;
        }

        public MethodDeclarationBuilder WithModifier(string modifier)
        {
            method.Modifiers.Add(modifier);
            return this;
        }
    }
}
