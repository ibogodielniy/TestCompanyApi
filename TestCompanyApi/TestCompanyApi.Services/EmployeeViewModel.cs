using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompanyApi.Services
{
    class EmployeeViewModel
    {
        public int Id { get; set; }
        
        public ICollection<Department> DepartmentAllocation { get; set; }
       
        public string Name { get; set; }
        
        public string LastName { get; set; }
        
        public string Description { get; set; }
    }
}
