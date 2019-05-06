using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using Codereflex.Common.Extentions.TestObjects;

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
