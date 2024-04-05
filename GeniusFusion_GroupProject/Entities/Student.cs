using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace GeniusFusion_GroupProject.Entities
{
    public class Student
    {

        public Student()
        {
            Enrollments = new List<Enrollment>();
        }
        [Key]
        public int? StudentId { get; set; }
        public string ? StudentName { get; set; }

        public DateTime? dateOfBirth { get; set; }

        public string? StudentPhone { get; set; }

        public string? StudentAddress { get; set; }

        public string? StudentEmail { get; set; }

        public List <Enrollment> Enrollments { get; set; }

        

    }
}



