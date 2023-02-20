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
    public partial class Frm_SistemaLIvros : Form
    {
        public Frm_SistemaLIvros()
        {
            InitializeComponent();
        }
        public void Carregar_Livro()//Crinado Metodo para guardar o comando do banco de dados
        {
            try
            {
                Banco banco = new Banco();
                banco.conectar();

                string sql = "SELECT * FROM livros;";//Mostrando tudo que foi cadastrado na tabela socios

                MySqlCommand cmd = new MySqlCommand(sql, banco.conexao);

                MySqlDataAdapter dados = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                dados.Fill(dt);

                Dvg_Livros.DataSource = dt;

                banco.Desconectar();
            }
            catch
            {

            }
        }

        private void Frm_SistemaLIvros_Load(object sender, EventArgs e)
        {
            Carregar_Livro();
        }

        private void Btn_Adicionar_Click(object sender, EventArgs e)
        {
            Frm_CadastroLivro cadastroLivro = new Frm_CadastroLivro();
            cadastroLivro.Show();
            Hide();
        }

        private void Btn_Voltar_Click(object sender, EventArgs e)
        {
            Frm_Abertura_Biblioteca abertura_Biblioteca = new Frm_Abertura_Biblioteca();
            abertura_Biblioteca.Show();
            Hide();
        }
    }
}
