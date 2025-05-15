using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsEmpleado
    {
        private VeterinariaEntities vet = new VeterinariaEntities();

        private Sede sede { get; set; }


        public string Insertar(Sede nuevaSede)
        {
            try
            {
                vet.Sedes.Add(nuevaSede);
                vet.SaveChanges();
                return "Se ingresó la Sede la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Sede Consultar(int idSede)
        {
            Sede mat = vet.Sedes.FirstOrDefault(p => p.id == idSede);
            return mat;
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
                vet.Sedes.AddOrUpdate(sede);
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
                Sede prod = Consultar(idSede);
                if (prod == null)
                {
                    return "El producto no existe";
                }
                vet.Sedes.Remove(prod);
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
