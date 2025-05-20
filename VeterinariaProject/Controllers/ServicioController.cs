using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VeterinariaProject.Clases;
using VeterinariaProject.Models;

namespace VeterinariaProject.Controllers
{
    [RoutePrefix("api/Servicio")]
    [Authorize]
    public class ServicioController : ApiController
    {
        private clsServicio _servicio = new clsServicio();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Servicio newServicio)
        {
            return _servicio.Insertar(newServicio);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Servicio ConsultarXId(int idServicio)
        {
            return _servicio.Consultar(idServicio);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Servicio> ConsultarTodos()
        {
            // TODO: paginar
            return _servicio.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idServicio, [FromBody] Servicio servicio)
        {
            return _servicio.Actualizar(idServicio, servicio);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idServicio)
        {
            return _servicio.Eliminar(idServicio);
        }

        [HttpGet]
        [Route("ConsultaConFiltros")]
        public List<Servicio> ConsultaConFiltros()
        {
            var queryParams = HttpContext.Current.Request.QueryString;
            string fecha_ingreso = queryParams["fecha_ingreso"];
            string fecha_salida = queryParams["fecha_salida"];
            int mascota_id = int.Parse(queryParams["mascota_id"]);
            int empleado_id = int.Parse(queryParams["empleado_id"]);
            int consultorio_id = int.Parse(queryParams["consultorio_id"]);
            int tipoServicio_id = int.Parse(queryParams["tipoServicio_id"]);

            return _servicio.Filtrar(fecha_ingreso, fecha_salida, mascota_id, empleado_id, consultorio_id, tipoServicio_id);
        }
    }
}