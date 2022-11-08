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

        //[HttpGet]
        //public ActionResult<IEnumerable<DepartamentModel>> Get()
        //{   
        //    try
        //    {
        //        var departaments = _departamentService.GetAllDepartaments();
        //        return Ok(departaments);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500);
        //    }
        //}

        [HttpGet]
        public IEnumerable<DepartamentModel> Get()
        {
                return _departamentService.GetAllDepartaments();

        }

        [HttpGet("{id}")]        
        public DepartamentModel GetById(int id)
        {
            return _departamentService.GetDepartamentById(id);

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
