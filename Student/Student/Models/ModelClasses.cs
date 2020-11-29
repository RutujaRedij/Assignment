using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Models
{
    public class StudentInfo
    {
        [Key]
        public int StudentKeyId { get; set; }
        [Required(ErrorMessage = "StudentId is Must")]
        [StringLength(200, ErrorMessage = "StudentId can be 200 characters max")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Student Name is Must")]
        [StringLength(200, ErrorMessage = "Student Name can be 200 characters max")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Email Name is Must")]
        [DataType(DataType.EmailAddress,ErrorMessage ="E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is Must")]
        [StringLength(500, ErrorMessage = "Address Name can be 500 characters max")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is Must")]
        [StringLength(200, ErrorMessage = "City can be 200 characters max")]
        public string City { get; set; }
        [Required(ErrorMessage = "Area of interest is Must")]
        [StringLength(200, ErrorMessage = "Area of interest can be 200 characters max")]
        public string AreaofInterest { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public string DOB { get; set; }
        [Required(ErrorMessage = "CourseCompleted is Must")]
        [StringLength(200, ErrorMessage = "CourseCompleted can be 200 characters max")]
     
        public string CourseCompleted { get; set; }

        //public virtual ICollection<Course> Courses { get; set; }
    }
    public class Course
    {
        [Key]
       public int CourseKeyId { get; set; }
        [Required(ErrorMessage = "CourseId is Must")]
        [StringLength(50, ErrorMessage = "CourceId can be 50 characters max")]
        public string CourseId { get; set; }

        [Required(ErrorMessage = "CourseName is Must")]
        [StringLength(200, ErrorMessage = "CourceName can be 50 characters max")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "NumberofModules is Must")]
        public int NumderofModules { get; set; }
        [Required(ErrorMessage = "Price is Must")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Student id is Must")]

       // public int StudentId { get; set; }
        public int TrainerKeyId { get; set; }


       // public virtual Student Student{ get; set; }
        public virtual Trainer Trainer { get; set; }


    }
    public class Trainer
    {
        [Key]
       public int TrainerKeyId { get; set; }
        [Required(ErrorMessage = "TrainerId is Must")]
        [StringLength(50, ErrorMessage = "TrainerId can be 200 characters max")]
        public string TrainerId { get; set; }

        [Required(ErrorMessage = "TrainerName is Must")]
        [StringLength(200, ErrorMessage = "TrainerName can be 200 characters max")]
        public string TrainerName { get; set; }

        [Required(ErrorMessage = "TrainerName is Must")]
        [StringLength(200, ErrorMessage = "TrainerName can be 200 characters max")]
        public string Expertise { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }

    public class Studentcource
    {
        [Key]
        public int StudentCourseId { get; set; }
        public int StudentKeyId { get; set; }
        public int CourseKeyId { get; set; }
        public virtual ICollection<StudentInfo> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}