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
    [RoutePrefix("api/Cliente")]
    [Authorize]
    public class ClienteController : ApiController
    {
        private clsCliente Cliente = new clsCliente();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cliente newCliente)
        {
            return Cliente.Insertar(newCliente);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Cliente ConsultarXId(int idCliente)
        {
            return Cliente.Consultar(idCliente);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Cliente> ConsultarTodos()
        {
            return Cliente.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idCliente, [FromBody] Cliente _Cliente)
        {
            return Cliente.Actualizar(idCliente, _Cliente);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idCliente)
        {
            return Cliente.Eliminar(idCliente);
        }
    }
}