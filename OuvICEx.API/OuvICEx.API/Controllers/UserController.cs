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
        public IEnumerable<User> Get()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserModel user)
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
