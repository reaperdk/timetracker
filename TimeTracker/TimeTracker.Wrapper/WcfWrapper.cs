using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Wrapper.WcfWrapperConnection;
using TimeTracker.ClassService;

namespace TimeTracker.Wrapper
{
    public class WcfWrapper : IServiceWrapper
    {
        private IWcfConnectionService _connectionService;
        private readonly Func<IWcfConnectionService> _getWcfConnectionService;

        public WcfWrapper()
        {
            _getWcfConnectionService = () => new WcfConnectionService();
        }

        public WcfWrapper(Func<IWcfConnectionService> getWcfConnectionService)
        {
            _getWcfConnectionService = getWcfConnectionService;
        }

        public void InitializeDatabase()
        {
            using (_connectionService = _getWcfConnectionService()) 
            {
                _connectionService.RemoteProxy.InitializeDatabase();
            }
        }

        public void InitializeRoles()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                _connectionService.RemoteProxy.InitializeRoles();
            }
        }

        public void InitializeCategories()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                _connectionService.RemoteProxy.InitializeCategories();
            }
        }

        public void InitializeStatuses()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                _connectionService.RemoteProxy.InitializeStatuses();
            }
        }

        public void InitializePriorities()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                _connectionService.RemoteProxy.InitializePriorities();
            }
        }

        public void InitializeTypes()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                _connectionService.RemoteProxy.InitializeTypes();
            }
        }

        public IEnumerable<Model.UserModel> GetAllUsers()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetAllUsers();
            }
        }

        public Model.UserModel GetUserById(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetUserById(id);
            }
        }

        public string GetSaltByUserName(string userName)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetSaltByUserName(userName);
            }
        }

        public void SetSalt(string userName, string salt)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                _connectionService.RemoteProxy.SetSalt(userName, salt);
            }
        }

        public bool UpdateCreatedUser(Model.UserModel user, string salt)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.UpdateCreatedUser(user, salt);
            }
        }

        public bool UpdateUser(Model.UserModel user)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.UpdateUser(user);
            }
        }

        public IEnumerable<Model.ProjectModel> GetAllProjects()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetAllProjects();
            }
        }

        public Model.ProjectModel GetProjectById(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetProjectById(id);
            }
        }

        public bool CreateProject(Model.ProjectModel project)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.CreateProject(project);
            }
        }

        public bool UpdateProject(Model.ProjectModel project)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.UpdateProject(project);
            }
        }

        public bool DeleteProject(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.DeleteProject(id);
            }
        }

        public IEnumerable<Model.TaskModel> GetAllTasks()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetAllTasks();
            }
        }

        public Model.TaskModel GetTaskById(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetTaskById(id);
            }
        }

        public bool CreateTask(Model.TaskModel task)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.CreateTask(task);
            }
        }

        public bool UpdateTask(Model.TaskModel task)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.UpdateTask(task);
            }
        }

        public bool DeleteTask(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.DeleteTask(id);
            }
        }

        public IEnumerable<Model.SlotModel> GetAllSlots()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetAllSlots();
            }
        }

        public Model.SlotModel GetSlotById(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetSlotById(id);
            }
        }

        public bool CreateSlot(Model.SlotModel slot)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.CreateSlot(slot);
            }
        }

        public bool UpdateSlot(Model.SlotModel slot)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.UpdateSlot(slot);
            }
        }

        public bool DeleteSlot(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.DeleteSlot(id);
            }
        }

        public IEnumerable<Model.RoleModel> GetAllRoles()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetAllRoles();
            }
        }

        public Model.RoleModel GetRoleById(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetRoleById(id);
            }
        }

        public IEnumerable<Model.CategoryModel> GetAllCategories()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetAllCategories();
            }
        }

        public Model.CategoryModel GetCategoryById(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetCategoryById(id);
            }
        }

        public IEnumerable<Model.StatusModel> GetAllStatuses()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetAllStatuses();
            }
        }

        public Model.StatusModel GetStatusById(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetStatusById(id);
            }
        }

        public IEnumerable<Model.PriorityModel> GetAllPriorities()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetAllPriorities();
            }
        }

        public Model.PriorityModel GetPriorityById(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetPriorityById(id);
            }
        }

        public IEnumerable<Model.TypeModel> GetAllTypes()
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetAllTypes();
            }
        }

        public Model.TypeModel GetTypeById(int id)
        {
            using (_connectionService = _getWcfConnectionService())
            {
                return _connectionService.RemoteProxy.GetTypeById(id);
            }
        }
    }
}
