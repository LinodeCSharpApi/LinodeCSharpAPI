using Newtonsoft.Json.Linq;

namespace JTraverso.LinodeCSharpAPI.Core.Payloads
{
    public class ErrorPayload : IResponsePayload
    {
        public string ERRORCODE { get; set; }
        public string ERRORMESSAGE { get; set; }

        public void Deserialize(JToken token)
        {
            this.ERRORCODE = token["ERRORCODE"].ToObject<string>();
            this.ERRORMESSAGE = token["ERRORMESSAGE"].ToObject<string>();
        }
    }
}
