using System.ComponentModel.DataAnnotations;

namespace GeniusFusion_GroupProject.Entities
{
    public class Faculty 
    {
        public Faculty()
        {
            CoursesTaught = new List<Course>();
        }
        [Key]
        public int FacultyId { get; set; }

        public string? FacultyName { get; set; }

        public DateTime? dateOfBirth { get; set; }

        public string? FacultyPhone { get; set; }

        public string? FacultyAddress { get; set; }

        public string? FacultyEmail { get; set;}
        public List<Course> CoursesTaught { get; set; }


    }
}
