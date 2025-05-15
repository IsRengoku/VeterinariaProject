using VeterinariaProject.Authenticate;
using VeterinariaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VeterinariaProject.Controllers.LogIn
{
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("CrearUsuario")]
        [AllowAnonymous]
        public string CrearUsuario([FromBody] Usuario usuario, int idPerfil)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.CrearUsuario(idPerfil);
        }
    }
}