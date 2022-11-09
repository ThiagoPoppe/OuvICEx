using Microsoft.AspNetCore.Mvc;
using OuvICEx.API.Domain.Interfaces.Service;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly IDepartamentService _departamentService;

        public DepartamentController(IDepartamentService departamentService)
        {
            _departamentService = departamentService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var departaments = _departamentService.GetAllDepartaments();
                return Ok(departaments);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("{id}")]        
        public ActionResult GetById(int id)
        {
            try
            {
                var departament = _departamentService.GetDepartamentById(id);
                return Ok(departament);
            }
            catch (BadHttpRequestException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] DepartamentCreationModel departament)
        {
            try
            {
                _departamentService.CreateDepartament(departament);
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
