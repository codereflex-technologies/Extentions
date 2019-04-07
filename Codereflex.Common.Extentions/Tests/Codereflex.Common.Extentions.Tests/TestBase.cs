using Codereflex.Common.Extentions.TestObjects;

namespace Codereflex.Common.Extentions.Tests
{
    public class TestBase
    {
        protected readonly string  employeejsonstring = "{ \"Name\":\"Tom\",\"TypeOfEmployement\": 1,\"Address\":{ \"AddressLine1\":\"2\",\"AddressLine2\":\"Penman way\",\"Town\":\"dxb\",\"PostCode\":\"695501\"},\"BasePay\":2345.67}";
        protected readonly string employeecsvstring = "Tom,1,2,Penman way,dxb,695501,2345.67";
        protected readonly string nullstring = null;
        protected readonly Employee employeetestobject = new Employee
        {
            Name = "Tom",
            BasePay = 2345.67M,
            TypeOfEmployement = EmployementType.Contract,
            Address = new Address
            {
                AddressLine1 = "2",
                AddressLine2 = "Penman way",
                PostCode = "695501",
                Town = "dxb"

            }
        };

    }
}
