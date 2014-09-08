using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;
using TimeTracker.Repository;

namespace TimeTracker.ClassService
{
    public class TypesService : ITypesService
    {
        private IEntitiesRepository<TypeModel> _repository;
        private readonly Func<IEntitiesRepository<TypeModel>> _getRepository;

        public TypesService()
        {
            _getRepository = () => new EntitiesRepository<TypeModel>();
        }
        public TypesService(Func<IEntitiesRepository<TypeModel>> getRepository)
        {
            _getRepository = getRepository;
        }

        public void InitializeTypes()
        {
            using (_repository = _getRepository())
            {
                if (!_repository.Get().Any())
                {
                    _repository.Insert(new TypeModel { Name = "Epic" });
                    _repository.Insert(new TypeModel { Name = "Task" });
                    _repository.Insert(new TypeModel { Name = "Bug" });
                    _repository.Insert(new TypeModel { Name = "Exception" });
                    _repository.Save();
                }
            }
        }

        public IEnumerable<TypeModel> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get().ToArray();
            }
        }

        public TypeModel Get(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(id);
            }
        }
    }
}
