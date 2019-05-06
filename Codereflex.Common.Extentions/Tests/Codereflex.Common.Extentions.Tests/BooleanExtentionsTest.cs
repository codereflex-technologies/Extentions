using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using Codereflex.Common.Extentions.TestObjects;

namespace Codereflex.Common.Extentions.Tests
{
    [TestClass]
    public class BooleanExtentionsTest:TestBase
    {
        [TestMethod]
        public void Test_FileReader()
        {


            "a valid string".IsNullEmptyOrWhiteSpace().IsTrue(() =>  Assert.Fail());
            "".IsNullEmptyOrWhiteSpace().IsFalse(() => Assert.Fail()) ;
            

        }
    }
}
