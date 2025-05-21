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
    [RoutePrefix("api/Empleado")]
    [Authorize]
    public class EmpleadoController : ApiController
    {
        private clsEmpleado emp = new clsEmpleado();

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Empleado newEmpleado)
        {
            return emp.Insertar(newEmpleado);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Empleado ConsultarXId(int idEmpleado)
        {
            return emp.Consultar(idEmpleado);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Empleado> ConsultarTodos()
        {
            return emp.ConsultarTodos();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(int idEmpleado, [FromBody] Empleado _emp)
        {
            return emp.Actualizar(idEmpleado, _emp);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idEmpleado)
        {
            return emp.Eliminar(idEmpleado);
        }
    }
}