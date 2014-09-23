using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Wrapper.WcfWrapperConnection;
using TimeTracker.ClassService;

namespace TimeTracker.Wrapper
{
    public class WcfWrapper : IServiceWrapper, IDisposable
    {
        private readonly IWcfConnectionService _connectionService;
        private bool _disposed;

        public WcfWrapper()
        {
            _connectionService = new WcfConnectionService();
            _connectionService.SetConnection();
            _disposed = false;
        }
        public WcfWrapper(IWcfConnectionService connectionService)
        {
            _connectionService = connectionService;
            _connectionService.SetConnection();
        }

        public void InitializeDatabase()
        {
            _connectionService.RemoteProxy.InitializeDatabase();
        }

        public void InitializeRoles()
        {
            _connectionService.RemoteProxy.InitializeRoles();
        }

        public void InitializeCategories()
        {
            _connectionService.RemoteProxy.InitializeCategories();
        }

        public void InitializeStatuses()
        {
            _connectionService.RemoteProxy.InitializeStatuses();
        }

        public void InitializePriorities()
        {
            _connectionService.RemoteProxy.InitializePriorities();
        }

        public void InitializeTypes()
        {
            _connectionService.RemoteProxy.InitializeTypes();
        }

        public IEnumerable<Model.UserModel> GetAllUsers()
        {
            return _connectionService.RemoteProxy.GetAllUsers();
        }

        public Model.UserModel GetUserById(int id)
        {
            return _connectionService.RemoteProxy.GetUserById(id);
        }

        public string GetSaltByUserName(string userName)
        {
            return _connectionService.RemoteProxy.GetSaltByUserName(userName);
        }

        public void SetSalt(string userName, string salt)
        {
            _connectionService.RemoteProxy.SetSalt(userName, salt);
        }

        public bool UpdateCreatedUser(Model.UserModel user, string salt)
        {
            return _connectionService.RemoteProxy.UpdateCreatedUser(user, salt);
        }

        public bool UpdateUser(Model.UserModel user)
        {
            return _connectionService.RemoteProxy.UpdateUser(user);
        }

        public IEnumerable<Model.ProjectModel> GetAllProjects()
        {
            return _connectionService.RemoteProxy.GetAllProjects();
        }

        public Model.ProjectModel GetProjectById(int id)
        {
            return _connectionService.RemoteProxy.GetProjectById(id);
        }

        public bool CreateProject(Model.ProjectModel project)
        {
            return _connectionService.RemoteProxy.CreateProject(project);
        }

        public bool UpdateProject(Model.ProjectModel project)
        {
            return _connectionService.RemoteProxy.UpdateProject(project);
        }

        public bool DeleteProject(int id)
        {
            return _connectionService.RemoteProxy.DeleteProject(id);
        }

        public IEnumerable<Model.TaskModel> GetAllTasks()
        {
            return _connectionService.RemoteProxy.GetAllTasks();
        }

        public Model.TaskModel GetTaskById(int id)
        {
            return _connectionService.RemoteProxy.GetTaskById(id);
        }

        public bool CreateTask(Model.TaskModel task)
        {
            return _connectionService.RemoteProxy.CreateTask(task);
        }

        public bool UpdateTask(Model.TaskModel task)
        {
            return _connectionService.RemoteProxy.UpdateTask(task);
        }

        public bool DeleteTask(int id)
        {
            return _connectionService.RemoteProxy.DeleteTask(id);
        }

        public IEnumerable<Model.SlotModel> GetAllSlots()
        {
            return _connectionService.RemoteProxy.GetAllSlots();
        }

        public Model.SlotModel GetSlotById(int id)
        {
            return _connectionService.RemoteProxy.GetSlotById(id);
        }

        public bool CreateSlot(Model.SlotModel slot)
        {
            return _connectionService.RemoteProxy.CreateSlot(slot);
        }

        public bool UpdateSlot(Model.SlotModel slot)
        {
            return _connectionService.RemoteProxy.UpdateSlot(slot);
        }

        public bool DeleteSlot(int id)
        {
            return _connectionService.RemoteProxy.DeleteSlot(id);
        }

        public IEnumerable<Model.RoleModel> GetAllRoles()
        {
            return _connectionService.RemoteProxy.GetAllRoles();
        }

        public Model.RoleModel GetRoleById(int id)
        {
            return _connectionService.RemoteProxy.GetRoleById(id);
        }

        public IEnumerable<Model.CategoryModel> GetAllCategories()
        {
            return _connectionService.RemoteProxy.GetAllCategories();
        }

        public Model.CategoryModel GetCategoryById(int id)
        {
            return _connectionService.RemoteProxy.GetCategoryById(id);
        }

        public IEnumerable<Model.StatusModel> GetAllStatuses()
        {
            return _connectionService.RemoteProxy.GetAllStatuses();
        }

        public Model.StatusModel GetStatusById(int id)
        {
            return _connectionService.RemoteProxy.GetStatusById(id);
        }

        public IEnumerable<Model.PriorityModel> GetAllPriorities()
        {
            return _connectionService.RemoteProxy.GetAllPriorities();
        }

        public Model.PriorityModel GetPriorityById(int id)
        {
            return _connectionService.RemoteProxy.GetPriorityById(id);
        }

        public IEnumerable<Model.TypeModel> GetAllTypes()
        {
            return _connectionService.RemoteProxy.GetAllTypes();
        }

        public Model.TypeModel GetTypeById(int id)
        {
            return _connectionService.RemoteProxy.GetTypeById(id);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _connectionService.CloseConnection();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
