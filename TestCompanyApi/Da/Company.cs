﻿// --------------------------------------------------------------------------------------------------------------------
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
            this.Departments = new List<Department>();
        }

        /// <summary>
        /// Gets or sets collection Companies departments
        /// </summary>
        public ICollection<Department> Departments { get; set; }

        /// <summary>
        /// Gets or sets Company Id
        /// </summary>
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