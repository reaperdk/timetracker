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
        IEnumerable<UserProfile> GetAll();
        UserProfile GetById(int id);
        void Add(UserProfile user, int roleId);
        void Update(UserProfile user);
        void Remove(int id);
    }
}
