using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsCita
    {
        private VeterinariaEntities vet = new VeterinariaEntities();

        private Cita cita { get; set; }


        public string Insertar(Cita newCita)
        {
            try
            {
                vet.Citas.Add(newCita);
                vet.SaveChanges();
                return "Se ingresó la cita a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Cita Consultar(int idCita)
        {
            Cita cita = vet.Citas.FirstOrDefault(p => p.id == idCita);
            return cita;
        }
        public List<Cita> ConsultarTodos()
        {
            return vet.Citas
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idCita, Cita cita)
        {
            try
            {
                Cita cit = Consultar(idCita);
                if (cit == null)
                {
                    return "No se encontró la cita a eliminar";
                }
                cit.fecha = cita.fecha;
                cit.motivo = cita.motivo;
                cit.mascota_id = cita.mascota_id;
                cit.empleado_id = cita.empleado_id;
                cit.sede_id = cita.sede_id;
                vet.Citas.AddOrUpdate(cit);
                vet.SaveChanges();
                return "Se actualizó la cita correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idCita)
        {
            try
            {
                Cita cita = Consultar(idCita);
                if (cita == null)
                {
                    return "La cita no existe";
                }
                vet.Citas.Remove(cita);
                vet.SaveChanges();
                return "Se eliminó la cita correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
