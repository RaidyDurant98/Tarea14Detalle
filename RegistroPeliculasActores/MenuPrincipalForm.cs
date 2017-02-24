using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroPeliculasActores
{
    public partial class MenuPrincipalForm : Form
    {
        public MenuPrincipalForm()
        {
            InitializeComponent();
        }

        private void peliculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UI.Registros.PeliculasRegistroForm().Show();
        }

        private void actoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UI.Registros.ActoresRegistroForm().Show();
        }

        private void peliculasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new UI.Consultas.ConsultaPeliculasForm().Show();
        }
    }
}
