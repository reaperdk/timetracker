using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.ClassService;
using TimeTracker.Model;

namespace TimeTracker.Wrapper
{
    public class ClassWrapper : IServiceWrapper
    {
        private readonly IUsersService _usersService;
        private readonly IRolesService _rolesService;
        private readonly IUsersRolesService _usersRolesService;
        private readonly ICategoriesService _categoriesService;
        private readonly IStatusesService _statusesService;
        private readonly IPrioritiesService _prioritiesService;
        private readonly ITypesService _typesService;

        public ClassWrapper()
        {
            _usersService = new ClassService.UsersService();
            _rolesService = new ClassService.RolesService();
            _usersRolesService = new ClassService.UsersRolesService();
            _categoriesService = new ClassService.CategoriesService();
            _statusesService = new ClassService.StatusesService();
            _prioritiesService = new ClassService.PrioritiesService();
            _typesService = new ClassService.TypesService();
        }
        public ClassWrapper(IUsersService usersService, IRolesService rolesService, ICategoriesService categoriesService, IStatusesService statusesService, IPrioritiesService prioritiesService, ITypesService typesService)
        {
            _usersService = usersService;
            _rolesService = rolesService;
            _categoriesService = categoriesService;
            _statusesService = statusesService;
            _prioritiesService = prioritiesService;
            _typesService = typesService;
        }

        public static void InitializeDatabase()
        {
            DatabaseInitializer.InitializeDatabase();
        }

        public void InitializeRoles()
        {
            _rolesService.InitializeRoles();
        }

        public void InitializeCategories()
        {
            _categoriesService.InitializeCategories();
        }

        public void InitializeStatuses()
        {
            _statusesService.InitializeStatuses();
        }

        public void InitializePriorities()
        {
            _prioritiesService.InitializePriorities();
        }

        public void InitializeTypes()
        {
            _typesService.InitializeTypes();
        }

        public IEnumerable<UserProfile> GetAllUsers()
        {
            return _usersService.GetAll();
        }

        public UserProfile GetUserById(int id)
        {
            return _usersService.GetById(id);
        }

        public void CreateUser(UserProfile user)
        {
            _usersService.Add(user);
        }

        public void UpdateUser(UserProfile user)
        {
            _usersService.Update(user);
        }
        
        public void RemoveUser(int id)
        {
            _usersService.Remove(id);
        }

        public IEnumerable<webpages_Roles> GetAllRoles()
        {
            return _rolesService.GetAll();
        }

        public webpages_Roles GetRoleById(int id)
        {
            return _rolesService.Get(id);
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            return _categoriesService.GetAll();
        }

        public CategoryModel GetCategoryById(int id)
        {
            return _categoriesService.Get(id);
        }

        public IEnumerable<StatusModel> GetAllStatuses()
        {
            return _statusesService.GetAll();
        }

        public StatusModel GetStatusById(int id)
        {
            return _statusesService.Get(id);
        }

        public IEnumerable<PriorityModel> GetAllPriorities()
        {
            return _prioritiesService.GetAll();
        }

        public PriorityModel GetPriorityById(int id)
        {
            return _prioritiesService.Get(id);
        }

        public IEnumerable<TypeModel> GetAllTypes()
        {
            return _typesService.GetAll();
        }

        public TypeModel GetTypeById(int id)
        {
            return _typesService.Get(id);
        }
    }
}
