using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Please Give the Name")]
        [Column(TypeName = "Varchar")]
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "Please Give the  Address")]

        [Column(TypeName = "text")]
        public string TeacherAddress { get; set; }
        [Required(ErrorMessage = "Please Give the  Email")]

        [DataType(DataType.EmailAddress)]
        [Remote("IsEmailExist", "Teacher", ErrorMessage = "Email already exist")]
        public string TeacherEmail { get; set; }
        [Required(ErrorMessage = "Please Give the Contact No")]
        [Column(TypeName = "Varchar")]
        public string TeacherContactNo { get; set; }
        [Required(ErrorMessage = "Please Select  the  Designation")]



        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please Select  the  Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please Select  the  Department")]

        public int DepartmentId { get; set; }
        [Range(+.5, 50, ErrorMessage = "Credit Can not be negetive")]
        [Required(ErrorMessage = "Please Give the Credit")]

        public double CreditToBeTaken { get; set; }

        public virtual Department Department { get; set; }

        public virtual Designation Designation { get; set; }

        public double CourseTaken { get; set; }

    }
}