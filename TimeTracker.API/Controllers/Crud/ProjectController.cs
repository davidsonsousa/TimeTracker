using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeTracker.CompanyManagement.Core.Interfaces;
using TimeTracker.CompanyManagement.Core.Models;
using TimeTracker.CompanyManagement.Core.Models.ApiModels;

namespace TimeTracker.API.Controllers.Crud
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectController(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _projectRepository.ListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound(id);
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProjectApiModel projectApiModel)
        {
            var projectToSave = new Project
            {
                Name = projectApiModel.Name,
                CompanyId = projectApiModel.CompanyId
            };
            await _projectRepository.InsertAsync(projectToSave);
            await _projectRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]ProjectApiModel projectApiModel)
        {
            var projectToUpdate = await _projectRepository.GetByIdAsync(id);
            if (projectToUpdate == null)
            {
                return NotFound(id);
            }

            projectToUpdate.Name = projectApiModel.Name;
            // TODO: Set update values for related entities

            _projectRepository.Update(projectToUpdate);
            await _projectRepository.SaveAsync();
            return Ok(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectRepository.DeleteAsync(id);
            await _projectRepository.SaveAsync();
            return Ok(id);
        }
    }
}
