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
        private Veterinaria1Entities vet = new Veterinaria1Entities();

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
        public List<Herramienta> ConsultarXProveedor(string nombreProveedor)
        {
            return vet.Herramientas
                .Where(h => h.Proveedor.nombre == nombreProveedor)
                .ToList();
        }
        public List<Herramienta> ConsultarXTipo(string tipo)
        {
            return vet.Herramientas
                .Where(h=> h.tipo == tipo)
                .ToList();
        }

        public string Actualizar(Herramienta herramienta)
        {
            try
            {
                Herramienta her = Consultar(herramienta.id);

                if (her == null)
                {
                    return "La herramienta no existe";
                }

                vet.Herramientas.AddOrUpdate(herramienta);
                vet.SaveChanges();

                return "Se actualizó la herramienta " + herramienta.nombre + " correctamente";
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
