using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department Code Must Be Fill Up")]
        [Column(TypeName = "Varchar")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code must be between 2 to 7 character")]

        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name ")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DepartmentName { get; set; }
    }
}