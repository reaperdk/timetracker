using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;
using TimeTracker.Repository;

namespace TimeTracker.ClassService
{
    public class RolesService : IRolesService
    {
        private IEntitiesRepository<webpages_Roles> _repository;
        private readonly Func<IEntitiesRepository<webpages_Roles>> _getRepository;

        public RolesService()
        {
            _getRepository = () => new EntitiesRepository<webpages_Roles>();
        }
        public RolesService(Func<IEntitiesRepository<webpages_Roles>> getRepository)
        {
            _getRepository = getRepository;
        }

        public void InitializeRoles()
        {
            using (_repository = _getRepository())
            {
                if (!_repository.Get().Any())
                {
                    _repository.Insert(new webpages_Roles { RoleName = "admin" });
                    _repository.Insert(new webpages_Roles { RoleName = "user" });
                    _repository.Save();
                }
            }
        }

        public IEnumerable<webpages_Roles> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get().ToArray();
            }
        }

        public webpages_Roles Get(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(id);
            }
        }
    }
}
