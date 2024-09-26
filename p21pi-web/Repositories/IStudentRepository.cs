using p21pi_web.Entities;

namespace p21pi_web.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student? GetById(int id);
        Student? GetByIdIncludeGroup(int id);
    }
}