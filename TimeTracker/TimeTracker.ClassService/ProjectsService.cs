using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Repository;
using TimeTracker.Model;

namespace TimeTracker.ClassService
{
    public class ProjectsService : IProjectsService
    {
        private IEntitiesRepository<ProjectModel> _repository;
        private readonly Func<IEntitiesRepository<ProjectModel>> _getRepository;

        public ProjectsService()
        {
            _getRepository = () => new EntitiesRepository<ProjectModel>();
        }
        public ProjectsService(Func<IEntitiesRepository<ProjectModel>> getRepository)
        {
            _getRepository = getRepository;
        }

        public IEnumerable<ProjectModel> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get().ToArray();
            }
        }

        public ProjectModel GetById(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(id);
            }
        }

        public ProjectModel GetProjectByProjectName(string projectName)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(item => item.Name.Equals(projectName)).First();
            }
        }

        public void Create(ProjectModel project)
        {
            using (_repository = _getRepository())
            {
                _repository.Insert(project);
                _repository.Save();
            }
        }

        public void Update(ProjectModel project)
        {
            using (_repository = _getRepository())
            {
                ProjectModel toUpdate = _repository.Get(item => item.Id == project.Id).First();
                toUpdate.Name = project.Name;
                _repository.Update(toUpdate);
                _repository.Save();
            }
        }

        public void Delete(int id)
        {
            using (_repository = _getRepository())
            {
                _repository.Remove(id);
                _repository.Save();
            }
        }
    }
}
