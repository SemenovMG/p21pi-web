using p21pi_web.Entities;
using p21pi_web.Models.Requests.Students;

namespace p21pi_web.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetById(int id);
        Student AddStudent(AddStudentRequest request);
    }
}
