using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JTraverso.LinodeCSharpAPI.Core;

namespace JTraverso.LinodeCSharpAPI.tests.unit
{
    [TestFixture]
    class LinodeApiTest
    {
        LinodeAPI apiObject;

        [SetUp]
        public void Init()
        {
            this.apiObject = new LinodeAPI();
        }

        [Test]
        public void TestGet()
        {
            Response response = (Response)this.apiObject.Get("api.spec", new Dictionary<string, string>());
        }
    }
}
