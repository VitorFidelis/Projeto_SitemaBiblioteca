using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SitemaBiblioteca
{
    public partial class Frm_Abertura_Biblioteca : Form
    {
        public Frm_Abertura_Biblioteca()
        {
            InitializeComponent();
        }

        private void Btn_Livro_Click(object sender, EventArgs e)
        {
            Frm_SistemaLIvros sistemaLIvros = new Frm_SistemaLIvros();
            sistemaLIvros.Show();
            Hide();
        }

        private void Btn_Socio_Click(object sender, EventArgs e)
        {
            Frm_SistemaSocio sistemaSocio = new Frm_SistemaSocio();
            sistemaSocio.Show();
            Hide();
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
