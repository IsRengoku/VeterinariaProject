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
        private Veterinaria1Entities vet = new Veterinaria1Entities();

        private Empleado emp { get; set; }


        public string Insertar(Empleado nuevaEmpleado)
        {
            try
            {
                vet.Empleadoes.Add(nuevaEmpleado);
                vet.SaveChanges();
                return "Se ingresó el empleado la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Empleado Consultar(int idEmpleado)
        {
            Empleado mat = vet.Empleadoes.FirstOrDefault(p => p.id == idEmpleado);
            return mat;
        }
        public List<Empleado> ConsultarTodos()
        {
            return vet.Empleadoes
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idEmpleado, Empleado emp)
        {
            try
            {
                Empleado sed = Consultar(idEmpleado);
                if (sed == null)
                {
                    return "No se encontró el empleado a eliminar";
                }
                sed.nombre = emp.nombre;
                sed.correo = emp.correo;
                sed.usuario_id = emp.usuario_id;
                sed.sede_id = emp.sede_id;
                vet.Empleadoes.AddOrUpdate(emp);
                vet.SaveChanges();
                return "Se actualizó el empleado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idEmpleado)
        {
            try
            {
                Empleado prod = Consultar(idEmpleado);
                if (prod == null)
                {
                    return "El empleado no existe";
                }
                vet.Empleadoes.Remove(prod);
                vet.SaveChanges();
                return "Se eliminó el empleado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
