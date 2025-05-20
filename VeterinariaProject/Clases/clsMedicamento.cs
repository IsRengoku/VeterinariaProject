using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsMedicamento
    {
        private VeterinariaEntities vet = new VeterinariaEntities();

        private Medicamento medicamento { get; set; }


        public string Insertar(Medicamento newMedicamento)
        {
            try
            {
                vet.Medicamentoes.Add(newMedicamento);
                vet.SaveChanges();
                return "Se ingresó el medicamento a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Medicamento Consultar(int idMedicamento)
        {
            Medicamento med = vet.Medicamentoes.FirstOrDefault(p => p.id == idMedicamento);
            return med;
        }
        public List<Medicamento> ConsultarTodos()
        {
            return vet.Medicamentoes
                .OrderBy(m => m.id)
                .ToList();
        }
        public List<Medicamento> ConsultarXProveedor(string nombreProveedor)
        {
            return vet.Medicamentoes
                .Where(m => m.Proveedor.nombre == nombreProveedor)
                .ToList();
        }
        public List<Medicamento> ConsultarXTipo(string tipo)
        {
            return vet.Medicamentoes
                .Where(m => m.tipo == tipo)
                .ToList();
        }

        public string Actualizar(int idMedicamento, Medicamento medicamento)
        {
            try
            {
                Medicamento med = Consultar(idMedicamento);
                if (med == null)
                {
                    return "No se encontró el medicamento a eliminar";
                }
                med.nombre = medicamento.nombre;
                med.tipo = medicamento.tipo;
                med.precio = medicamento.precio;
                med.proveedor_id = medicamento.proveedor_id;
                vet.Medicamentoes.AddOrUpdate(med);
                vet.SaveChanges();
                return "Se actualizó el medicamento correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idMedicamento)
        {
            try
            {
                Medicamento med = Consultar(idMedicamento);
                if (med == null)
                {
                    return "El medicamento no existe";
                }
                vet.Medicamentoes.Remove(med);
                vet.SaveChanges();
                return "Se eliminó el medicamento correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
