using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Handlers;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Repsitory_Coding_Prac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectHandler _projectHandler;
        public ProjectController(IProjectHandler projectHandler)
        {
            _projectHandler = projectHandler;
        }
        // GET: api/<ValuesController>
        [HttpGet("{userId}")]
        public async Task<IEnumerable<Project>> GetByUser(int userId)
        {
            try
            {
                return await _projectHandler.GetSimpleProjectsForUser(userId);
            }
            catch( Exception ex)
            {
                // TODO: Could do better. Implement in base Controller class
                throw ex;
            }
            
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Project> Get(int id)
        {
            try
            {
                return await _projectHandler.GetSimpleProject(id);
            }
            catch (Exception ex)
            {
                // TODO: Could do better. Implement in base Controller class
                throw ex;
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<int> Post([FromBody] Project value)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    return await _projectHandler.CreateProject(value);
                } else
                {
                    // TO IMPROVE response
                    throw new Exception("Invalid Model");
                }  
            }
            catch (Exception ex)
            {
                // TODO: Could do better. Implement in base Controller class
                throw ex;
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPatch("{id}")]
        public async Task<Project> Patch(int id, [FromBody] Project value)
        {
            try
            {
                return await _projectHandler.PatchProject(value);
            }
            catch (Exception ex)
            {
                // TODO: Could do better. Implement in base Controller class
                throw ex;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _projectHandler.ArchiveProject(id);
            }
            catch (Exception ex)
            {
                // TODO: Could do better. Implement in base Controller class
                throw ex;
            }
        }
    }
}
