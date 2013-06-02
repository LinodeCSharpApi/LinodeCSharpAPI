using Newtonsoft.Json.Linq;

namespace JTraverso.LinodeCSharpAPI.Core.Payloads
{
    public interface IResponsePayload
    {
        void Deserialize(JToken token);
    }
}
