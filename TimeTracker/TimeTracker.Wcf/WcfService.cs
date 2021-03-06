﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TimeTracker.Model;
using TimeTracker.WcfContract;
using TimeTracker.ClassService;

namespace TimeTracker.Wcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfService : IWcfContract
    {
        //These service classes will be used to connect to database and do necessary things
        private readonly IUsersService _usersService;
        private readonly IProjectsService _projectsService;
        private readonly ITasksService _tasksService;
        private readonly IMembershipsService _membershipsService;
        private readonly IUserMembershipsService _userMembershipsService;
        private readonly IRolesService _rolesService;
        private readonly IUsersRolesService _usersRolesService;
        private readonly ICategoriesService _categoriesService;
        private readonly IStatusesService _statusesService;
        private readonly IPrioritiesService _prioritiesService;
        private readonly ITypesService _typesService;
        private readonly ISlotsService _slotsService;

        public WcfService()
        {
            _usersService = new UsersService();
            _projectsService = new ProjectsService();
            _tasksService = new TasksService();
            _membershipsService = new MembershipsService();
            _userMembershipsService = new UserMembershipsService();
            _rolesService = new RolesService();
            _usersRolesService = new UsersRolesService();
            _categoriesService = new CategoriesService();
            _statusesService = new StatusesService();
            _prioritiesService = new PrioritiesService();
            _typesService = new TypesService();
            _slotsService = new SlotsService();
        }

        public WcfService(
            IUsersService usersService, 
            IProjectsService projectsService, 
            ITasksService tasksService, 
            IRolesService rolesService,
            ICategoriesService categoriesService, 
            IStatusesService statusesService, 
            IPrioritiesService prioritiesService, 
            ITypesService typesService,
            ISlotsService slotsService)
        {
            _usersService = usersService;
            _projectsService = projectsService;
            _tasksService = tasksService;
            _rolesService = rolesService;
            _categoriesService = categoriesService;
            _statusesService = statusesService;
            _prioritiesService = prioritiesService;
            _typesService = typesService;
            _slotsService = slotsService;
        }

        public void InitializeDatabase()
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

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _usersService.GetAll();
        }

        public UserModel GetUserById(int id)
        {
            return _usersService.GetById(id);
        }

        public void SetSalt(string userName, string salt)
        {
            _membershipsService.SetSalt(_usersService.GetByUserName(userName).UserId, salt);
        }

        public string GetSaltByUserName(string userName)
        {
            return _userMembershipsService.GetSaltByUserName(userName);
        }

        public bool UpdateCreatedUser(UserModel user, string salt)
        {
            user.UserId = _usersService.GetByUserName(user.UserName).UserId;
            _usersService.UpdateCreated(user);
            _membershipsService.SetSalt(user.UserId, salt);
            //TODO: return user add result // no wlasnie, zrob to Andrzej :)
            return true;
        }

        public bool UpdateUser(UserModel user)
        {
            _usersService.Update(user);
            //TODO: return user update result // no wlasnie, zrob to Andrzej ;)
            return true;
        }

        public IEnumerable<ProjectModel> GetAllProjects()
        {
            return _projectsService.GetAll();
        }

        public ProjectModel GetProjectById(int id)
        {
            return _projectsService.GetById(id);
        }

        public bool CreateProject(ProjectModel project)
        {
            _projectsService.Create(project);
            //TODO: return  result
            return true;
        }

        public bool UpdateProject(ProjectModel project)
        {
            _projectsService.Update(project);
            //TODO: return  result
            return true;
        }

        public bool DeleteProject(int id)
        {
            _projectsService.Delete(id);
            //TODO: return  result
            return true;
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _tasksService.GetAll();
        }

        public TaskModel GetTaskById(int id)
        {
            return _tasksService.GetById(id);
        }

        public bool CreateTask(TaskModel task)
        {
            _tasksService.Create(task);
            //TODO: return  result
            return true;
        }

        public bool UpdateTask(TaskModel task)
        {
            _tasksService.Update(task);
            //TODO: return  result
            return true;
        }

        public bool DeleteTask(int id)
        {
            _tasksService.Delete(id);
            //TODO: return  result
            return true;
        }

        public IEnumerable<SlotModel> GetAllSlots()
        {
            return _slotsService.GetAll();
        }

        public SlotModel GetSlotById(int id)
        {
            return _slotsService.GetById(id);
        }

        public bool CreateSlot(SlotModel slot)
        {
            _slotsService.Create(slot);
            //TODO: return  result
            return true;
        }

        public bool UpdateSlot(SlotModel slot)
        {
            _slotsService.Update(slot);
            //TODO: return  result
            return true;
        }

        public bool DeleteSlot(int id)
        {
            _slotsService.Delete(id);
            //TODO: return  result
            return true;
        }

        public IEnumerable<RoleModel> GetAllRoles()
        {
            return _rolesService.GetAll();
        }

        public RoleModel GetRoleById(int id)
        {
            return _rolesService.GetById(id);
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
