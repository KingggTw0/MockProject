
namespace OTRequest.DataAccessLayer.Repositories
{
    using OTRequest.Core.Models;
    using OTRequest.DataAccessLayer.Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class ProjectRespository.
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {
        private readonly OTRequestContext otContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRepository"/> class.
        /// </summary>
        public ProjectRepository()
        {
            this.otContext = new OTRequestContext();
        }

        /// <summary>
        /// Create project.
        /// </summary>
        /// <param name="project"></param>
        public void CreateProject(Project project)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete project by project id.
        /// </summary>
        /// <param name="projectID"></param>
        public void DeleteProject(int projectID)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            this.otContext.Dispose();
        }

        public IList<UserProjectMap> listUser(int projectID)
        {
            throw new NotImplementedException();
        }

        public Project FindProjectName(string projectName)
        {
            return this.otContext.Projects.FirstOrDefault(p => p.ProjectName.ToLower() == projectName.ToLower());
        }


        public IList<Project> FindProjectsDate(DateTime dateStart, DateTime dateEnd)
        {
            return this.otContext.Projects.Where(p => p.DateStart >= dateStart && p.DateEnd <= ((dateEnd == DateTime.Now)? DateTime.Now : dateEnd)).ToList();
        }
    }
}
