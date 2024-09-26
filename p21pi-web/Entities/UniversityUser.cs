using Microsoft.AspNetCore.Identity;

namespace p21pi_web.Entities
{
    public class UniversityUser : IdentityUser
    {
        public int? StudentId { get; set; }
    }
}
