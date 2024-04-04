namespace GeniusFusion_GroupProject.Entities
{
    public class Enrollment
    {

        public int EnrollmentId {get;set;}

        // Foreign key for Course 

        public int CourseId { get;set;}
        public Course Course { get;set;}

        // Foreign key for student 

        public int StudentId { get;set;}
        public Student Student { get;set;}

    }
}
