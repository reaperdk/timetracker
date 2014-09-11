using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.ClassService
{
    public interface IUserMembershipsService
    {
        string GetSaltByUserName(string userName);
    }
}
