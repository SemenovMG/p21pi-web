namespace p21pi_web.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsForeign { get; set; } = false;
        public Group? Group { get; set; }
    }
}
