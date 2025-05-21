using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsProveedor
    {
        private Veterinaria1Entities vet = new Veterinaria1Entities();

        private Proveedor proveedor { get; set; }


        public string Insertar(Proveedor newProveedor)
        {
            try
            {
                vet.Proveedors.Add(newProveedor);
                vet.SaveChanges();
                return "Se ingresó el proveedor a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Proveedor Consultar(int idProveedor)
        {
            Proveedor proveedor = vet.Proveedors.FirstOrDefault(p => p.id == idProveedor);
            return proveedor;
        }
        public List<Proveedor> ConsultarTodos()
        {
            return vet.Proveedors
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idProveedor, Proveedor proveedor)
        {
            try
            {
                Proveedor prov = Consultar(idProveedor);
                if (prov == null)
                {
                    return "No se encontró el proveedor a actualizar";
                }
                prov.nombre = proveedor.nombre;
                prov.contacto = proveedor.contacto;
                prov.telefono = proveedor.telefono;
                prov.email = proveedor.email;
                vet.Proveedors.AddOrUpdate(prov);
                vet.SaveChanges();
                return "Se actualizó el proveedor correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idProveedor)
        {
            try
            {
                Proveedor prov = Consultar(idProveedor);
                if (prov == null)
                {
                    return "El proveedor no existe";
                }
                vet.Proveedors.Remove(prov);
                vet.SaveChanges();
                return "Se eliminó el proveedor correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
