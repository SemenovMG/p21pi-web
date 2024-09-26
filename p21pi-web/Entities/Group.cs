namespace p21pi_web.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Capacity { get; set; } = 3;
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
    }
}
