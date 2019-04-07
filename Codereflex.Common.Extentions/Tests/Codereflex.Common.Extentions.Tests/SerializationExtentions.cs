using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;

namespace Codereflex.Common.Extentions.Tests
{
    [TestClass]
    public class SerializationExtentionsTests : TestBase
    {
        [TestMethod]
        public void Test_ToJson()
        {
           
           string empjson = employeetestobject.ToJson();
           empjson.Should().NotBeNullOrWhiteSpace();
           
        }
        [TestMethod]
        public void Test_ToXml()
        {
          
            string empxml = employeetestobject.ToXml();
            empxml.Should().NotBeNullOrWhiteSpace();
        }
    }
}
