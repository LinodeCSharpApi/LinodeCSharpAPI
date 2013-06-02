using JTraverso.LinodeCSharpAPI.Core;
using NUnit.Framework;

namespace JTraverso.LinodeCSharpAPI.tests.unit.Core
{
    [TestFixture]
    class BatchRequestTest
    {
        BatchRequest testObject;

        [SetUp]
        public void Init()
        {
            this.testObject = new BatchRequest();
        }

        private void AddRequests()
        {
            Request req = new Request();

            req.AddParam("test", "one");
            req.SetApiAction("test.echo");
            this.testObject.AddRequest(req);

            Request req2 = new Request();

            req2.AddParam("test", "two");
            req2.SetApiAction("test.echo");
            this.testObject.AddRequest(req2);

            Request req3 = new Request();

            req3.AddParam("test", "three");
            req3.SetApiAction("test.echo");
            this.testObject.AddRequest(req3);
        }

        [Test]
        public void TestGETJson()
        {
            this.AddRequests();

            string expected = "[{\"api_action\": \"test.echo\", \"test\": \"one\"}, {\"api_action\": \"test.echo\", \"test\": \"two\"}, {\"api_action\": \"test.echo\", \"test\": \"three\"}]";
            Assert.AreEqual(expected, this.testObject.GetJSON());
        }

        [Test]
        public void TestGetPOSTString()
        {
            this.AddRequests();

            string expected = "api_action=batch&api_requestArray=[{\"api_action\": \"test.echo\", \"test\": \"one\"}, {\"api_action\": \"test.echo\", \"test\": \"two\"}, {\"api_action\": \"test.echo\", \"test\": \"three\"}]";
            Assert.AreEqual(expected, this.testObject.GetPOSTString());
        }
    }
}
