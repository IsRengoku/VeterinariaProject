using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsPago
    {
        private VeterinariaEntities vet = new VeterinariaEntities();

        private Pago pago { get; set; }


        public string Insertar(Pago newPago)
        {
            try
            {
                vet.Pagoes.Add(newPago);
                vet.SaveChanges();
                return "Se ingresó el pago a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Pago Consultar(int idPago)
        {
            Pago pago = vet.Pagoes.FirstOrDefault(p => p.id == idPago);
            return pago;
        }
        public List<Pago> ConsultarTodos()
        {
            return vet.Pagoes
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idPago, Pago pago)
        {
            try
            {
                Pago pay = Consultar(idPago);
                if (pay == null)
                {
                    return "No se encontró el pago a eliminar";
                }
                pay.costo_total = pago.costo_total;
                pay.descripcion = pago.descripcion;
                pay.servicio_id = pago.servicio_id;
                pay.medicamento_id = pago.medicamento_id;
                vet.Pagoes.AddOrUpdate(pay);
                vet.SaveChanges();
                return "Se actualizó el pago correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idPago)
        {
            try
            {
                Pago pago = Consultar(idPago);
                if (pago == null)
                {
                    return "El pago no existe";
                }
                vet.Pagoes.Remove(pago);
                vet.SaveChanges();
                return "Se eliminó el pago correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
