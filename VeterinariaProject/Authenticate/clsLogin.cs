using VeterinariaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaProject.Authenticate
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public VeterinariaEntities vet = new VeterinariaEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        private bool ValidarUsuario()
        {
            try
            {
                //Se instancia un objeto de la clase Cypher
                clsCypher cifrar = new clsCypher();
                //Se consulta el usuario, sólo con el nombre, para obtener la información básica del usuario: Salt y clave encriptada
                Usuario usuario = vet.Usuarios.FirstOrDefault(u => u.userName == login.Usuario);
                if (usuario == null)
                {
                    //El usuario no existe, se retorna un error
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                //El usuario existe, se lee la información del Salt y se traduce a un arreglo de bytes y se cifra la clave que envió el usuario
                byte[] arrBytesSalt = Convert.FromBase64String(usuario.salt);
                //login.clave tiene la clave plana
                string ClaveCifrada = cifrar.HashPassword(login.Clave, arrBytesSalt);
                //Se obtiene la clave cifrada
                login.Clave = ClaveCifrada;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        private bool ValidarClave()
        {
            try
            {
                //Se consulta el usuario con la clave encriptada y el usuario para validar si existe
                Usuario usuario = vet.Usuarios.FirstOrDefault(u => u.userName == login.Usuario && u.contraseña == login.Clave);
                if (usuario == null)
                {
                    //Si no existe la clave es incorrecta
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                //La clave y el usuario son correctos
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            //Si la validación es simple, en este punto se pone el código: if (user = "admin"){ token=...;}else{error;}
            if (ValidarUsuario() && ValidarClave())
            {
                //Si el usuario y la clave son correctas, se genera el token
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                //Consulta la información del usuario y el perfil
                return from U in vet.Set<Usuario>()
                       join UP in vet.Set<Usuario_Perfil>()
                       on U.idUsuario equals UP.idUsuario
                       join P in vet.Set<Perfil>()
                       on UP.idPerfil equals P.idPerfil
                       where U.userName == login.Usuario &&
                               U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.userName,
                           Autenticado = true,
                           Perfil = P.Nombre,
                           PaginaInicio = P.PaginaNavegar,
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                List<LoginRespuesta> List = new List<LoginRespuesta>();
                List.Add(loginRespuesta);
                return List.AsQueryable();
            }
        }
    }
}