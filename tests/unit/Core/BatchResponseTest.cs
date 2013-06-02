using JTraverso.LinodeCSharpAPI.Core;
using JTraverso.LinodeCSharpAPI.Core.Payloads;
using NUnit.Framework;

namespace JTraverso.LinodeCSharpAPI.tests.unit.Core
{
    [TestFixture]
    class BatchResponseTest
    {
        BatchResponse testObject;

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void TestBatch()
        {
            string batchPayload = "[ {\"ERRORARRAY\":[], \"ACTION\":\"test\", \"DATA\":[{\"Test\":\"unit\"},{\"Test\":\"unit2\"}, {\"Test\":\"unit3\"}]},{\"ERRORARRAY\":[], \"ACTION\":\"test\", \"DATA\":[{\"Test\":\"unit\"},{\"Test\":\"unit2\"},{\"Test\":\"unit3\"}]} ]";
            this.testObject = new BatchResponse(batchPayload);

            Assert.AreEqual(2, this.testObject.Responses.Count);
        }
    }
}
