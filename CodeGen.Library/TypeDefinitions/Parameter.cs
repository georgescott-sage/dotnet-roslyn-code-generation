namespace codegen.library.definitions
{
    public class Parameter
    {
        public Parameter(string name, string type)
        {
            this.Type = type;
            this.Name = name;
        }
        
        public string Type { get; set; }

        public string Name { get; set; }
    }
}
