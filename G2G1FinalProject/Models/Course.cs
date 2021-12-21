using System;
using System.ComponentModel.DataAnnotations;

namespace G2G1FinalProject.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Enter Course Name")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Enter Course Price")]
        [Display(Name = "Course Price")]
        [DataType(DataType.Currency)]
        public decimal CoursePrice { get; set; }

        [Required(ErrorMessage = "Enter Start Date")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime CourseDate { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Display(Name = "Trainer")]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }


    }
}
