using RegistroPeliculasActores.DAL;
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
    public partial class PeliculasRegistroForm : Form
    {
        Entidades.Peliculas pelicula;

        public PeliculasRegistroForm()
        {
            InitializeComponent();
            Limpiar();
        }

        private void PeliculasRegistroForm_Load(object sender, EventArgs e)
        {
            LlenarCombo();
        }

        private void Limpiar()
        {
            pelicula = new Entidades.Peliculas();

            peliculaIdTextBox.Clear();
            nombreTextBox.Clear();
            fechaEstrenoDateTimePicker.Value = DateTime.Today;
            //actorComboBox.Text = " ";
            DetalledataGridView.DataSource = null;
            NombreerrorProvider.Clear();

            nombreTextBox.Focus();

            
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(nombreTextBox.Text))
            {
                NombreerrorProvider.SetError(nombreTextBox, "Por favor llenar el campo vacio.");
                return false;
            }

            return true;
        }

        private void LlenarGrid(Entidades.Peliculas pelicula)
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = pelicula.Actor;
        }

        private void LlenarCombo()
        {
            var llenar = new PeliculaActorDb();
            List<Entidades.Actores> lista = BLL.ActoresBLL.GetList();

            actorComboBox.DataSource = lista;
            actorComboBox.DisplayMember = "Nombre";
            actorComboBox.ValueMember = "ActorId";
        }

        private Entidades.Peliculas LlenarCampos()
        {
            string actores = actorComboBox.SelectedValue.ToString();

            pelicula.Nombre = nombreTextBox.Text;
            pelicula.FechaEstreno = fechaEstrenoDateTimePicker.Value;
            pelicula.ActorId = Utilidades.TOINT(actores);
            return pelicula;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                MessageBox.Show("Por favor llenar los campor vacios.");
            }
            else
            {
                pelicula = LlenarCampos();

                if (BLL.PeliculasBLL.Guardar(pelicula))
                {
                    MessageBox.Show("La pelicula se guardo con exito.");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la pelicula.");
                }
            }

            Limpiar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var pelicula = BLL.PeliculasBLL.Buscar(Utilidades.TOINT(peliculaIdTextBox.Text));

            if(pelicula != null)
            {               
                nombreTextBox.Text = pelicula.Nombre;
                fechaEstrenoDateTimePicker.Value = pelicula.FechaEstreno;
                actorComboBox.SelectedValue = pelicula.ActorId;

                LlenarGrid(pelicula);
            }
            else
            {
                MessageBox.Show("No existe ningun usuario con ese id.");
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            var pelicula = BLL.PeliculasBLL.Buscar(Utilidades.TOINT(peliculaIdTextBox.Text));

            if (pelicula != null)
            {
                if (BLL.PeliculasBLL.Eliminar(pelicula))
                    MessageBox.Show("La pelicula se leimino con exito.");
            }
            else
                MessageBox.Show("No se pudo eliminar la pelicula.");

            Limpiar();
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            Entidades.Actores actor = new Entidades.Actores();

            actor = (Entidades.Actores)actorComboBox.SelectedItem;
            pelicula.Actor.Add(actor);

            LlenarGrid(pelicula);
        }

        private void actorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
