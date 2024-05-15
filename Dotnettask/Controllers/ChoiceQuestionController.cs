using Dotnettask.DTOs;
using Dotnettask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnettask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceQuestionController : ControllerBase
    {
        //.. Dependency injection of the IChoiceQuestionService
        private readonly IChoiceQuestionService _choiceQuestionService;

        // Constructor: Initializes the ChoiceQuestionService
        public ChoiceQuestionController(IChoiceQuestionService choiceQuestionService)
        {
            _choiceQuestionService = choiceQuestionService;
        }

        // Create: POST method to create a new ChoiceQuestion entity
        [HttpPost]
        public async Task<ActionResult> CreateChoiceQuestion([FromBody] ChoiceQuestionDto choiceQuestion)
        {
            // Calls the AddChoiceQuestionAsync method of the ChoiceQuestionService to add the new choice question
            await _choiceQuestionService.AddChoiceQuestionAsync(choiceQuestion);
            // Returns HTTP 200 OK status
            return Ok();
        }

        // Read: GET method to retrieve a ChoiceQuestion entity by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ChoiceQuestionDto>> GetChoiceQuestion(string id)
        {
            // Calls the GetChoiceQuestionAsync method of the ChoiceQuestionService to get the choice question
            var choiceQuestion = await _choiceQuestionService.GetChoiceQuestionAsync(id);
            // If the choice question is not found, returns HTTP 404 Not Found status
            if (choiceQuestion == null)
            {
                return NotFound();
            }
            // If the choice question is found, returns the choice question with HTTP 200 OK status
            return Ok(choiceQuestion);
        }

        // Update: PUT method to update an existing ChoiceQuestion entity by its ID
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateChoiceQuestion(string id, [FromBody] ChoiceQuestionDto choiceQuestion)
        {
            // Calls the UpdateChoiceQuestionAsync method of the ChoiceQuestionService to update the choice question
            await _choiceQuestionService.UpdateChoiceQuestionAsync(id, choiceQuestion);
            // Returns HTTP 200 OK status
            return Ok();
        }

        // Delete: DELETE method to delete a ChoiceQuestion entity by its ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChoiceQuestion(string id)
        {
            // Calls the DeleteChoiceQuestionAsync method of the ChoiceQuestionService to delete the choice question
            await _choiceQuestionService.DeleteChoiceQuestionAsync(id);
            // Returns HTTP 200 OK status
            return Ok();
        }
    }

}
