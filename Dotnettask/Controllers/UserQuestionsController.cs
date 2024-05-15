using Dotnettask.DTOs;
using Dotnettask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnettask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQuestionsController : ControllerBase
    {
        //.. Dependency injection of the IUserQuestionServices
        private readonly IUserQuestionServices _userQuestionServices;

        // Constructor: Initializes the UserQuestionServices
        public UserQuestionsController(IUserQuestionServices userQuestionServices)
        {
            _userQuestionServices = userQuestionServices;
        }

        // Create: POST method to create a new UserQuestion entity
        [HttpPost]
        public async Task<ActionResult> CreateUserQuestion([FromBody] UserQuestionDto userQuestion)
        {
            // Calls the AddUserQuestionAsync method of the UserQuestionServices to add the new user question
            await _userQuestionServices.AddUserQuestionAsync(userQuestion);
            // Returns HTTP 200 OK status
            return Ok();
        }

        // Read: GET method to retrieve a UserQuestion entity by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UserQuestionDto>> GetUserQuestion(string id)
        {
            // Calls the GetUserQuestionAsync method of the UserQuestionServices to get the user question
            var userQuestion = await _userQuestionServices.GetUserQuestionAsync(id);
            // If the user question is not found, returns HTTP 404 Not Found status
            if (userQuestion == null)
            {
                return NotFound();
            }
            // If the user question is found, returns the user question with HTTP 200 OK status
            return Ok(userQuestion);
        }

        // Update: PUT method to update an existing UserQuestion entity by its ID
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserQuestion(string id, [FromBody] UserQuestionDto userQuestion)
        {
            // Calls the UpdateUserQuestionAsync method of the UserQuestionServices to update the user question
            await _userQuestionServices.UpdateUserQuestionAsync(id, userQuestion);
            // Returns HTTP 200 OK status
            return Ok();
        }

        // Delete: DELETE method to delete a UserQuestion entity by its ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserQuestion(string id)
        {
            // Calls the DeleteUserQuestionAsync method of the UserQuestionServices to delete the user question
            await _userQuestionServices.DeleteUserQuestionAsync(id);
            // Returns HTTP 200 OK status
            return Ok();
        }
    }

}
