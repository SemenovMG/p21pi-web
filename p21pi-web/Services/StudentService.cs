using p21pi_web.Data;
using p21pi_web.Entities;
using p21pi_web.Models.Requests.Students;

namespace p21pi_web.Services
{
    public class StudentService : IStudentService
    {
        private readonly G21WebContext _db;

        public StudentService(G21WebContext db)
        {
            _db = db;
        }

        public List<Student> GetAll()
        {
            return _db.Students.ToList();
        }

        public Student GetById(int id)
        {
            var student = _db.Students.FirstOrDefault(x => x.Id == id);
            if (student is null)
            {
                throw new Exception($"Student id = {id} not found");
            }
            // LINQ
            return student;
        }

        public List<Student> GetAllOlderThan(int minAge)
        {
            // where, orderby, select, first, firstordefafult
            return _db.Students
                .Where(x => x.Age > minAge)
                .ToList();
        }

        public Student AddStudent(AddStudentRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new Exception("Bad name");
            }
            var newStudent = new Student
            {
                //Id = _nextId,
                Name = request.Name,
                Age = request.Age,
                IsForeign = request.IsForeign,
            };
            //_nextId++;
            _db.Students.Add(newStudent);
            _db.SaveChanges();
            return newStudent;
        }
    }
}
