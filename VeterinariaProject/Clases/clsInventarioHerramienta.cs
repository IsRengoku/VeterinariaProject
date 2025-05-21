using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsInventarioHerramienta
    {
        private Veterinaria1Entities vet = new Veterinaria1Entities();

        private InventarioHerramienta inventarioHerramienta { get; set; }


        public string Insertar(InventarioHerramienta newInventarioHerramienta)
        {
            try
            {
                vet.InventarioHerramientas.Add(newInventarioHerramienta);
                vet.SaveChanges();
                return "Se ingresó el inventario a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public InventarioHerramienta Consultar(int idInventarioHerramienta)
        {
            InventarioHerramienta inv = vet.InventarioHerramientas.FirstOrDefault(p => p.id == idInventarioHerramienta);
            return inv;
        }
        public List<InventarioHerramienta> ConsultarTodos()
        {
            return vet.InventarioHerramientas
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idInventarioHerramienta, InventarioHerramienta inventarioHerramienta)
        {
            try
            {
                InventarioHerramienta inv = Consultar(idInventarioHerramienta);
                if (inv == null)
                {
                    return "No se encontró el inventario a eliminar";
                }
                inv.cantidad = inventarioHerramienta.cantidad;
                inv.herramientas_id = inventarioHerramienta.herramientas_id;
                inv.farmacia_id = inventarioHerramienta.farmacia_id;
                vet.InventarioHerramientas.AddOrUpdate(inv);
                vet.SaveChanges();
                return "Se actualizó el inventario correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idInventarioHerramienta)
        {
            try
            {
                InventarioHerramienta inv = Consultar(idInventarioHerramienta);
                if (inv == null)
                {
                    return "El inventario no existe";
                }
                vet.InventarioHerramientas.Remove(inv);
                vet.SaveChanges();
                return "Se eliminó el inventario correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
