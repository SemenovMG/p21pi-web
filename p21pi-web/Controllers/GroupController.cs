using Microsoft.AspNetCore.Mvc;

namespace p21pi_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        public GroupController()
        {
        }

        [HttpGet()]
        public string Get()
        {
            return "Hello, World! (GroupController)";
        }
    }
}