using p21pi_web.Data;
using p21pi_web.Entities;
using p21pi_web.Models.Requests.Groups;

namespace p21pi_web.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly G21WebContext _db;

        public GroupRepository(G21WebContext db)
        {
            _db = db;
        }

        public List<Group> GetAllGroups()
        {
            return _db.Groups.ToList();
        }

        public Group? GetById(int id)
        {
            return _db.Groups
                .FirstOrDefault(g => g.Id == id);
        }

        public Group AddGroup(AddGroupRequest request)
        {
            var newGroup = new Group
            {
                Capacity = request.Capacity,
                Name = request.Name,
            };

            _db.Groups.Add(newGroup);
            _db.SaveChanges();

            return newGroup;
        }
    }
}
