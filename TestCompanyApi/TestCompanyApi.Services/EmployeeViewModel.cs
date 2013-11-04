namespace TestCompanyApi.Services
{
    using System.Collections.Generic;

    public class EmployeeViewModel
    {
        public int Id { get; set; }
        
        public ICollection<Department> DepartmentAllocation { get; set; }
       
        public string Name { get; set; }
        
        public string LastName { get; set; }
        
        public string Description { get; set; }
    }
}
