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
        private IEntitiesRepository<UserProfile> _usersRepository;
        private readonly Func<IEntitiesRepository<UserProfile>> _getUsersRepository;

        private IEntitiesRepository<webpages_Roles> _rolesRepository;
        private readonly Func<IEntitiesRepository<webpages_Roles>> _getRolesRepository;

        public UsersRolesService()
        {
            _getUsersRepository = () => new EntitiesRepository<UserProfile>();
            _getRolesRepository = () => new EntitiesRepository<webpages_Roles>();
        }
        public UsersRolesService(Func<IEntitiesRepository<webpages_Roles>> getRolesRepository, Func<IEntitiesRepository<UserProfile>> getUsersRepository)
        {
            _getUsersRepository = getUsersRepository;
            _getRolesRepository = getRolesRepository;
        }
    }
}
