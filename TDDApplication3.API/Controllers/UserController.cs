using Microsoft.AspNetCore.Mvc;
using TDDApplication3.DTO.Constants;
using TDDApplication3.DTO.DTOs;
using TDDApplication3.Service.Interface;

namespace TDDApplication3.API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.ControllerRouting)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var result = _userService.GetUserList();
                if (result.Any())
                {
                    return Ok(result);

                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }

        }
        [HttpPost]
        public IActionResult CreateUser(UserDTO user)
        {
            try
            {
                if (user == null || string.IsNullOrEmpty(user.Name))
                    return BadRequest();

                var result = _userService.CreateUser(user);

                if (result != null && result.UserId != 0)
                    return Ok(user);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }

        }
    }
}