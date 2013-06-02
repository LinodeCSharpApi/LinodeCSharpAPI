using System.Collections.Generic;

namespace JTraverso.LinodeCSharpAPI.Core
{
    /// <summary>
    /// Batch Request class.
    /// </summary>
    class BatchRequest : IRequest
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
