using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.ClassService;
using TimeTracker.Model;

namespace TimeTracker.Wrapper
{
    public class ClassWrapper : IWrapper
    {
        private readonly IUsersService _usersService;
        private readonly IRolesService _rolesService;

        public ClassWrapper()
        {
            _usersService = new UsersService();
            _rolesService = new RolesService();
        }
        public ClassWrapper(IUsersService usersService, IRolesService rolesService)
        {
            _usersService = usersService;
            _rolesService = rolesService;
        }

        public IEnumerable<UserProfile> GetAllUsers()
        {
            return _usersService.GetAll();
        }

        public UserProfile GetUserById(int id)
        {
            return _usersService.GetById(id);
        }

        public void CreateUser(UserProfile user)
        {
            _usersService.Add(user);
        }

        public void UpdateUser(UserProfile user)
        {
            _usersService.Update(user);
        }
        
        public void RemoveUser(int id)
        {
            _usersService.Remove(id);
        }

        public void InitializeRoles()
        {
            _rolesService.InitializeRoles();
        }

        public IEnumerable<webpages_Roles> GetAllRoles()
        {
            return _rolesService.GetAll();
        }

        public webpages_Roles GetRoleById(int id)
        {
            return _rolesService.Get(id);
        }
    }
}
