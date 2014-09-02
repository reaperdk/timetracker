using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.ClassService;
using TimeTracker.Model;

namespace TimeTracker.Wrapper.ClassWrappers
{
    public class UsersClassWrapper : IUsersWrapper
    {
        private readonly IUsersService _usersService;

        public UsersClassWrapper()
        {
            _usersService = new UsersService();
        }
        public UsersClassWrapper(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _usersService.GetAllUsers();
        }

        public UserModel GetById(int id)
        {
            return _usersService.GetById(id);
        }

        public void Add(UserModel user)
        {
            _usersService.Add(user);
        }

        public void Update(UserModel user)
        {
            _usersService.Update(user);
        }
        
        public void Remove(int id)
        {
            _usersService.Remove(id);
        }
    }
}
