namespace TestCompanyApi
{
    using System.Collections.Generic;

    public class Employee
    {
        public int Id { get; set; }

        public virtual ICollection<Department> DepartmentAllocation { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }
    }
}
