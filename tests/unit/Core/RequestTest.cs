using JTraverso.LinodeCSharpAPI.Core;
using NUnit.Framework;

namespace JTraverso.LinodeCSharpAPI.tests.unit.Core
{
    [TestFixture]
    class RequestTest
    {
        Request testObject;

        [SetUp]
        public void Init()
        {
            this.testObject = new Request();
            this.testObject.AddParam("testParam", "testValue");
        }

        [Test]
        public void SetAction()
        {
            this.testObject.SetApiAction("test.echo");
            Assert.AreEqual(this.testObject.GetApiAction(), "test.echo");
        }

        [Test]
        public void AddParameter()
        {
            Assert.AreEqual(this.testObject.AddParam("testParam","testValue"), this.testObject);
        }

        [Test]
        public void TryAddExistingParameter()
        {
            Assert.AreEqual(this.testObject.AddParam("testParam", "changedValue"), this.testObject);
            Assert.AreEqual(this.testObject.GetParam("testParam"), "changedValue");
        }

        [Test]
        public void TryAddNullParameter()
        {
            Assert.AreEqual(this.testObject.AddParam(null, "testValue"), false);
        }

        [Test]
        public void TryAddApiActionParameter()
        {
            Assert.AreEqual(this.testObject.AddParam("api_action", "test.echo"), false);
        }

        [Test]
        public void HasParam()
        {
            Assert.IsTrue(this.testObject.HasParam("testParam"));
        }

        [Test]
        public void DoesNotHasParam()
        {
            Assert.IsFalse(this.testObject.HasParam("notValid"));
        }

        [Test]
        public void GetParam()
        {
            Assert.AreEqual(this.testObject.GetParam("testParam"), "testValue");
        }

        [Test]
        public void GetMissingParameter()
        {
            Assert.IsNull(this.testObject.GetParam("notValid"));
        }

        [Test]
        public void RemoveParam()
        {
            this.testObject.RemoveParam("testParam");
            Assert.IsFalse(this.testObject.HasParam("testParam"));
        }

        [Test]
        public void GetPOSTString()
        {
            this.testObject.SetApiAction("unitTest");
            this.testObject.AddParam("testParam", "testValue");
            this.testObject.AddParam("test", "echo");
            this.testObject.AddParam("myParam", "myValue");
            this.testObject.AddParam("another", "one");

            string expected = "api_action=unitTest&testParam=testValue&test=echo&myParam=myValue&another=one";
            Assert.AreEqual(expected, this.testObject.GetPOSTString());
        }

        [Test]
        public void GetJSON()
        {
            this.testObject.SetApiAction("unitTest");
            this.testObject.AddParam("testParam", "testValue");
            this.testObject.AddParam("test", "echo");
            this.testObject.AddParam("myParam", "myValue");
            this.testObject.AddParam("another", "one");

            string expected = "{\"api_action\": \"unitTest\", \"testParam\": \"testValue\", \"test\": \"echo\", \"myParam\": \"myValue\", \"another\": \"one\"}";
            Assert.AreEqual(expected, this.testObject.GetJSON());
        }
    }
}

