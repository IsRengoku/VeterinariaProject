using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsCliente
    {
        private Veterinaria1Entities vet = new Veterinaria1Entities();

        private Cliente cliente { get; set; }


        public string Insertar(Cliente newCliente)
        {
            try
            {
                vet.Clientes.Add(newCliente);
                vet.SaveChanges();
                return "Se ingresó el cliente a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Cliente Consultar(int idCliente)
        {
            Cliente cli = vet.Clientes.FirstOrDefault(p => p.id == idCliente);
            return cli;
        }
        public List<Cliente> ConsultarTodos()
        {
            return vet.Clientes
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idCliente, Cliente cliente)
        {
            try
            {
                Cliente cli = Consultar(idCliente);
                if (cli == null)
                {
                    return "No se encontró el cliente a eliminar";
                }
                cli.nombre = cliente.nombre;
                cli.telefono = cliente.telefono;
                cli.email = cliente.email;
                cli.direccion = cliente.direccion;
                cli.documento = cliente.documento;
                vet.Clientes.AddOrUpdate(cli);
                vet.SaveChanges();
                return "Se actualizó el cliente correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idCliente)
        {
            try
            {
                Cliente cli = Consultar(idCliente);
                if (cli == null)
                {
                    return "El cliente no existe";
                }
                vet.Clientes.Remove(cli);
                vet.SaveChanges();
                return "Se eliminó el cliente correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
