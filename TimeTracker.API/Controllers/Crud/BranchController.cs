using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeTracker.CompanyManagement.Core.Interfaces;
using TimeTracker.CompanyManagement.Core.Models;
using TimeTracker.CompanyManagement.Core.Modelss.ApiModels;
using TimeTracker.SharedKernel.ValueObjects;

namespace TimeTracker.API.Controllers.Crud
{
    [ApiController]
    [Route("[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly IRepository<Branch> _branchRepository;

        public BranchController(IRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _branchRepository.ListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var branch = await _branchRepository.GetByIdAsync(id);
            if (branch == null)
            {
                return NotFound(id);
            }

            return Ok(branch);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BranchApiModel branchApiModel)
        {
            var branchToSave = new Branch
            {
                Name = branchApiModel.Name,
                Address = new Address(branchApiModel.Street, branchApiModel.City, branchApiModel.State, branchApiModel.Country, branchApiModel.ZipCode),
                CompanyId = branchApiModel.CompanyId
            };

            await _branchRepository.InsertAsync(branchToSave);
            await _branchRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]BranchApiModel branchApiModel)
        {
            var branchToUpdate = await _branchRepository.GetByIdAsync(id);
            branchToUpdate.Name = branchApiModel.Name;
            branchToUpdate.Address = new Address(branchApiModel.Street, branchApiModel.City, branchApiModel.State, branchApiModel.Country, branchApiModel.ZipCode);
            // TODO: Set update values for related entities

            _branchRepository.Update(branchToUpdate);
            await _branchRepository.SaveAsync();
            return Ok(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _branchRepository.DeleteAsync(id);
            await _branchRepository.SaveAsync();
            return Ok(id);
        }
    }
}
