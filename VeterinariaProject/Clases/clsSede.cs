using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsSede
    {
        private Veterinaria1Entities vet = new Veterinaria1Entities();

        private Sede sede { get; set; }


        public string Insertar(Sede newSede)
        {
            try
            {
                vet.Sedes.Add(newSede);
                vet.SaveChanges();
                return "Se ingresó la Sede a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Sede> ConsultarXCiudad(string ciudad)
        {
            return vet.Sedes
                .Where(m => m.ciudad == ciudad)
                .OrderBy(m => m.nombre)
                .ToList();
        }
        public Sede Consultar(int idSede)
        {
            Sede sed = vet.Sedes.FirstOrDefault(p => p.id == idSede);
            return sed;
        }
        public List<Sede> ConsultarTodos()
        {
            return vet.Sedes
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idSede, Sede sede)
        {
            try
            {
                Sede sed = Consultar(idSede);
                if (sed == null)
                {
                    return "No se encontró la Sede a eliminar";
                }
                sed.nombre = sede.nombre;
                sed.ciudad = sede.ciudad;
                sed.direccion = sede.direccion;
                vet.Sedes.AddOrUpdate(sed);
                vet.SaveChanges();
                return "Se actualizó la Sede correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idSede)
        {
            try
            {
                Sede sed = Consultar(idSede);
                if (sed == null)
                {
                    return "La sede no existe";
                }
                vet.Sedes.Remove(sed);
                vet.SaveChanges();
                return "Se eliminó la Sede correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
