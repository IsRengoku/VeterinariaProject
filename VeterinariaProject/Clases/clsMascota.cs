using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.Clases
{
        public class clsMascota
    {
        private VeterinariaEntities vet = new VeterinariaEntities();

        private Mascota mascota { get; set; }


        public string Insertar(Mascota newMascota)
        {
            try
            {
                vet.Mascotas.Add(newMascota);
                vet.SaveChanges();
                return "Se ingresó la mascota a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Mascota Consultar(int idMascota)
        {
            Mascota mas = vet.Mascotas.FirstOrDefault(p => p.id == idMascota);
            return mas;
        }
        public List<Mascota> ConsultarTodos()
        {
            return vet.Mascotas
                .OrderBy(m => m.id)
                .ToList();
        }

        public string Actualizar(int idMascota, Mascota mascota)
        {
            try
            {
                Mascota mas = Consultar(idMascota);
                if (mas == null)
                {
                    return "No se encontró la Sede a eliminar";
                }
                mas.nombre = mascota.nombre;
                mas.especie = mascota.especie;
                mas.raza = mascota.raza;
                mas.edad = mascota.edad;
                mas.sexo = mascota.sexo;
                mas.cliente_id = mascota.cliente_id;
                mas.sede_id = mascota.sede_id;
                vet.Mascotas.AddOrUpdate(mas);
                vet.SaveChanges();
                return "Se actualizó la mascota correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idMascota)
        {
            try
            {
                Mascota mas = Consultar(idMascota);
                if (mas == null)
                {
                    return "La mascota no existe";
                }
                vet.Mascotas.Remove(mas);
                vet.SaveChanges();
                return "Se eliminó la mascota correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
