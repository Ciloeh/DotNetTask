using Dotnettask.DTOs;
using Dotnettask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnettask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramInformationController : ControllerBase
    {
        //.. Dependency injection of the IProgramService
        private readonly IProgramService _programService;
        // Constructor: Initializes the ProgramService
        public ProgramInformationController(IProgramService programService)
        {
            _programService = programService;
        }

        // Create: POST method to create a new Program entity
        [HttpPost]
        public async Task<ActionResult> CreateProgram([FromBody] ProgramInformationDTO program)
        {
            // Calls the AddProgramAsync method of the ProgramService to add the new program
            await _programService.AddProgramAsync(program);
            // Returns HTTP 200 OK status
            return Ok();
        }

        // Read: GET method to retrieve a Program entity by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramInformationDTO>> GetProgram(string id)
        {
            // Calls the GetProgramAsync method of the ProgramService to get the program
            var program = await _programService.GetProgramAsync(id);
            // If the program is not found, returns HTTP 404 Not Found status
            if (program == null)
            {
                return NotFound();
            }
            // If the program is found, returns the program with HTTP 200 OK status
            return Ok(program);
        }

        // Update: PUT method to update an existing Program entity by its ID
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProgram(string id, [FromBody] ProgramInformationDTO program)
        {
            // Calls the UpdateProgramAsync method of the ProgramService to update the program
            await _programService.UpdateProgramAsync(id, program);
            // Returns HTTP 200 OK status
            return Ok();
        }

        // Delete: DELETE method to delete a Program entity by its ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProgram(string id)
        {
            // Calls the DeleteProgramAsync method of the ProgramService to delete the program
            await _programService.DeleteProgramAsync(id);
            // Returns HTTP 200 OK status
            return Ok();
        }
    }


}
