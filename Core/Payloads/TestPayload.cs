using Newtonsoft.Json.Linq;

namespace JTraverso.LinodeCSharpAPI.Core.Payloads
{
    class TestPayload : IResponsePayload
    {
        public string Test { get; set; }

        public void Deserialize(JToken token)
        {
            this.Test = token["Test"].ToObject<string>();
        }

    }
}
