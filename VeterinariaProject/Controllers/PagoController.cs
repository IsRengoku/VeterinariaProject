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
    [RoutePrefix("api/Pago")]
    [Authorize]
    public class PagoController : ApiController
    {
        private clsPago _pago= new clsPago();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Pago newPago)
        {
            return _pago.Insertar(newPago);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Pago ConsultarXId(int idPago)
        {
            return _pago.Consultar(idPago);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Pago> ConsultarTodos()
        {
            return _pago.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idPago, [FromBody] Pago Pago)
        {
            return _pago.Actualizar(idPago, Pago);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idPago)
        {
            return _pago.Eliminar(idPago);
        }
    }
}