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
