using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
    public class clsServicio
    {
        private Veterinaria1Entities vet = new Veterinaria1Entities();

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

        public List<Servicio> Filtrar(string fecha_ingreso, string fecha_salida, int mascota_id, int empleado_id, int consultorio_id, int tipoServicio_id)
        {
            var query = vet.Servicios.AsQueryable();

            if (DateTime.TryParseExact(fecha_ingreso, "yyyy-mm-dd", null, DateTimeStyles.None, out DateTime fecha_ingresoT))
                query = query.Where(s => s.fecha_ingreso >= fecha_ingresoT);

            if (DateTime.TryParseExact(fecha_salida, "yyyy-mm-dd", null, DateTimeStyles.None, out DateTime fecha_salidaT))
                query = query.Where(s => s.fecha_salida <= fecha_salidaT);

            if (mascota_id > 0)
                query = query.Where(s => s.mascota_id == mascota_id);

            if (empleado_id > 0)
                query = query.Where(s => s.empleado_id == empleado_id);

            if (consultorio_id > 0)
                query = query.Where(s => s.consultorio_id == consultorio_id);

            if (tipoServicio_id > 0)
                query = query.Where(s => s.tipoServicio_id == tipoServicio_id);

            return query.ToList();
        }
    }

}
