using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.ClassService
{
    public interface ITasksService
    {
        IEnumerable<TaskModel> GetAll();
        TaskModel GetById(int id);
        TaskModel GetTaskByTaskName(string taskName);
        void Create(TaskModel task);
        void Update(TaskModel task);
        void Delete(int id);
    }
}
