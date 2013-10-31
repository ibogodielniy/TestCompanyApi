// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Company.cs" company="">
//   
// </copyright>
// <summary>
//   Domain class of Company
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestCompanyApi
{
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
    
    /// <summary>
    /// Domain class of Company
    /// </summary>
    [Table("Companies")]
    public class Company
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class
        /// </summary>
        public Company()
        {
            this.DepartmentAllocation = new HashSet<Department>();
        }

        /// <summary>
        /// Gets or sets collection Companies departments
        /// </summary>
        public ICollection<Department> DepartmentAllocation { get; set; }

        /// <summary>
        /// Gets or sets Company Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Company Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Company Description
        /// </summary>
        public string Description { get; set; }
    }
}
