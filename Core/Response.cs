//
// This file is part of LinodeCSharpAPI.
//
// LinodeCSharpAPI is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// LinodeCSharpAPI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with LinodeCSharpAPI.  If not, see <http://www.gnu.org/licenses/>.
// 
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
            JObject baseObject = JObject.Parse(JSONResponse);

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
