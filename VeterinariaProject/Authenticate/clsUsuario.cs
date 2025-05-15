using VeterinariaProject.Models;
using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace VeterinariaProject.Authenticate
{
    public class clsUsuario
    {
        private VeterinariaEntities vet = new VeterinariaEntities();
        public Usuario usuario { get; set; }

        public string CrearUsuario(int idPerfil)
        {
            try
            {
                // 1. Validaciones básicas
                if (usuario == null)
                    return "El objeto usuario no puede ser nulo";

                if (string.IsNullOrWhiteSpace(usuario.userName))
                    return "El nombre de usuario es requerido";

                if (string.IsNullOrWhiteSpace(usuario.contraseña))
                    return "La contraseña es requerida";

                if (usuario.empleado_id <= 0)
                    return "ID de empleado inválido";

                // 2. Validar existencia de relaciones
                var estudianteExistente = vet.Empleadoes.Find(usuario.empleado_id);
                if (estudianteExistente == null)
                    return "No existe un empleado con el ID proporcionado";

                var perfilExistente = vet.Perfils.Find(idPerfil);
                if (perfilExistente == null)
                    return "No existe un perfil con el ID proporcionado";

                // 3. Cifrado de contraseña
                clsCypher cypher = new clsCypher();
                cypher.Password = usuario.contraseña;

                if (!cypher.CifrarClave())
                    return "Error al cifrar la contraseña";

                // 4. Asignar valores cifrados
                usuario.contraseña = cypher.PasswordCifrado;
                usuario.salt = cypher.Salt;

                // 6. Guardar en base de datos
                vet.Usuarios.Add(usuario);
                vet.SaveChanges();

                // 7. Crear relación Usuario_Perfil
                var usuarioPerfil = new Usuario_Perfil
                {
                    idUsuario = usuario.id,
                    idPerfil = idPerfil,
                    Activo = true
                };

                vet.Usuario_Perfil.Add(usuarioPerfil);
                vet.SaveChanges();

                return "Usuario creado exitosamente";
            }
            catch (DbEntityValidationException ex)
            {
                // Capturar todos los errores de validación
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(e => e.ValidationErrors)
                    .Select(e => $"- {e.PropertyName}: {e.ErrorMessage}");

                return $"Error de validación:\n{string.Join("\n", errorMessages)}";
            }
            catch (Exception ex)
            {
                return $"Error inesperado: {ex.Message}";
            }
        }
    }
}