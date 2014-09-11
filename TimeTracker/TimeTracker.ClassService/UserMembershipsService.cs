using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;
using TimeTracker.Repository;

namespace TimeTracker.ClassService
{
    public class UserMembershipsService : IUserMembershipsService
    {
        private IEntitiesRepository<UserModel> _usersRepository;
        private readonly Func<IEntitiesRepository<UserModel>> _getUsersRepository;

        private IEntitiesRepository<MembershipModel> _membershipsRepository;
        private readonly Func<IEntitiesRepository<MembershipModel>> _getMembershipsRepository;

        public UserMembershipsService()
        {
            _getUsersRepository = () => new EntitiesRepository<UserModel>();
            _getMembershipsRepository = () => new EntitiesRepository<MembershipModel>();
        }
        public UserMembershipsService(
            Func<IEntitiesRepository<UserModel>> getUsersRepository,
            Func<IEntitiesRepository<MembershipModel>> getMembershipsRepository)
        {
            _getUsersRepository = getUsersRepository;
            _getMembershipsRepository = getMembershipsRepository;
        }

        public string GetSaltByUserName(string userName)
        {
            using (_usersRepository = _getUsersRepository())
            {
                using (_membershipsRepository = _getMembershipsRepository())
                {
                    return _membershipsRepository.Get(
                        _usersRepository.Get(
                            item => item.UserName.Equals(userName)
                        ).First().UserId
                    ).PasswordSalt;
                }
            }
        }
    }
}
