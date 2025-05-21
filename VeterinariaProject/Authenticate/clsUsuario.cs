using VeterinariaProject.Models;
using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace VeterinariaProject.Authenticate
{
    public class clsUsuario
    {
        private Veterinaria1Entities vet = new Veterinaria1Entities();
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

                // 2. Validar existencia de relaciones
                var perfilExistente = vet.Perfils.Find(usuario.perfil_id);
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