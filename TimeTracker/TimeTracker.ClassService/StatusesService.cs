using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;
using TimeTracker.Repository;

namespace TimeTracker.ClassService
{
    public class StatusesService : IStatusesService
    {
        private IEntitiesRepository<StatusModel> _repository;
        private readonly Func<IEntitiesRepository<StatusModel>> _getRepository;

        public StatusesService()
        {
            _getRepository = () => new EntitiesRepository<StatusModel>();
        }
        public StatusesService(Func<IEntitiesRepository<StatusModel>> getRepository)
        {
            _getRepository = getRepository;
        }

        public void InitializeStatuses()
        {
            using (_repository = _getRepository())
            {
                if (!_repository.Get().Any())
                {
                    _repository.Insert(new StatusModel { Name = "Active" });
                    _repository.Insert(new StatusModel { Name = "Completed" });
                    _repository.Insert(new StatusModel { Name = "Suspended" });
                    _repository.Insert(new StatusModel { Name = "New" });
                    _repository.Insert(new StatusModel { Name = "Reactivated" });
                    _repository.Save();
                }
            }
        }

        public IEnumerable<StatusModel> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get().ToArray();
            }
        }

        public StatusModel Get(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(id);
            }
        }
    }
}
