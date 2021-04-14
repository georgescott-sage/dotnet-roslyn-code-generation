using System.Collections.Generic;

namespace dotnet_roslyn_code_generation.SampleEndpointDocs
{
    public class EndpointDetail
    {
        public string Description { get; set; }
        public string HttpAction { get; set; }
        public string Path { get; set; }
        public IEnumerable<PathParameter> PathParameters { get; set; }
    }
}