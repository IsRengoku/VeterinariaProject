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
    [RoutePrefix("api/Cita")]
    [Authorize]
    
    public class CitaController : ApiController
    {
        private clsCita cita = new clsCita();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cita newCita)
        {
            return cita.Insertar(newCita);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Cita ConsultarXId(int idCita)
        {
            return cita.Consultar(idCita);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Cita> ConsultarTodos()
        {
            return cita.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idCita, [FromBody] Cita _cita)
        {
            return cita.Actualizar(idCita, _cita);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idCita)
        {
            return cita.Eliminar(idCita);
        }
    }
}
