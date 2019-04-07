namespace Codereflex.Common.Extentions.TestObjects
{
    public class Employee
    {
        public Employee()
        {
            Address = new Address();
        }
        public string Name { get; set; }
        public EmployementType TypeOfEmployement { get; set; }
        public Address Address { get; set; }

        public decimal BasePay { get; set; }
    }

    public enum EmployementType
    {
        Permanant,
        Contract,
        PartTime
    }



}
