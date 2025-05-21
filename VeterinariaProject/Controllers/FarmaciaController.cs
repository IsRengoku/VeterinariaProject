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
    [RoutePrefix("api/Farmacia")]
    [Authorize]
    public class FarmaciaController : ApiController
    {
        private clsFarmacia farm = new clsFarmacia();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Farmacia newFarmacia)
        {
            return farm.Insertar(newFarmacia);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Farmacia ConsultarXId(int idFarmacia)
        {
            return farm.Consultar(idFarmacia);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Farmacia> ConsultarTodos()
        {
            return farm.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idFarmacia, [FromBody] Farmacia _Farmacia)
        {
            return farm.Actualizar(idFarmacia, _Farmacia);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idFarmacia)
        {
            return farm.Eliminar(idFarmacia);
        }
    }
}