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
    [RoutePrefix("api/TipoServicio")]
    [Authorize]

    public class TipoServicioController : ApiController
    {
        private clsTipoServicio tipoServicio = new clsTipoServicio();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] TipoServicio newTipoServicio)
        {
            return tipoServicio.Insertar(newTipoServicio);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public TipoServicio ConsultarXId(int idTipoServicio)
        {
            return tipoServicio.Consultar(idTipoServicio);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<TipoServicio> ConsultarTodos()
        {
            return tipoServicio.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idTipoServicio, [FromBody] TipoServicio _tipoServicio)
        {
            return tipoServicio.Actualizar(idTipoServicio, _tipoServicio);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idTipoServicio)
        {
            return tipoServicio.Eliminar(idTipoServicio);
        }
    }
}
