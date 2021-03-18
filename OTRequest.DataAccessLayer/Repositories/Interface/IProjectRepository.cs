namespace OTRequest.DataAccessLayer.Repositories.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OTRequest.Core.Models;

    public interface IProjectRepository
    {
        /// <summary>
        /// Create project.
        /// </summary>
        /// <param name="project">New Project.</param>
        void CreateProject(Project project);

        /// <summary>
        /// Update project.
        /// </summary>
        /// <param name="project">Project.</param>
        void UpdateProject(Project project);

        /// <summary>
        /// Update project.
        /// </summary>
        /// <param name="project"></param>
        void DeleteProject(Project project);

        /// <summary>
        /// Delete project by id.
        /// </summary>
        /// <param name="project">Project id.</param>
        void DeleteProject(int projectID);

        /// <summary>
        /// Find project by id.
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        Project FindProjectName(string projectName);

        /// <summary>
        /// Find project by date.
        /// </summary>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        IList<Project> FindProjectsDate(DateTime dateStart, DateTime dateEnd);

        /// <summary>
        /// List User join project by project id.
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        IList<UserProjectMap> listUser(int projectID);


    }
}
