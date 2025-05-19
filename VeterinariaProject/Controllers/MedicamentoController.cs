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
    [RoutePrefix("api/Medicamento")]
    public class MedicamentoController : ApiController
    {
        private clsMedicamento Medicamento = new clsMedicamento();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Medicamento newMedicamento)
        {
            return Medicamento.Insertar(newMedicamento);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Medicamento ConsultarXId(int idMedicamento)
        {
            return Medicamento.Consultar(idMedicamento);
        }

        [HttpGet]
        [Route("ConsultarXTipo")]
        public List<Medicamento> ConsultarXTipo(string tipo)
        {
            return Medicamento.ConsultarXTipo(tipo);
        }

        [HttpGet]
        [Route("ConsultarXProveedor")]
        public List<Medicamento> ConsultarXProveedor(string nombreProveedor)
        {
            return Medicamento.ConsultarXProveedor(nombreProveedor);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Medicamento> ConsultarTodos()
        {
            return Medicamento.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idMedicamento, [FromBody] Medicamento _Medicamento)
        {
            return Medicamento.Actualizar(idMedicamento, _Medicamento);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idMedicamento)
        {
            return Medicamento.Eliminar(idMedicamento);
        }
    }
}