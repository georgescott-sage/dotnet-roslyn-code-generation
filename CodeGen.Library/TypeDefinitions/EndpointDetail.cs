using System.Collections.Generic;

namespace codegen.definitions.commands.definitions
{
    public class EndpointDetail
    {
        public string Description { get; set; }
        public string HttpAction { get; set; }
        public string Path { get; set; }
        public IEnumerable<PathParameter> PathParameters { get; set; }

        //how to parse? get from policy?
        public string Resource { get; set; }
        public string Operation => $"{HttpAction}{Resource}";
        public string CommandName => $"{Operation}Command";
        public string CommandRequest => $"{Operation}CommandRequest";
        public string CommandResponse => $"{Operation}CommandResponse";
        public string QueryRequest => $"{Operation}QueryRequest";
    }
}