using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeTracker.CompanyManagement.Core.Interfaces;
using TimeTracker.CompanyManagement.Core.Models;
using TimeTracker.CompanyManagement.Core.Models.ApiModels;

namespace TimeTracker.API.Controllers.Crud
{
    [ApiController]
    [Route("[controller]")]
    public class HolidayController : ControllerBase
    {
        private readonly IRepository<Holiday> _holidayRepository;

        public HolidayController(IRepository<Holiday> holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _holidayRepository.ListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var holiday = await _holidayRepository.GetByIdAsync(id);
            if (holiday == null)
            {
                return NotFound(id);
            }

            return Ok(holiday);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HolidayApiModel holidayApiModel)
        {
            var holidayToSave = new Holiday
            {
                Name = holidayApiModel.Name,
                Date = holidayApiModel.Date,
                BranchId = holidayApiModel.BranchId
            };
            await _holidayRepository.InsertAsync(holidayToSave);
            await _holidayRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]HolidayApiModel holidayApiModel)
        {
            var holidayToUpdate = await _holidayRepository.GetByIdAsync(id);
            if (holidayToUpdate == null)
            {
                return NotFound(id);
            }

            holidayToUpdate.Name = holidayApiModel.Name;
            holidayToUpdate.Date = holidayApiModel.Date;
            // TODO: Set update values for related entities

            _holidayRepository.Update(holidayToUpdate);
            await _holidayRepository.SaveAsync();
            return Ok(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _holidayRepository.DeleteAsync(id);
            await _holidayRepository.SaveAsync();
            return Ok(id);
        }
    }
}
