namespace GeniusFusion_GroupProject.Entities
{
    public class Student
    {
        public int? StudentId { get; set; }
        public string ? StudentName { get; set; }

        public string? StudentEmail { get; set; }

        public List <Enrollment> Enrollments { get; set; }

        

    }
}



