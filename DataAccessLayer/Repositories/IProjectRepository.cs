using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetProject(int ProjectId);

        Task<Project> UpdateProject(Project project);

        Task<int> InsertProject(Project project);

        Task<IEnumerable<Project>> GetProjectsForUser(int UserId);
    }
}
