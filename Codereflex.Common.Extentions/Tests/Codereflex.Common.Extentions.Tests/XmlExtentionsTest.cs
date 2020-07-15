using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using Codereflex.Common.Extentions.TestObjects;

namespace Codereflex.Common.Extentions.Tests
{
    [TestClass]
    public class XmlExtenstionTest:TestBase
    {
        [TestMethod]
        public void Test_XmlToObject()
        {
            string empxml = employeetestobject.ToXml();
            Employee employee = empxml.Xml().ToObject<Employee>();
            employee.Should().NotBeNull();

        }
    }
}
