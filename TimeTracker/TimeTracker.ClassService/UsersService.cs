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
        private IEntitiesRepository<UserModel> _repository;
        private readonly Func<IEntitiesRepository<UserModel>> _getRepository;

        public UsersService()
        {
            _getRepository = () => new EntitiesRepository<UserModel>();
        }
        public UsersService(Func<IEntitiesRepository<UserModel>> getRepository)
        {
            _getRepository = getRepository;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get().ToArray();
            }
        }

        public UserModel GetById(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(id);
            }
        }

        public void Add(UserModel user)
        {
            using (_repository = _getRepository())
            {
                _repository.Insert(user);
                _repository.Save();
            }
        }

        public void Update(UserModel user)
        {
            using (_repository = _getRepository())
            {
                _repository.Update(user);
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
