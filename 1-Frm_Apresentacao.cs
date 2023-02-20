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
    public partial class Frm_Apresentacao : Form
    {
        public Frm_Apresentacao()
        {
            InitializeComponent();
        }

        private void Tmr_Apresentacao_Tick(object sender, EventArgs e)
        {
            Tmr_Apresentacao.Start();//Inicia o timer.
            Tmr_Apresentacao.Stop();//Para o timer no intervalo programado.
            Frm_Abertura_Biblioteca abertura_Biblioteca = new Frm_Abertura_Biblioteca();//Abre o forme abertura depois da apresentação.
            abertura_Biblioteca.Show();//Abre o forme Abertura.
            Hide();//Esconde o forme apresentação.
         
        }
    }
}
