using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.Wrapper
{
    /// <summary>
    /// There will be methods used in Web project like "CreateProject" etc. This interface gives possibility to make selected CRUD actions
    /// </summary>
    public interface IDatabaseWrapper
    {
        /// <summary>
        /// Create a new project in database.
        /// </summary>
        /// <param name="projectName">Project name</param>
        /// <returns>True if project is succesfully created, otherwise false</returns>
        /// <exception cref="ArgumentException">Thrown when project name is null or empty</exception>
        bool CreateProject(string projectName);

        /// <summary>
        /// Creates task and add to the project.
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <param name="task">Task which has to be added to the project. Must have at least name</param>
        /// <returns>True if task is succesfully added to project, otherwise false</returns>
        /// <exception cref="ArgumentException">Thrown when projectId is equal or less than zero or task name is null or empty</exception>
        bool AddTaskToProject(int projectId, TaskModel task);

        /// <summary>
        /// Creates project's category
        /// </summary>
        /// <param name="categoryName">Category name</param>
        /// <returns>True if category is created, otherwise false/returns>
        /// <exception cref="ArgumentException">Thrown when category name is null or empty</exception>
        bool CreateCategory(string categoryName);

        /// <summary>
        /// Creates status
        /// </summary>
        /// <param name="statusName">Status name</param>
        /// <returns>True if status is created, otherwise false/returns>
        /// <exception cref="ArgumentException">Thrown when status name is null or empty</exception>
        bool CreateStatus(string statusName);

        /// <summary>
        /// Creates type
        /// </summary>
        /// <param name="typeName">Type name</param>
        /// <returns>True if type is created, otherwise false/returns>
        /// <exception cref="ArgumentException">Thrown when type name is null or empty</exception>
        bool CreateType(string typeName);

        /// <summary>
        /// Creates user
        /// </summary>
        /// <param name="userLogin">User login</param>
        /// <returns>True if user is created, false if user exist/returns>
        /// <exception cref="ArgumentException">Thrown when user login is null or empty</exception>
        bool CreateUser(string userLogin);


    }
}
    