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
    [RoutePrefix("api/Mascota")]
    [Authorize]

    public class MascotaController : ApiController
    {
        private clsMascota mascota = new clsMascota();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Mascota newMascota)
        {
            return mascota.Insertar(newMascota);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Mascota ConsultarXId(int idMascota)
        {
            return mascota.Consultar(idMascota);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Mascota> ConsultarTodos()
        {
            return mascota.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idMascota, [FromBody] Mascota _mascota)
        {
            return mascota.Actualizar(idMascota, _mascota);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idMascota)
        {
            return mascota.Eliminar(idMascota);
        }
    }
}
