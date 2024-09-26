using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using p21pi_web.Constants;
using p21pi_web.Entities;
using p21pi_web.Models.Requests.Students;
using p21pi_web.Services;

namespace p21pi_web.Controllers
{
    [ApiController]
    [Route("[controller]")] //StudentController -> /Student
    // Http Method - GET POST PUT DELETE
    // /student/{*path-tail}
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService service)
        {
            _studentService = service;
        }

        [HttpGet()]
        public List<Student> Get(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            return _studentService.GetAll();
        }

        // TODO: add Admin check
        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            return _studentService.GetById(id);
        }

        [HttpPost()]
        public Student AddStudent(
            [FromBody] AddStudentRequest request)
        {
            return _studentService.AddStudent(request);
        }

        [Authorize]
        [HttpGet("/my-profile")]
        public ActionResult TestAuth()
        {
            var id = 0;

            try
            {
                id = TryGetStudentId();
            }
            catch (Exception)
            {
                return Forbid();
            }

            return Ok(_studentService.GetById(id));
        }

        //[Authorize]
        //[HttpGet("/my-group")]
        //public ActionResult TestAuth()
        //{
        //    var id = 0;

        //    try
        //    {
        //        id = TryGetStudentId();
        //    }
        //    catch (Exception)
        //    {
        //        return Forbid();
        //    }

        //    return Ok(_studentService.GetById(id));
        //}

        private int TryGetStudentId()
        {
            var studentIdString = User
                .FindFirst(c => c.Type == AuthConstants.StudentIdClaimType)
                ?.Value;

            if (string.IsNullOrEmpty(studentIdString))
            {
                throw new Exception("StudentId is empty");
            }

            return int.Parse(studentIdString);
        }

        //[HttpPut()]
        //public string UpdateStudent()
        //{
        //    return "Update student";
        //}

        //[HttpDelete()]
        //public string DeleteStudent()
        //{
        //    return "Delete student";
        //}
    }
}