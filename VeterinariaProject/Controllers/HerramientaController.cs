using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VeterinariaProject.Clases;
using VeterinariaProject.Models;

namespace VeterinariaProject.Controllers
{
    [RoutePrefix("api/Matricula")]
    [Authorize]
    public class SedeController : ApiController
    {
        private clsSede sede = new clsSede();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Sede newSede)
        {
            return sede.Insertar(newSede);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Sede ConsultarXId(int idSede)
        {
            return sede.Consultar(idSede);
        }
        [HttpGet]
        [Route("ConsultarXCidudad")]
        public List<Sede> ConsultarXCiudad(string ciudad)
        {
            return sede.ConsultarXCiudad(ciudad);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Sede> ConsultarTodos()
        {
            return sede.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idSede, [FromBody] Sede _sede)
        {
            return sede.Actualizar(idSede, _sede);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idSede)
        {
            return sede.Eliminar(idSede);
        }
    }
}