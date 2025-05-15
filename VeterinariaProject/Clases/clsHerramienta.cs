using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsHerramienta
    {
        private VeterinariaEntities vet = new VeterinariaEntities();

        private Herramienta herramienta { get; set; }


        public string Insertar(Herramienta newHerramienta)
        {
            try
            {
                vet.Herramientas.Add(newHerramienta);
                vet.SaveChanges();
                return "Se ingresó la herramienta a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Herramienta Consultar(int idHerramienta)
        {
            Herramienta her = vet.Herramientas.FirstOrDefault(p => p.id == idHerramienta);
            return her;
        }
        public List<Herramienta> ConsultarTodos()
        {
            return vet.Herramientas
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idHerramienta, Herramienta herramienta)
        {
            try
            {
                Herramienta her = Consultar(idHerramienta);
                if (her == null)
                {
                    return "No se encontró la herramienta a eliminar";
                }
                her.nombre = herramienta.nombre;
                her.tipo = herramienta.tipo;
                her.proveedor_id = herramienta.proveedor_id;
                vet.Herramientas.AddOrUpdate(her);
                vet.SaveChanges();
                return "Se actualizó la herramienta correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idHerramienta)
        {
            try
            {
                Herramienta her = Consultar(idHerramienta);
                if (her == null)
                {
                    return "La herramienta no existe";
                }
                vet.Herramientas.Remove(her);
                vet.SaveChanges();
                return "Se eliminó la herramienta correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
