using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;
using TimeTracker.Repository;

namespace TimeTracker.ClassService
{
    public class UsersService : IUsersService
    {
        private IEntitiesRepository<UserProfile> _repository;
        private readonly Func<IEntitiesRepository<UserProfile>> _getRepository;

        public UsersService()
        {
            _getRepository = () => new EntitiesRepository<UserProfile>();
        }
        public UsersService(Func<IEntitiesRepository<UserProfile>> getRepository)
        {
            _getRepository = getRepository;
        }

        public IEnumerable<UserProfile> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(item => item.webpages_Roles).ToArray();
            }
        }

        public UserProfile GetById(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(item => item.UserId == id, item => item.webpages_Roles).First();
            }
        }

        public void Add(UserProfile user)
        {
            using (_repository = _getRepository())
            {
                int roleId = user.webpages_Roles.First().RoleId;
                user.webpages_Roles =
                    new []
                    {
                        _repository.GetAnother<Model.webpages_Roles>(item => item.RoleId == roleId).First()
                    };
                _repository.Insert(user);
                _repository.Save();
            }
        }

        public void Update(UserProfile user)
        {
            using (_repository = _getRepository())
            {
                UserProfile toUpdate = _repository.Get(item => item.UserId == user.UserId, item => item.webpages_Roles).First();
                int roleId = user.webpages_Roles.First().RoleId;
                toUpdate.webpages_Roles.Clear();
                toUpdate.webpages_Roles.Add(
                    _repository.GetAnother<Model.webpages_Roles>(item => item.RoleId == roleId).First()
                );
                _repository.Update(toUpdate);
                _repository.Save();
            }
        }

        public void Remove(int id)
        {
            using (_repository = _getRepository())
            {
                _repository.Remove(id);
                _repository.Save();
            }
        }
    }
}
