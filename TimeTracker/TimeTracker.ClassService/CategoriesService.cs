using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;
using TimeTracker.Repository;

namespace TimeTracker.ClassService
{
    public class CategoriesService : ICategoriesService
    {
        private IEntitiesRepository<CategoryModel> _repository;
        private readonly Func<IEntitiesRepository<CategoryModel>> _getRepository;

        public CategoriesService()
        {
            _getRepository = () => new EntitiesRepository<CategoryModel>();
        }
        public CategoriesService(Func<IEntitiesRepository<CategoryModel>> getRepository)
        {
            _getRepository = getRepository;
        }

        public void InitializeCategories()
        {
            using (_repository = _getRepository())
            {
                if (!_repository.Get().Any())
                {
                    _repository.Insert(new CategoryModel { Name = "Easy" });
                    _repository.Insert(new CategoryModel { Name = "Difficult" });
                    _repository.Save();
                }
            }
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get().ToArray();
            }
        }

        public CategoryModel Get(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(id);
            }
        }
    }
}
