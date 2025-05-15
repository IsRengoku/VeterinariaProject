using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsTipoServicio
    {
        private VeterinariaEntities vet = new VeterinariaEntities();

        private TipoServicio tipoServicio { get; set; }


        public string Insertar(TipoServicio newTipoServicio)
        {
            try
            {
                vet.TipoServicios.Add(newTipoServicio);
                vet.SaveChanges();
                return "Se ingresó el tipoServicio a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public TipoServicio Consultar(int idTipoServicio)
        {
            TipoServicio tipserv = vet.TipoServicios.FirstOrDefault(p => p.id == idTipoServicio);
            return tipserv;
        }
        public List<TipoServicio> ConsultarTodos()
        {
            return vet.TipoServicios
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idTipoServicio, TipoServicio tipoServicio)
        {
            try
            {
                TipoServicio tipserv = Consultar(idTipoServicio);
                if (tipserv == null)
                {
                    return "No se encontró el tipoServicio a eliminar";
                }
                tipserv.nombre = tipoServicio.nombre;
                tipserv.costo = tipoServicio.costo;
                tipserv.descripcion = tipoServicio.descripcion;
                vet.TipoServicios.AddOrUpdate(tipserv);
                vet.SaveChanges();
                return "Se actualizó el tipoServicio correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idTipoServicio)
        {
            try
            {
                TipoServicio tipserv = Consultar(idTipoServicio);
                if (tipserv == null)
                {
                    return "El tipoServicio no existe";
                }
                vet.TipoServicios.Remove(tipserv);
                vet.SaveChanges();
                return "Se eliminó el tipoServicio correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
