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
    [RoutePrefix("api/Herramienta")]
    [Authorize]
    public class HerramientaController : ApiController
    {
       private clsHerramienta Herramienta = new clsHerramienta();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Herramienta newHerramienta)
        {
            return Herramienta.Insertar(newHerramienta);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Herramienta ConsultarXId(int idHerramienta)
        {
            return Herramienta.Consultar(idHerramienta);
        }

        [HttpGet]
        [Route("ConsultarXTipo")]
        public List<Herramienta> ConsultarXTipo(string tipo)
        {
            return Herramienta.ConsultarXTipo(tipo);
        }

        [HttpGet]
        [Route("ConsultarXProveedor")]
        public List<Herramienta> ConsultarXProveedor(string nombreProveedor)
        {
            return Herramienta.ConsultarXProveedor(nombreProveedor);
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Herramienta _Herramienta)
        {
            return Herramienta.Actualizar(_Herramienta);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idHerramienta)
        {
            return Herramienta.Eliminar(idHerramienta);
        }
    }
}