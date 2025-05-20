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
    [RoutePrefix("api/InventarioHerramienta")]
    [Authorize]
    public class InventarioHerramientaController : ApiController
    {
        private clsInventarioHerramienta _inventarioHerramienta = new clsInventarioHerramienta();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] InventarioHerramienta newInventarioHerranieta)
        {
            return _inventarioHerramienta.Insertar(newInventarioHerranieta);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public InventarioHerramienta ConsultarXId(int idInventarioHerramienta)
        {
            return _inventarioHerramienta.Consultar(idInventarioHerramienta);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<InventarioHerramienta> ConsultarTodos()
        {
            return _inventarioHerramienta.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idInventarioHerramienta, [FromBody] InventarioHerramienta inventarioHerramienta)
        {
            return _inventarioHerramienta.Actualizar(idInventarioHerramienta, inventarioHerramienta);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idInventarioHerramienta)
        {
            return _inventarioHerramienta.Eliminar(idInventarioHerramienta);
        }
    }
}