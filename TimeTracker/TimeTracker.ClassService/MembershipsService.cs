using System;
using TimeTracker.Model;
using TimeTracker.Repository;

namespace TimeTracker.ClassService
{
    public class MembershipsService : IMembershipsService
    {
        private IEntitiesRepository<MembershipModel> _repository;
        private readonly Func<IEntitiesRepository<MembershipModel>> _getRepository;

        public MembershipsService()
        {
            _getRepository = () => new EntitiesRepository<MembershipModel>();
        }
        public MembershipsService(Func<IEntitiesRepository<MembershipModel>> getRepository)
        {
            _getRepository = getRepository;
        }

        public void SetSalt(int userId, string salt)
        {
            using (_repository = _getRepository())
            {
                MembershipModel membership = _repository.Get(userId);
                membership.PasswordSalt = salt;
                _repository.Update(membership);
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
