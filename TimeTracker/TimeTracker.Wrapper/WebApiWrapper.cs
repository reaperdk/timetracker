using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TimeTracker.Model;

namespace TimeTracker.Wrapper
{
    public class WebApiWrapper : IServiceWrapper
    {
        private readonly string _webApiUrl = "http://localhost:17046/api/";
        private HttpClient _client;

        public void InitializeDatabase()
        {
            throw new NotImplementedException();
        }

        public void InitializeRoles()
        {
            throw new NotImplementedException();
        }

        public void InitializeCategories()
        {
            throw new NotImplementedException();
        }

        public void InitializeStatuses()
        {
            throw new NotImplementedException();
        }

        public void InitializePriorities()
        {
            throw new NotImplementedException();
        }

        public void InitializeTypes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return RequestGet<UserModel[]>("Users/");
        }

        public UserModel GetUserById(int id)
        {
            return RequestGet<UserModel>("Users/" + id);
        }

        public string GetSaltByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public void SetSalt(string userName, string salt)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCreatedUser(UserModel user, string salt)
        {
            user.UserId = RequestGet<UserModel>("Users/ByUserName/" + user.UserName).UserId;
            RequestPut("Users/Created/", user);
            RequestPut("Memberships/Salt/" + user.UserId, salt);
            // o tak, zrob to Andrzej!
            return true;
        }

        public bool UpdateUser(UserModel user)
        {
            RequestPut("Users/", user);
            return true;
        }

        public IEnumerable<ProjectModel> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public ProjectModel GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateProject(ProjectModel project)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProject(ProjectModel project)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public TaskModel GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateTask(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTask(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SlotModel> GetAllSlots()
        {
            throw new NotImplementedException();
        }

        public SlotModel GetSlotById(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateSlot(SlotModel slot)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSlot(SlotModel slot)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSlot(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleModel> GetAllRoles()
        {
            return RequestGet<RoleModel[]>("Roles/");
        }

        public RoleModel GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public CategoryModel GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatusModel> GetAllStatuses()
        {
            throw new NotImplementedException();
        }

        public StatusModel GetStatusById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriorityModel> GetAllPriorities()
        {
            throw new NotImplementedException();
        }

        public PriorityModel GetPriorityById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TypeModel> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public TypeModel GetTypeById(int id)
        {
            throw new NotImplementedException();
        }

        private T RequestGet<T>(string url)
        {
            using (_client = new HttpClient())
            {
                _client.BaseAddress = new Uri(_webApiUrl);
                HttpResponseMessage response = _client.GetAsync(url).Result;
                return response.Content.ReadAsAsync<T>().Result;
            }
        }

        private HttpResponseMessage RequestPost<T>(string url, T item)
        {
            using (_client = new HttpClient())
            {
                _client.BaseAddress = new Uri(_webApiUrl);
                HttpResponseMessage response = _client.PostAsJsonAsync(url, item).Result;
                return response;
            }
        }

        private HttpResponseMessage RequestPut<T>(string url, T item)
        {
            using (_client = new HttpClient())
            {
                _client.BaseAddress = new Uri(_webApiUrl);
                HttpResponseMessage response = _client.PutAsJsonAsync(url, item).Result;
                return response;
            }
        }

        private HttpResponseMessage RequestDelete<T>(string url)
        {
            using (_client = new HttpClient())
            {
                _client.BaseAddress = new Uri(_webApiUrl);
                HttpResponseMessage response = _client.DeleteAsync(url).Result;
                return response;
            }
        }
    }
}
