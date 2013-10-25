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
using System.Collections.Generic;

namespace JTraverso.LinodeCSharpAPI.Core
{
    /// <summary>
    /// Batch Request class.
    /// </summary>
    public class BatchRequest : IRequest
    {
        /// <summary>
        /// Batched Requests list.
        /// </summary>
        private List<Request> requests;

        /// <summary>
        /// Constructor
        /// </summary>
        public BatchRequest()
        {
            this.requests = new List<Request>();
        }

        /// <summary>
        /// Adds a Request to a Batch Request
        /// </summary>
        /// <param name="req">Request object</param>
        public void AddRequest(Request req)
        {
            this.requests.Add(req);
        }

        /// <summary>
        /// Returns the POST payload for the batch request.
        /// </summary>
        /// <returns>POST payload string</returns>
        public string GetPOSTString()
        {
            string output = "api_action=batch&api_requestArray=" + this.GetJSON();

            return output;
        }

        /// <summary>
        /// Returns the batched requests in JSON format.
        /// </summary>
        /// <returns>JSON string</returns>
        public string GetJSON()
        {
            string output = "[";
            foreach (Request req in requests)
            {
                output = output + req.GetJSON() + ", ";
            }

            output = output.Trim(' ').Trim(',') + "]";

            return output;
        }
    }
}
