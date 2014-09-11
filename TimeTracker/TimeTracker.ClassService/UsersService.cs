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

        public IEnumerable<UserModel> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(item => item.webpages_Roles).ToArray();
            }
        }

        public UserModel GetById(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(item => item.UserId == id, item => item.webpages_Roles).First();
            }
        }

        public UserModel GetUserByUserName(string userName)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(item => item.UserName.Equals(userName), item => item.webpages_Roles).First();
            }
        }

        public void UpdateCreated(UserModel user)
        {
            using (_repository = _getRepository())
            {
                UserModel toUpdate = _repository.Get(item => item.UserName.Equals(user.UserName)).First();
                int roleId = user.webpages_Roles.First().RoleId;
                toUpdate.webpages_Roles = new []
                    {
                        _repository.GetAnother<Model.RoleModel>(item => item.RoleId == roleId).First()
                    };
                _repository.Update(toUpdate);
                _repository.Save();
            }
        }

        public void Update(UserModel user)
        {
            using (_repository = _getRepository())
            {
                UserModel toUpdate = _repository.Get(item => item.UserId == user.UserId, item => item.webpages_Roles).First();
                toUpdate.UserName = user.UserName;
                int roleId = user.webpages_Roles.First().RoleId;
                toUpdate.webpages_Roles.Clear();
                toUpdate.webpages_Roles.Add(
                    _repository.GetAnother<Model.RoleModel>(item => item.RoleId == roleId).First()
                );
                _repository.Update(toUpdate);
                _repository.Save();
            }
        }
    }
}
