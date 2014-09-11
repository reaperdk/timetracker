using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;
using TimeTracker.Repository;

namespace TimeTracker.ClassService
{
    public class UsersRolesService : IUsersRolesService
    {
        private IEntitiesRepository<UserModel> _usersRepository;
        private readonly Func<IEntitiesRepository<UserModel>> _getUsersRepository;

        private IEntitiesRepository<RoleModel> _rolesRepository;
        private readonly Func<IEntitiesRepository<RoleModel>> _getRolesRepository;

        public UsersRolesService()
        {
            _getUsersRepository = () => new EntitiesRepository<UserModel>();
            _getRolesRepository = () => new EntitiesRepository<RoleModel>();
        }
        public UsersRolesService(Func<IEntitiesRepository<UserModel>> getUsersRepository, Func<IEntitiesRepository<RoleModel>> getRolesRepository)
        {
            _getUsersRepository = getUsersRepository;
            _getRolesRepository = getRolesRepository;
        }
    }
}
