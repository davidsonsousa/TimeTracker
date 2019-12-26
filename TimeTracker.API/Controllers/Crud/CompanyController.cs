using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeTracker.CompanyManagement.Core.Interfaces;
using TimeTracker.CompanyManagement.Core.Model;

namespace TimeTracker.API.Controllers.Crud
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyController(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _companyRepository.ListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound(id);
            }

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Company company)
        {
            await _companyRepository.InsertAsync(company);
            await _companyRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]Company company)
        {
            var companyToUpdate = await _companyRepository.GetByIdAsync(id);
            companyToUpdate.Name = company.Name;
            // TODO: Set update values for Branches and Projects

            _companyRepository.Update(companyToUpdate);
            await _companyRepository.SaveAsync();
            return Ok(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyRepository.DeleteAsync(id);
            await _companyRepository.SaveAsync();
            return Ok(id);
        }
    }
}
