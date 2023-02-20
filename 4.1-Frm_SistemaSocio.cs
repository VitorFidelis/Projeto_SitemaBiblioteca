using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_SitemaBiblioteca
{
    public partial class Frm_SistemaSocio : Form
    {
        public Frm_SistemaSocio()
        {
            InitializeComponent();
        }

        public void Carregar_Socios()//Crinado Metodo para guardar o comando do banco de dados
        {
            try
            {
                Banco banco = new Banco();
                banco.conectar();

                string sql = "SELECT * FROM socio;";//Mostrando tudo que foi cadastrado na tabela socios

                MySqlCommand cmd = new MySqlCommand(sql, banco.conexao);

                MySqlDataAdapter dados = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                dados.Fill(dt);

                Dvg_CadastroSocio.DataSource = dt;

                banco.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro ao Carregar a Lista de Sócio...", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Frm_SistemaSocio_Load(object sender, EventArgs e)
        {
            Carregar_Socios();
        }

        private void Btn_Voltar_Click(object sender, EventArgs e)
        {
            Frm_Abertura_Biblioteca abertura_Biblioteca = new Frm_Abertura_Biblioteca();
            abertura_Biblioteca.Show();
            Hide();
        }

        private void Btn_Adicionar_Click(object sender, EventArgs e)
        {
            frm_CadastroSocio cadastroSocio = new frm_CadastroSocio();
            cadastroSocio.Show();
            Hide();
        }
    }
}


