using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using Codereflex.Common.Extentions.TestObjects;
using System.Net;

namespace Codereflex.Common.Extentions.Tests
{
    [TestClass]
    public class StringExtentionsTests : TestBase
    {
        [TestMethod]
        public void Test_FileReader()
        {

            
            "./test.txt".File().Stream().ForEachLine(line => {
                    line.Should().NotBeNullOrWhiteSpace();     
            } );

        }

        [TestMethod]
        public void Test_IsJson()
        {

            "{}".IsJson().Should().BeTrue();
             employeejsonstring.IsJson().Should().BeTrue();
            "".IsJson().Should().BeFalse();
            nullstring.IsJson().Should().BeFalse();
           
        }

        [TestMethod]
        public void Test_JsonMapper()
        {
            Employee actualemp = new Employee();
            employeejsonstring.Json().Map().From("$.Name").Into<string>(r => actualemp.Name = r)
                                        .From("$.BasePay").Into<decimal>(r => actualemp.BasePay = r)
                                        .From("$.TypeOfEmployement").Into<int>(r => actualemp.TypeOfEmployement = (EmployementType)r);

            actualemp.Name.Should().Be(employeetestobject.Name);
            actualemp.BasePay.Should().Be(employeetestobject.BasePay);
            actualemp.TypeOfEmployement.Should().Be(employeetestobject.TypeOfEmployement);

            //Test with map to Enum
            string statuscode = "{\"status\": 200}";
            System.Net.HttpStatusCode statusCode;
            statuscode.Json().Map().From("$.status").Into<int>(r => statusCode = (System.Net.HttpStatusCode)r);
         
        }

        [TestMethod]
        public void Test_BetweenDelimiters()
        {
            string basestring = @"File upload started, filename:'EN32515_17_05_2019_15_28_07.xml',username:'test@google.com'";
            string expected = "EN32515_17_05_2019_15_28_07.xml";
            string actual = basestring.BetweenDelimiters("filename:'", "',");
            actual.Should().Be(expected);
            expected = "test@google.com";
            actual = basestring.BetweenDelimiters("username:'", "'");
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Test_WhenMethod()
        {
            string stringval = "1d";
            Action act = () => stringval.To<int>((actual) => actual.Should().Be(10),true);
            act.Should().Throw<FormatException>();
            act = () => stringval.To<int>((actual) => actual.Should().Be(0));
            act.Should().NotThrow<FormatException>();
            stringval = "10.00";
            stringval.To<double>((actual) => actual.Should().Be(10.00));
            stringval = "true";
            stringval.To<bool>((actual) => actual.Should().Be(true));
            stringval = "false";
            stringval.To<bool>((actual) => actual.Should().Be(false));
            stringval = "200";
             HttpStatusCode expected = HttpStatusCode.OK;
            stringval.To<int>((actual) => {

                ((HttpStatusCode)actual).Should().Be(expected);
               });
        }

        [TestMethod]
        public void Test_DelimitedMapper()
        {
            var expectedemployeeobject = new Employee();
            employeecsvstring.DelimtedString(",").Map().From(0).Into<string>(r => expectedemployeeobject.Name = r)
                                                       .From(1).Into<EmployementType>(r => expectedemployeeobject.TypeOfEmployement = r)
                                                       .From(2).Into<string>(r =>  expectedemployeeobject.Address.AddressLine1 = r)
                                                       .From(3).Into<string>(r =>  expectedemployeeobject.Address.AddressLine2 = r)
                                                       .From(4).Into<string>(r =>  expectedemployeeobject.Address.Town = r)
                                                       .From(5).Into<string>(r =>  expectedemployeeobject.Address.PostCode = r)
                                                       .From(6).Into<Decimal>(r =>  expectedemployeeobject.BasePay = r);
            expectedemployeeobject.Should().NotBeNull();
            expectedemployeeobject.Should().BeEquivalentTo(employeetestobject);
        }

        [TestMethod]
        public void Test_ToObject()
        {
            
            Employee employee = employeejsonstring.Json().ToObject<Employee>();
            employee.Should().NotBeNull();
                
        }
        [TestMethod]

        public void Test_IsNullEmptyOrWhiteSpace()
        {

            "".IsNullEmptyOrWhiteSpace().Should().BeTrue();
            "  ".IsNullEmptyOrWhiteSpace().Should().BeTrue();

            string value = null;
            value.IsNullEmptyOrWhiteSpace().Should().BeTrue();

            "NotaNullEmptyorWhiteSpaceString".IsNullEmptyOrWhiteSpace().Should().BeFalse();
        }

        [TestMethod]
        public void Test_ThrowIfNullEmptyOrWhiteSpace()
        {
            Action act = () => "".ThrowIfNullEmptyOrWhiteSpace();
            act.Should().Throw<ArgumentException>();

            act = () => "  ".ThrowIfNullEmptyOrWhiteSpace();
            act.Should().Throw<ArgumentException>();

            string value = null;
            act = () => value.ThrowIfNullEmptyOrWhiteSpace();
            act.Should().Throw<ArgumentException>();

            act = () => "NotaNullEmptyorWhiteSpaceString".ThrowIfNullEmptyOrWhiteSpace();
            act.Should().NotThrow<ArgumentException>();
        }
    }
}
