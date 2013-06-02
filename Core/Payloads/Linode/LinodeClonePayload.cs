using Newtonsoft.Json.Linq;

namespace JTraverso.LinodeCSharpAPI.Core.Payloads
{
    class LinodeClonePayload : IResponsePayload
    {
        public int LinodeID { get; set; }

        public void Deserialize(JToken token)
        {
            this.LinodeID = token["LinodeID"].ToObject<int>();
        }
    }
}
