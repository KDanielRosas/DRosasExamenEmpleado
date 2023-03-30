using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class EmpleadoController : Controller
    {
        [EnableCors("API")]
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        public ActionResult Index()
        {
            ML.Result result = BL.Empleado.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }            
        }//GetAll

        [EnableCors("API")]
        [HttpPost]
        [Route("api/Empleado/Add")]
        public ActionResult Add([FromBody]ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }//Add

        [EnableCors("API")]
        [HttpPost]
        [Route("api/Empleado/Delete")]
        public ActionResult Delete(int idEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(idEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }//Delete

        [EnableCors("API")]
        [HttpGet]
        [Route("api/Empleado/GetById")]
        public ActionResult GetById(int idEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(idEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }//GetById

        [EnableCors("API")]
        [HttpPost]
        [Route("api/Empleado/Update")]
        public ActionResult Update([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }//Update
    }
}
