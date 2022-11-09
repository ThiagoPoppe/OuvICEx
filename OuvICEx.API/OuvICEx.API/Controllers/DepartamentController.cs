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
        [ProducesResponseType(typeof(IEnumerable<DepartamentModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get()
        {
            try
            {
                var departaments = _departamentService.GetAllDepartaments();
                return Ok(departaments);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DepartamentModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetById(int id)
        {
            try
            {
                var departament = _departamentService.GetDepartamentById(id);
                return Ok(departament);
            }
            catch (BadHttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] DepartamentCreationModel departament)
        {
            try
            {
                _departamentService.CreateDepartament(departament);
                return Ok();
            }
            catch (BadHttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
