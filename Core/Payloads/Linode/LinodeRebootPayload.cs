using Newtonsoft.Json.Linq;

namespace JTraverso.LinodeCSharpAPI.Core.Payloads
{
    class LinodeRebootPayload : IResponsePayload
    {
        public int JobID { get; set; }

        public void Deserialize(JToken token)
        {
            this.JobID = token["JobID"].ToObject<int>();
        }
    }
}
