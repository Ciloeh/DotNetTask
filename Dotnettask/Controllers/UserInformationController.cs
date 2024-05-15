using Dotnettask.DTOs;
using Dotnettask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnettask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        // Dependency injection of the IUserInformationServices
        private readonly IUserInformationServices _userInformationServices;
        // Constructor: Initializes the UserInformationServices
        public UserInformationController(IUserInformationServices userInformationServices)
        {
            _userInformationServices = userInformationServices;
        }

        // Create: POST method to create a new User entity
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserInformationDTO user)
        {
            // Calls the AddUserAsync method of the UserInformationServices to add the new user
            await _userInformationServices.AddUserAsync(user);
            // Returns HTTP 200 OK status
            return Ok();
        }

        // Read: GET method to retrieve a User entity by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInformationDTO>> GetUser(string id)
        {
            // Calls the GetUserAsync method of the UserInformationServices to get the user
            var user = await _userInformationServices.GetUserAsync(id);
            // If the user is not found, returns HTTP 404 Not Found status
            if (user == null)
            {
                return NotFound();
            }
            // If the user is found, returns the user with HTTP 200 OK status
            return Ok(user);
        }

        // Update: PUT method to update an existing User entity by its ID
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(string id, [FromBody] UserInformationDTO user)
        {
            // Calls the UpdateUserAsync method of the UserInformationServices to update the user
            await _userInformationServices.UpdateUserAsync(id, user);
            // Returns HTTP 200 OK status
            return Ok();
        }

        // Delete: DELETE method to delete a User entity by its ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            // Calls the DeleteUserAsync method of the UserInformationServices to delete the user
            await _userInformationServices.DeleteUserAsync(id);
            // Returns HTTP 200 OK status
            return Ok();
        }

    }

}
