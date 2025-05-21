using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsInventarioMedicamento
    {
        private Veterinaria1Entities vet = new Veterinaria1Entities();

        private InventarioMedicamento inventarioMedicamento { get; set; }


        public string Insertar(InventarioMedicamento newInventarioMedicamento)
        {
            try
            {
                vet.InventarioMedicamentoes.Add(newInventarioMedicamento);
                vet.SaveChanges();
                return "Se ingresó exitosamente a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public InventarioMedicamento Consultar(int idInventarioMedicamento)
        {
            InventarioMedicamento inv = vet.InventarioMedicamentoes.FirstOrDefault(p => p.id == idInventarioMedicamento);
            return inv;
        }
        public List<InventarioMedicamento> ConsultarTodos()
        {
            return vet.InventarioMedicamentoes
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idInventarioMedicamento, InventarioMedicamento inventarioMedicamento)
        {
            try
            {
                InventarioMedicamento inv = Consultar(idInventarioMedicamento);
                if (inv == null)
                {
                    return "No se encontró el inventario a eliminar";
                }
                inv.cantidad = inventarioMedicamento.cantidad;
                inv.medicamento_id = inventarioMedicamento.medicamento_id;
                inv.farmacia_id = inventarioMedicamento.farmacia_id;
                vet.InventarioMedicamentoes.AddOrUpdate(inv);
                vet.SaveChanges();
                return "Se actualizó el inventario correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idInventarioMedicamento)
        {
            try
            {
                InventarioMedicamento inv = Consultar(idInventarioMedicamento);
                if (inv == null)
                {
                    return "El inventario no existe";
                }
                vet.InventarioMedicamentoes.Remove(inv);
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
