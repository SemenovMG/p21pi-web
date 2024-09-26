using Microsoft.EntityFrameworkCore;
using p21pi_web.Data;
using p21pi_web.Entities;

namespace p21pi_web.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly G21WebContext _db;

        public StudentRepository(G21WebContext db)
        {
            _db = db;
        }

        public List<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }

        public Student? GetById(int id)
        {
            return _db.Students
                .FirstOrDefault(g => g.Id == id);
        }

        public Student? GetByIdIncludeGroup(int id)
        {
            return _db.Students
                .Include(s => s.Group)
                .FirstOrDefault(s => s.Id == id);
        }
    }
}
