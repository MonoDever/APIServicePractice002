using APIServicePractice002.BSL.IService;
using APIServicePractice002.DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APIServicePractice002.Controllers
{
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/[controller]/GetUser")]
        public IActionResult GetUser([FromBody] UserModel userModel)
        {
            IActionResult response = Unauthorized();

            var userEntities = _userService.GetUser(userModel);
            if (userEntities.user.Count > 0 && userEntities.isError == false)
            {
                response = Ok(userEntities);
            }
            else
            {
                response = Conflict(userEntities);
            }
            return response;
        }
    }
}
