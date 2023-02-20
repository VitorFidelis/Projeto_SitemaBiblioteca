using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;//Permitindo que use comandos do Banco de Dados

namespace Projeto_SitemaBiblioteca
{
    public partial class Frm_CadastroLivro : Form
    {
        public Frm_CadastroLivro()
        {
            InitializeComponent();
        }
        private void Variaveis_Livro()//Metodo para as variaveis do Frm_Livros
        {
            VariaveisGlobal.titulo = Txt_Titulo.Text;
            VariaveisGlobal.categoria = Txt_Categoria.Text;
            VariaveisGlobal.autor = Txt_Autor.Text;
            VariaveisGlobal.editor = Txt_Editor.Text;
            VariaveisGlobal.ano = int.Parse(Txt_Ano.Text);
            VariaveisGlobal.classificacao = int.Parse(Txt_Classificacao.Text);
        }
        private void Adicionar_Livros()//Adicionando metodo para cadastrar livros
        {
            try
            {
                Banco banco = new Banco();//Instanciando o objeto banco da classe Banco
                banco.conectar();//Conectando o Banco de Dados

                string sql = "INSERT INTO livros(id_Livros,Titulo,Categoria,Autor,Editor,Ano,Classificacao_Idade)" +
                    "VALUES(DEFAULT,@Titulo,@Categoria,@Autor,@Editor,@Ano,@Classificacao_Idade);";//Salvando os dados na tabela livro

                MySqlCommand cmd = new MySqlCommand(sql, banco.conexao);//Instanciando um objeto que exuta o comando INSERT

                //Enviando as informações das variaveis para as colunas do Banco de Dados

                cmd.Parameters.AddWithValue("@Titulo", VariaveisGlobal.titulo);
                cmd.Parameters.AddWithValue("@Categoria", VariaveisGlobal.categoria);
                cmd.Parameters.AddWithValue("@Autor", VariaveisGlobal.autor);
                cmd.Parameters.AddWithValue("@Editor", VariaveisGlobal.editor);
                cmd.Parameters.AddWithValue("@Ano", VariaveisGlobal.ano);
                cmd.Parameters.AddWithValue("@Classificacao_Idade", VariaveisGlobal.editor);

                cmd.ExecuteNonQuery();//Vai executar tudo o que foi programado nas linhas de comando a cima 
                banco.Desconectar();

                MessageBox.Show("Livro Cadastrado Com Sucesso!!", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar o Livro...\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_Limpar_Click(object sender, EventArgs e)
        {
            // Limpa as informações //
            Txt_Titulo.Clear();
            Txt_Categoria.Clear();
            Txt_Autor.Clear();
            Txt_Editor.Clear();
            Txt_Ano.Text.Clone();
            Txt_Classificacao.Clear();
            Txt_CodigoLivro.Clear();
            // Volta o cursor para o titulo //
            Txt_Titulo.Focus();
        }

        private void Txt_Titulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Somente Letras!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == 13)
            {
                if (Txt_Titulo.Text != "")
                {
                    Variaveis_Livro();
                    Txt_Categoria.Focus();
                }
                else
                {
                    MessageBox.Show("Você não informou nenhum titulo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void Txt_Categoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Somente Letras", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == 13)
            {
                if (Txt_Categoria.Text != "")
                {
                    Variaveis_Livro();
                    Txt_Autor.Focus();
                }
                else
                {
                    MessageBox.Show("Você não informou a categoria do Livro escolhido", "AViso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Txt_Autor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Soemnte Lestras", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == 13)
            {
                if (Txt_Autor.Text != "")
                {
                    Variaveis_Livro();
                    Txt_Editor.Focus();
                }
                else
                {
                    MessageBox.Show("Você não informou o nome do autor do livro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Txt_Editor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Soemnte Letras", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == 13)
            {
                if (Txt_Editor.Text != "")
                {
                    Variaveis_Livro();
                    Txt_Classificacao.Clear();
                    Txt_Classificacao.Focus();
                }
                else
                {
                    MessageBox.Show("Você não informou o nome do Editor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_Editor.Clear();
                    Txt_Editor.Focus();
                }
            }
        }

        private void Txt_Classificacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) &&!char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Soemnte Números", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == 13)
            {
                if (Txt_Categoria.Text != "")
                {
                    Variaveis_Livro();
                    Txt_Ano.Clear();
                    Txt_Ano.Focus();
                }
                else
                {
                    MessageBox.Show("Você não informou a classificação", "Avsio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_Classificacao.Clear();
                    Txt_Classificacao.Focus();
                }
            }
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Txt_Ano_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Somente Números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == 13)
            {
                if (Txt_Ano.Text != "")
                {
                    Variaveis_Livro();
                    Btn_Salvar.Visible = true;
                }
                else
                {
                    MessageBox.Show("Você não informou nenhum Ano.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_Ano.Clear();
                    Txt_Ano.Focus();
                }
            }
        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            Variaveis_Livro();
            Adicionar_Livros();

            Frm_SistemaLIvros sistemaLIvros = new Frm_SistemaLIvros();
            sistemaLIvros.Show();
            Hide();
        }
    }
}