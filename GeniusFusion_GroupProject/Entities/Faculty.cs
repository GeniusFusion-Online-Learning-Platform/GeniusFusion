namespace GeniusFusion_GroupProject.Entities
{
    public class Faculty 
    { 
        public int FacultyId { get; set; }
        public string? Name { get; set; }
        public string? EmailAddress { get; set;}
        public List<Course> CoursesTaught { get; set; }


    }
}
