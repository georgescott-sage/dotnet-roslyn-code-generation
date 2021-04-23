using System;

namespace codegen.library.definitions
{
    public class MethodDeclarationBuilder
    {
        private MethodDeclaration method { get; set; }

        public MethodDeclarationBuilder(string name)
        {
            this.method = new MethodDeclaration()
            {
                Name = name,
                ReturnType = "void",
                Parameters = new System.Collections.Generic.List<Parameter>(),
                Modifiers = new System.Collections.Generic.List<string>()
            };
        }

        public MethodDeclaration Build() =>  this.method;
        
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

        public MethodDeclarationBuilder WithParameter(Parameter parameter)
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
