using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudEmpleados
{
    public partial class DetallesContactos : Form
    {
        private CapaDeNegocios _capaDeNegocios;
        private Empleados _empleados;

        public DetallesContactos()
        {
            InitializeComponent();
            _capaDeNegocios = new CapaDeNegocios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarContacto();
            this.Close();
            ((Main)this.Owner).ContactosPopulares();
        }
   
        private void GuardarContacto(){
            Empleados empleados = new Empleados();
            empleados.Nombre = txtNombre.Text;
            empleados.Apellido = txtApellido.Text;
            empleados.Telefono = txtTelefono.Text;
            empleados.Direccion = txtDireccion.Text;
            empleados.Email = txtEmail.Text;

            empleados.idempleado = _empleados != null ? _empleados.idempleado : 0;

            _capaDeNegocios.GuardarContacto(empleados);

        }
        public void CargarContacto(Empleados empleados) {
            _empleados = empleados;
        if(empleados != null)
            {
                LimpiarFrom();
                txtNombre.Text = empleados.Nombre;
                txtApellido.Text = empleados.Apellido;
                txtTelefono.Text = empleados.Telefono;
                txtDireccion.Text = empleados.Direccion;
                txtEmail.Text = empleados.Email;
            }
        }
        private void LimpiarFrom()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void DetallesContactos_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
