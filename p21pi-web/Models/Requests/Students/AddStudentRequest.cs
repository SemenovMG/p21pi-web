namespace p21pi_web.Models.Requests.Students
{
    public class AddStudentRequest
    {
        public string Name { get; set; } = "Default";
        public int Age { get; set; }
        public bool IsForeign { get; set; } = false;
    }

    //public class StudentAdress
    //{
    //    public string Street { get; set; } = "Default";
    //    public int HouseNo { get; set; }
    //    public bool IsForeign { get; set; } = false;
    //}
}
