using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Handlers
{
    public interface IProjectHandler
    {
        Task<Project> GetSimpleProject(int ProjectId);

        Task<IEnumerable<Project>> GetSimpleProjectsForUser(int UserId);
        Task<Project> GetComplexProject(int ProjectId);
        Task<Project> GetCalculatedProject(int ProjectId);

        Task<int> CreateProject(Project input );

        Task<bool> ArchiveProject(int projectId);

        Task<Project> PatchProject(Project project);

    }
}
