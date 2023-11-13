using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEmpleados
{
    internal class CapaDeNegocios
    {
        private CapaDeAccesoBD _capaDeAccesoBD;

        public CapaDeNegocios()
        {
            _capaDeAccesoBD = new CapaDeAccesoBD();
        }
        public Empleados GuardarContacto(Empleados empleados)
        {
            if(empleados.idempleado == 0)
            {
                _capaDeAccesoBD.InsertarContacto(empleados);
            }
            else
                _capaDeAccesoBD.ActualizarContacto(empleados);
            return empleados;
        }
        public List<Empleados> TraerContactos(string textoBusqueda = null)
        {
           return _capaDeAccesoBD.TraerContactos(textoBusqueda);
        }
        public void EliminarContacto(int id)
        {
            _capaDeAccesoBD.EliminarContacto(id);
        }
    }
}
