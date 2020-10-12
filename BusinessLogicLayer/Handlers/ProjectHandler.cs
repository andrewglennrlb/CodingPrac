using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Handlers
{
    public class ProjectHandler : IProjectHandler
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<bool> ArchiveProject(int projectId)
        {
            var project = await _projectRepository.GetProject(projectId);
            project.archived = true;
            var result = await _projectRepository.UpdateProject(project);
            return true; 
        }

        /// <summary>
        /// How to handle middleware
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int> CreateProject(Project input)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetCalculatedProject(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetComplexProject(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetSimpleProject(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> PatchProject(Project project)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetSimpleProjectsForUser(int UserId)
        {
            return await _projectRepository.GetProjectsForUser(UserId);
        }
    }
}
