using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroPeliculasActores.UI.Consultas
{
    public partial class ConsultaPeliculasForm : Form
    {
        public ConsultaPeliculasForm()
        {
            InitializeComponent();
        }

        private void Filtrarbutton_Click(object sender, EventArgs e)
        {
            if (FiltrarcomboBox.SelectedIndex == 1)
            {
                ListadataGridView.DataSource = BLL.PeliculasBLL.GetList();
            }
            if (FiltrarcomboBox.SelectedIndex == 1)
            {
                ListadataGridView.DataSource = BLL.PeliculasBLL.GetListFecha(DesdedateTimePicker.Value.Date, HastadateTimePicker.Value.Date);
            }
        }
    }
}
