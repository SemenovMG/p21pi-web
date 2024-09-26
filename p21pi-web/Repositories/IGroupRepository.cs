using p21pi_web.Entities;
using p21pi_web.Models.Requests.Groups;

namespace p21pi_web.Repositories
{
    public interface IGroupRepository
    {
        Group AddGroup(AddGroupRequest request);
        List<Group> GetAllGroups();
        Group? GetById(int id);
    }
}