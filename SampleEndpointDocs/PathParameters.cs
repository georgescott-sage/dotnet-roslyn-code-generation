namespace dotnet_roslyn_code_generation.SampleEndpointDocs
{
    public class PathParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public bool Required { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public string Description { get; set; }
        public string AllowedValues { get; set; }

    }
}