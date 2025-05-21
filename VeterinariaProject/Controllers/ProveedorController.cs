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
    [RoutePrefix("api/Proveedor")]
    [Authorize]
    public class ProveedorController : ApiController
    {
        private clsProveedor prov = new clsProveedor();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Proveedor newProveedor)
        {
            return prov.Insertar(newProveedor);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Proveedor ConsultarXId(int idProveedor)
        {
            return prov.Consultar(idProveedor);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Proveedor> ConsultarTodos()
        {
            return prov.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idProveedor, [FromBody] Proveedor _prov)
        {
            return prov.Actualizar(idProveedor, _prov);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idProveedor)
        {
            return prov.Eliminar(idProveedor);
        }
    }
}