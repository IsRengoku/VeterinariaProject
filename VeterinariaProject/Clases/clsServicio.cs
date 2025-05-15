using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsServicio
    {
        private VeterinariaEntities vet = new VeterinariaEntities();

        private Servicio servicio { get; set; }


        public string Insertar(Servicio newServicio)
        {
            try
            {
                vet.Servicios.Add(newServicio);
                vet.SaveChanges();
                return "Se ingresó el servicio a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Servicio Consultar(int idServicio)
        {
            Servicio serv = vet.Servicios.FirstOrDefault(p => p.id == idServicio);
            return serv;
        }
        public List<Servicio> ConsultarTodos()
        {
            return vet.Servicios
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idServicio, Servicio servicio)
        {
            try
            {
                Servicio serv = Consultar(idServicio);
                if (serv == null)
                {
                    return "No se encontró el servicio a eliminar";
                }
                serv.fecha_ingreso = servicio.fecha_ingreso;
                serv.fecha_salida = servicio.fecha_salida;
                serv.mascota_id = servicio.mascota_id;
                serv.empleado_id = servicio.empleado_id;
                serv.consultorio_id = servicio.consultorio_id;
                serv.tipoServicio_id = servicio.tipoServicio_id;
                vet.Servicios.AddOrUpdate(serv);
                vet.SaveChanges();
                return "Se actualizó el servicio correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idServicio)
        {
            try
            {
                Servicio serv = Consultar(idServicio);
                if (serv == null)
                {
                    return "El servicio no existe";
                }
                vet.Servicios.Remove(serv);
                vet.SaveChanges();
                return "Se eliminó el servicio correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
