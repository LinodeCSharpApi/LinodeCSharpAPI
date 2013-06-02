using JTraverso.LinodeCSharpAPI.Core.Payloads;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;

namespace JTraverso.LinodeCSharpAPI.Core
{
    public class Response : IResponse
    {
        public string JSONString { get; private set; }
        public Collection<IResponsePayload> Payloads { get; private set; }
        public Collection<ErrorPayload> Errors { get; private set; }
        public string Action { get; private set; }

        public Response(string JSONResponse)
        {
            this.JSONString = JSONResponse;
            JObject baseObject = JObject.Parse(JSONResponse.Replace("\"DATA\":{", "\"DATA\":[{").Replace("}}", "}]}"));

            this.Action = baseObject["ACTION"].ToObject<string>();
            this.Payloads = new Collection<IResponsePayload>();
            this.Errors = new Collection<ErrorPayload>();
            
            JEnumerable<JToken> errChildrens = baseObject["ERRORARRAY"].Children();
            foreach (JToken child in errChildrens)
            {
                ErrorPayload errPayload = new ErrorPayload();
                errPayload.Deserialize(child);

                this.Errors.Add(errPayload);
            }
            JEnumerable<JToken> childrens = baseObject["DATA"].Children();
            foreach (JToken child in childrens)
            {
                IResponsePayload payload = Utils.GetPayloadClass(this.Action);
                if (payload != null)
                {
                    payload.Deserialize(child);

                    this.Payloads.Add(payload);
                }
            }
        }
    }
}
