using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class EstadoController : Controller
    {
        [EnableCors("API")]
        [HttpGet]
        [Route("api/Estado/GetAll")]
        public ActionResult Index()
        {
            ML.Result result = BL.Estado.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }//GetAll

        [EnableCors("API")]
        [HttpGet]
        [Route("api/Estado/GetById")]
        public ActionResult GetById(int idEstado)
        {
            ML.Result result = BL.Estado.GetById(idEstado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }//GetById
    }
}
