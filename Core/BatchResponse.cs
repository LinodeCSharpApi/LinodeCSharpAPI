using JTraverso.LinodeCSharpAPI.Core.Payloads;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;

namespace JTraverso.LinodeCSharpAPI.Core
{
    public class BatchResponse : IResponse
    {
        public string JSONString { get; private set; }
        public Collection<Response> Responses { get; private set; }

        public BatchResponse(string JSONResponse)
        {
            this.JSONString = JSONResponse;
            JArray baseObject = JArray.Parse(JSONResponse);

            this.Responses = new Collection<Response>();

            JEnumerable<JToken> childrens = baseObject.Children();
            foreach (JToken child in childrens)
            {
                Response resp = new Response(child.ToString());
                this.Responses.Add(resp);
            }
        }

    }

}
