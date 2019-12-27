using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeTracker.CompanyManagement.Core.Interfaces;
using TimeTracker.CompanyManagement.Core.Models;
using TimeTracker.CompanyManagement.Core.Models.ApiModels;

namespace TimeTracker.API.Controllers.Crud
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IRepository<Team> _teamRepository;

        public TeamController(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _teamRepository.ListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                return NotFound(id);
            }

            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TeamApiModel teamApiModel)
        {
            var teamToSave = new Team
            {
                Name = teamApiModel.Name
            };
            await _teamRepository.InsertAsync(teamToSave);
            await _teamRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]TeamApiModel teamApiModel)
        {
            var teamToUpdate = await _teamRepository.GetByIdAsync(id);
            if (teamToUpdate == null)
            {
                return NotFound(id);
            }

            teamToUpdate.Name = teamApiModel.Name;
            // TODO: Set update values for related entities

            _teamRepository.Update(teamToUpdate);
            await _teamRepository.SaveAsync();
            return Ok(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamRepository.DeleteAsync(id);
            await _teamRepository.SaveAsync();
            return Ok(id);
        }
    }
}
