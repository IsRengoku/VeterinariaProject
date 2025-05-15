using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsFarmacia
    {
        private VeterinariaEntities vet = new VeterinariaEntities();

        private Farmacia farmacia { get; set; }


        public string Insertar(Farmacia newFarmacia)
        {
            try
            {
                vet.Farmacias.Add(newFarmacia);
                vet.SaveChanges();
                return "Se ingresó la farmacia la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Farmacia Consultar(int idFarmacia)
        {
            Farmacia far = vet.Farmacias.FirstOrDefault(p => p.id == idFarmacia);
            return far;
        }
        public List<Farmacia> ConsultarTodos()
        {
            return vet.Farmacias
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idFarmacia, Farmacia farmacia)
        {
            try
            {
                Farmacia far = Consultar(idFarmacia);
                if (far == null)
                {
                    return "No se encontró la farmacia a eliminar";
                }
                far.nombre = farmacia.nombre;
                far.telefono = farmacia.telefono;
                far.direccion = farmacia.direccion;
                far.sede_id = farmacia.sede_id;
                vet.Farmacias.AddOrUpdate(far);
                vet.SaveChanges();
                return "Se actualizó la farmacia correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idFarmacia)
        {
            try
            {
                Farmacia far = Consultar(idFarmacia);
                if (far == null)
                {
                    return "La farmacia no existe";
                }
                vet.Farmacias.Remove(far);
                vet.SaveChanges();
                return "Se eliminó la farmacia correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
