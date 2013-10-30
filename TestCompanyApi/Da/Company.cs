using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TestCompanyApi 
{
    [Table("Companies")]
    public class Company 
    {
        public ICollection<Department> DepartmentAllocation { get; set; }

        public Company()
        {
            DepartmentAllocation = new HashSet<Department>();
        }

        [Key]
        public int id{get;set;}

        public string Name{get;set;}

        public string Description{get;set;}
    }
}
