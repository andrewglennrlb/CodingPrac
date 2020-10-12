using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Connection;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ProjectRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Get a Single Project By Project Id Key
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<Project> GetProject(int projectId)
        {
            using (var connection = _connectionFactory.GetOpenConnection())
            {
                var results = await connection.GetAsync<Project>(projectId);
                return results;
            }
        }

        /// <summary>
        /// Use Dapper to query all projects by User Id. @TODO
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Task<IEnumerable<Project>> GetProjectsForUser(int UserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Use Dapper.Contrib.Extension to insert a project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public async Task<int> InsertProject(Project project)
        {
            using (var connection = _connectionFactory.GetOpenConnection())
            {
                var newId = await connection.InsertAsync(project);
                return newId;
            }
        }

        /// <summary>
        /// Use Dapper.Contrib.Extension to update a project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public async Task<Project> UpdateProject(Project project)
        {
            using (var connection = _connectionFactory.GetOpenConnection())
            {
                var updated = await connection.UpdateAsync(project);
                return await GetProject(project.ProjectId);
            }
        }
    }
}
