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
    [RoutePrefix("api/Consultorio")]
    [Authorize]

    public class ConsultorioController : ApiController
    {
        private clsConsultorio consultorio = new clsConsultorio();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Consultorio newConsultorio)
        {
            return consultorio.Insertar(newConsultorio);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Consultorio ConsultarXId(int idConsultorio)
        {
            return consultorio.Consultar(idConsultorio);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Consultorio> ConsultarTodos()
        {
            return consultorio.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idConsultorio, [FromBody] Consultorio _consultorio)
        {
            return consultorio.Actualizar(idConsultorio, _consultorio);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idConsultorio)
        {
            return consultorio.Eliminar(idConsultorio);
        }
    }
}
