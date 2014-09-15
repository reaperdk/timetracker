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
        private IEntitiesRepository<RoleModel> _repository;
        private readonly Func<IEntitiesRepository<RoleModel>> _getRepository;

        public RolesService()
        {
            _getRepository = () => new EntitiesRepository<RoleModel>();
        }
        public RolesService(Func<IEntitiesRepository<RoleModel>> getRepository)
        {
            _getRepository = getRepository;
        }

        public void InitializeRoles()
        {
            using (_repository = _getRepository())
            {
                if (!_repository.Get().Any())
                {
                    _repository.Insert(new RoleModel { RoleName = "admin" });
                    _repository.Insert(new RoleModel { RoleName = "user" });
                    _repository.Save();
                }
            }
        }

        public IEnumerable<RoleModel> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get().ToArray();
            }
        }

        public RoleModel GetById(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(id);
            }
        }
    }
}
