using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeniusFusion_GroupProject.Entities
{
    public class Enrollment
    {

        
        public int EnrollmentId {get;set;}

        // Foreign key for Course 
        
        public int CourseId { get;set;}
        [JsonIgnore]
        public Course? Course { get;set;}

        // Foreign key for student 

        public int StudentId { get;set;}
        [JsonIgnore]
        public Student? Student { get;set;}

    }
}
