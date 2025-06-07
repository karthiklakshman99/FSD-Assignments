using CompanyManagement.Models;
using CompanyManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controller
{
    [Route("api/developer")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> GetDevelopers()
        {
            return Ok(await _developerService.GetAllDevelopersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloper(int id)
        {
            var developer = await _developerService.GetDeveloperByIdAsync(id);
            if (developer == null) return NotFound();
            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult> AddDeveloper([FromBody] Developer developer)
        {
            await _developerService.AddDeveloperAsync(developer);
            return CreatedAtAction(nameof(GetDeveloper), new { id = developer.Id }, developer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDeveloper(int id, [FromBody] Developer developer)
        {
            if (id != developer.Id) return BadRequest();
            await _developerService.UpdateDeveloperAsync(developer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeveloper(int id)
        {
            await _developerService.DeleteDeveloperAsync(id);
            return NoContent();
        }
    }

}
