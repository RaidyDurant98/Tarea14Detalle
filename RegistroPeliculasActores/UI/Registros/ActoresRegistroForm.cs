using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroPeliculasActores.UI.Registros
{
    public partial class ActoresRegistroForm : Form
    {
        public ActoresRegistroForm()
        {
            InitializeComponent();
        }

        private void ActoresRegistroForm_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            actorIdTextBox.Clear();
            nombreTextBox.Clear();
            NombreErrorProvider.Clear();

            nombreTextBox.Focus();
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(nombreTextBox.Text))
            {
                NombreErrorProvider.SetError(nombreTextBox, "Porfavor llenar el campo vacio.");
                return false;
            }
            return true;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Entidades.Actores actor = new Entidades.Actores();

            if (!Validar())
            {
                MessageBox.Show("Por favor llenar los campos vacios.");
            }
            else
            {
                actor.ActorId = Utilidades.TOINT(actorIdTextBox.Text);
                actor.Nombre = nombreTextBox.Text;

                if (BLL.ActoresBLL.Guardar(actor))
                {
                    MessageBox.Show("El actor se guardo con exito.");
                }
                else
                    MessageBox.Show("No se pudo guardar el actor.");
            }

            Limpiar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var actor = BLL.ActoresBLL.Buscar(Utilidades.TOINT(actorIdTextBox.Text));

            if (actor != null)
            {
                nombreTextBox.Text = actor.Nombre;
            }
            else
            {
                MessageBox.Show("No existe ningun actor con ese id.");
            }
        }
    }
}
