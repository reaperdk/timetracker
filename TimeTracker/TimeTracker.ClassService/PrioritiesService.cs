using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;
using TimeTracker.Repository;

namespace TimeTracker.ClassService
{
    public class PrioritiesService : IPrioritiesService
    {
        private IEntitiesRepository<PriorityModel> _repository;
        private readonly Func<IEntitiesRepository<PriorityModel>> _getRepository;

        public PrioritiesService()
        {
            _getRepository = () => new EntitiesRepository<PriorityModel>();
        }
        public PrioritiesService(Func<IEntitiesRepository<PriorityModel>> getRepository)
        {
            _getRepository = getRepository;
        }

        public void InitializePriorities()
        {
            using (_repository = _getRepository())
            {
                if (!_repository.Get().Any())
                {
                    _repository.Insert(new PriorityModel { Name = "Low" });
                    _repository.Insert(new PriorityModel { Name = "Medium" });
                    _repository.Insert(new PriorityModel { Name = "High" });
                    _repository.Insert(new PriorityModel { Name = "Very high" });
                    _repository.Save();
                }
            }
        }

        public IEnumerable<PriorityModel> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get().ToArray();
            }
        }

        public PriorityModel Get(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(id);
            }
        }
    }
}
