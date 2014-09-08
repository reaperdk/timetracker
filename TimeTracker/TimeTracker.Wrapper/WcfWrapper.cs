using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Wrapper.WcfWrapperConnection;

namespace TimeTracker.Wrapper
{
    public class WcfWrapper //: IServiceWrapper
    {
        private readonly IWcfConnectionService _connectionService;

        public WcfWrapper()
        {
            _connectionService = new WcfConnectionService();
        }
        public WcfWrapper(IWcfConnectionService connectionService)
        {
            
        }
        public IEnumerable<Model.UserProfile> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Model.UserProfile GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(Model.UserProfile user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Model.UserProfile user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public void InitializeRoles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.RoleModel> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Model.RoleModel GetRoleById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
