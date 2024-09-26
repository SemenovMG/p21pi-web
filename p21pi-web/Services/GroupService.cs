using p21pi_web.Entities;
using p21pi_web.Models.Requests.Groups;
using p21pi_web.Repositories;

namespace p21pi_web.Services
{
    public class GroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;

        public GroupService(IGroupRepository groupRepository, 
            IStudentRepository studentRepository)
        {
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
        }

        public List<Group> GetAllGroups()
        {
            return _groupRepository.GetAllGroups();
        }

        public Group? GetById(int id)
        {
            var group = _groupRepository.GetById(id);
            if (group is null)
            {
                throw new Exception($"Group not found (id = {id})");
            }
            return group;
        }

        public Group AddGroup(AddGroupRequest request)
        {
            if (!string.IsNullOrEmpty(request.Name))
            {
                throw new Exception("Not allowed Name");
            }

            if (request.Capacity < 1 || request.Capacity > 30)
            {
                throw new Exception("Capacity should be > 0 and < 31");
            }

            var newGroup = _groupRepository.AddGroup(request);

            return newGroup;
        }

        public /*GroupDetails*/ void AddStudent(int groupId, int studentId)
        {
            var student = _studentRepository.GetByIdIncludeGroup(groupId);

            if (student is null)
            {
                throw new Exception("Student not found");
            }

            //check if exists
            var currentGroup = student.Group;

            //if 

            //currentGroup.Capacity -= 1;

            // get student with group

        }
    }
}
