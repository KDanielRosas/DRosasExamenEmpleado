﻿using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        public ActionResult GetAll()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View(new ML.Empleado());
        }
    }
}
