using JTraverso.LinodeCSharpAPI;

namespace LinodeCSharpAPIEXample
{
    class Program
    {
        static void Main(string[] args)
        {
            LinodeAPI api = new LinodeAPI();
            /*string errorPayload = "{\"ERRORARRAY\":[1,24,20], \"ACTION\":\"test\", \"DATA\":[{\"Test\":\"unit\"},{\"Test\":\"unit2\"},{\"Test\":\"unit\"}]}";
            Response errorObject = new Response(errorPayload);

            string rawPayload = "{\"ERRORARRAY\":[], \"ACTION\":\"test\", \"DATA\":[{\"Test\":\"unit\"},{\"Test\":\"unit2\"},{\"Test\":\"unit\"}]}";
            Response testObject = new Response(rawPayload);

            string batchPayload = "[ {\"ERRORARRAY\":[], \"ACTION\":\"test\", \"DATA\":[{\"Test\":\"unit\"},{\"Test\":\"unit2\"}, {\"Test\":\"unit3\"}]},{\"ERRORARRAY\":[], \"ACTION\":\"test\", \"DATA\":[{\"Test\":\"unit\"},{\"Test\":\"unit2\"},{\"Test\":\"unit3\"}]} ]";
            BatchResponse batchObject = new BatchResponse(batchPayload);*/
        }
    }
}
