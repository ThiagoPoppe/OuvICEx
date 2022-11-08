using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces.Service;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserCreationModel user)
        {
            try
            {
                _userService.CreateUser(user);
                return Ok();
            }
            catch (BadHttpRequestException e)
            {                
                return StatusCode(403, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }
}
