﻿namespace TestCompanyApi
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Companies")]
    public class Company
    {
        public Company()
        {
            this.Departments = new List<Department>();
        }

        public ICollection<Department> Departments { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
