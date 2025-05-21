using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsConsultorio
    {
        private Veterinaria1Entities vet = new Veterinaria1Entities();

        private Consultorio consultorio { get; set; }


        public string Insertar(Consultorio newConsultorio)
        {
            try
            {
                vet.Consultorios.Add(newConsultorio);
                vet.SaveChanges();
                return "Se ingresó el consultorio a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Consultorio Consultar(int idConsultorio)
        {
            Consultorio con = vet.Consultorios.FirstOrDefault(p => p.id == idConsultorio);
            return con;
        }
        public List<Consultorio> ConsultarTodos()
        {
            return vet.Consultorios
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idConsultorio, Consultorio consultorio)
        {
            try
            {
                Consultorio con = Consultar(idConsultorio);
                if (con == null)
                {
                    return "No se encontró el consultorio a eliminar";
                }
                con.nombre = consultorio.nombre;
                con.sede_id = consultorio.sede_id;
                vet.Consultorios.AddOrUpdate(con);
                vet.SaveChanges();
                return "Se actualizó el consultorio correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idConsultorio)
        {
            try
            {
                Consultorio con = Consultar(idConsultorio);
                if (con == null)
                {
                    return "El consultorio no existe";
                }
                vet.Consultorios.Remove(con);
                vet.SaveChanges();
                return "Se eliminó el consultorio correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
