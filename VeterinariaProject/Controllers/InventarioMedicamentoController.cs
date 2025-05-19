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
    [RoutePrefix("api/InventarioMedicamento")]
    [Authorize]
    public class InventarioMedicamentoController : ApiController
    {
        private clsInventarioMedicamento _inventarioMedicamento = new clsInventarioMedicamento();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] InventarioMedicamento newInventarioMedicamento)
        {
            return _inventarioMedicamento.Insertar(newInventarioMedicamento);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public InventarioMedicamento ConsultarXId(int idInventarioMedicamento)
        {
            return _inventarioMedicamento.Consultar(idInventarioMedicamento);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<InventarioMedicamento> ConsultarTodos()
        {
            return _inventarioMedicamento.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idInventarioMedicamento, [FromBody] InventarioMedicamento inventarioMedicamento)
        {
            return _inventarioMedicamento.Actualizar(idInventarioMedicamento, inventarioMedicamento);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idInventarioMedicamento)
        {
            return _inventarioMedicamento.Eliminar(idInventarioMedicamento);
        }
    }
}