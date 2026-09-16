using SistemaNomina.Models;
using System.Collections.Generic;

namespace SistemaNomina.Data
{
    public class EmpleadoRepository
    {
        private List<Empleado> empleados;

        public EmpleadoRepository()
        {
            empleados = new List<Empleado>();
        }

        public void Agregar(Empleado empleado)
        {
            empleados.Add(empleado);
        }

        public List<Empleado> ObtenerTodos()
        {
            return empleados;
        }

        public Empleado BuscarPorNSS(string nss)
        {
            Empleado encontrado = null;

            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].NumeroSeguroSocial == nss)
                {
                    encontrado = empleados[i];
                    break;
                }
            }

            return encontrado;
        }
    }
}