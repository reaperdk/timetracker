using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.ClassService
{
    public interface IUsersService
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel GetUserByUserName(string userName);
        void UpdateCreated(UserModel user);
        void Update(UserModel user);
    }
}
