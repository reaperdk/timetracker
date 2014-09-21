using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Repository;
using TimeTracker.Model;

namespace TimeTracker.ClassService
{
    public class TasksService : ITasksService
    {
        private IEntitiesRepository<TaskModel> _repository;
        private readonly Func<IEntitiesRepository<TaskModel>> _getRepository;

        public TasksService()
        {
            _getRepository = () => new EntitiesRepository<TaskModel>();
        }
        public TasksService(Func<IEntitiesRepository<TaskModel>> getRepository)
        {
            _getRepository = getRepository;
        }

        public IEnumerable<TaskModel> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get().ToArray();
            }
        }

        public TaskModel GetById(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(id);
            }
        }

        public TaskModel GetTaskByTaskName(string taskName)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(item => item.Name.Equals(taskName)).First();
            }
        }

        public void Create(TaskModel task)
        {
            using (_repository = _getRepository())
            {
                _repository.Insert(task);
                _repository.Save();
            }
        }

        public void Update(TaskModel task)
        {
            using (_repository = _getRepository())
            {
                TaskModel toUpdate = _repository.Get(item => item.Id == task.Id).First();
                toUpdate.Name = task.Name;
                toUpdate.Description = task.Description;
                toUpdate.TimeEstimate = task.TimeEstimate;
                toUpdate.StartDate = task.StartDate;
                toUpdate.FinishDate = task.FinishDate;
                toUpdate.Filepath = task.Filepath;
                toUpdate.Version = task.Version;
                toUpdate.ProjectId = task.ProjectId;
                toUpdate.AssignedPersonId = task.AssignedPersonId;
                toUpdate.AssigningPersonId = task.AssigningPersonId;
                toUpdate.CategoryId = task.CategoryId;
                toUpdate.StatusId = task.StatusId;
                toUpdate.PriorityId = task.PriorityId;
                toUpdate.TypeId = task.TypeId;
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
