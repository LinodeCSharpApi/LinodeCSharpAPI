using JTraverso.LinodeCSharpAPI.Core;
using JTraverso.LinodeCSharpAPI.Core.Payloads;
using NUnit.Framework;

namespace JTraverso.LinodeCSharpAPI.tests.unit.Core
{
    [TestFixture]
    class ResponseTest
    {
        Response testObject;

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void TestSimple()
        {
            string rawPayload = "{\"ERRORARRAY\":[], \"ACTION\":\"test\", \"DATA\":{\"Test\":\"unit\"}}";
            this.testObject = new Response(rawPayload);

            Assert.IsEmpty(this.testObject.Errors);
            Assert.AreEqual("test", this.testObject.Action);
            Assert.AreEqual(1, this.testObject.Payloads.Count);
            Assert.AreEqual("unit", ((TestPayload)this.testObject.Payloads[0]).Test);
        }

        [Test]
        public void TestWithErrorArray()
        {
            string rawPayload = "{\"ERRORARRAY\":[{\"ERRORCODE\": 0,\"ERRORMESSAGE\": \"ok\"}], \"ACTION\":\"test\", \"DATA\":{\"Test\":\"unit\"}}";
            this.testObject = new Response(rawPayload);

            Assert.AreEqual("test", this.testObject.Action);
            Assert.AreEqual("unit", ((TestPayload)this.testObject.Payloads[0]).Test);
        }
    }
}
