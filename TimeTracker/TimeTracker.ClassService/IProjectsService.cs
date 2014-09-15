using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.ClassService
{
    public interface IProjectsService
    {
        IEnumerable<ProjectModel> GetAll();
        ProjectModel GetById(int id);
        ProjectModel GetProjectByProjectName(string projectName);
        void Create(ProjectModel project);
        void Update(ProjectModel project);
        void Delete(int id);
    }
}
