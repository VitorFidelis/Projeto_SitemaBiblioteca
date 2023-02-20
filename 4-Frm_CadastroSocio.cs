using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;//Permitir que use comandos do banco de dados

namespace Projeto_SitemaBiblioteca
{
    public partial class frm_CadastroSocio : Form
    {
        public frm_CadastroSocio()
        {
            InitializeComponent();
        }
        private void Variaveis_Socio()//Metodo para as variaveis do Frm_Socio
        {
            VariaveisGlobal.email = Txt_Email.Text;
            VariaveisGlobal.nome = Txt_Nome.Text;
            VariaveisGlobal.idade = int.Parse(Txt_Idade.Text);
            VariaveisGlobal.endereco = Txt_Endereco.Text;
            VariaveisGlobal.bairro = Txt_Bairro.Text;
            VariaveisGlobal.cep = MKD_Cep.Text;
            VariaveisGlobal.rg = MKD_RG.Text;
            VariaveisGlobal.cpf = MKD_CPF.Text;
            VariaveisGlobal.celular = MKD_Celular.Text;
        }

        public void Adicionar_Socio()//Criando Método para Cadastrar Sócio
        {
            try
            {
                Banco banco = new Banco();//Instanciando o objeto banco da classe Banco
                banco.conectar();

                string sql = "INSERT INTO socio(id_Socio,Nome,Idade,Endereco,Bairro,CEP,RG,CPF,Celular,Email)" +
                    "VALUES(DEFAULT,@Nome,@Idade,@Endereco,@Bairro,@CEP,@RG,@CPF,@Celular,@Email);";//Salvando os dados na Tabela Socios

                MySqlCommand cmd = new MySqlCommand(sql, banco.conexao);//Instanciando um objeto que excuta o comando INSERT

                //Enviando as informações das variaveis para as colunas do Banco de Dados
                cmd.Parameters.AddWithValue("@Nome", VariaveisGlobal.nome);
                cmd.Parameters.AddWithValue("@Idade", VariaveisGlobal.idade);
                cmd.Parameters.AddWithValue("@Endereco", VariaveisGlobal.endereco);
                cmd.Parameters.AddWithValue("@Bairro", VariaveisGlobal.bairro);
                cmd.Parameters.AddWithValue("@CEP", VariaveisGlobal.cep);
                cmd.Parameters.AddWithValue("@RG", VariaveisGlobal.rg);
                cmd.Parameters.AddWithValue("@CPF", VariaveisGlobal.cpf);
                cmd.Parameters.AddWithValue("@Celular", VariaveisGlobal.celular);
                cmd.Parameters.AddWithValue("@Email", VariaveisGlobal.email);

                cmd.ExecuteNonQuery();//Vai executar tudo o que foi programado nas linhas de comando a cima 
                banco.Desconectar();

                MessageBox.Show("Sócio Cadastrado Com Sucesso!!!", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar o Sócio...\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//LIberando a tecla enter 
            {
                //Aceitar somente esses endereços de E-mail
                if (Txt_Email.Text.Contains("@gmail.com") || Txt_Email.Text.Contains("@hotmail.com")
                    || Txt_Email.Text.Contains("@outlook.com") || Txt_Email.Text.Contains("@yahoo.com"))
                {
                    Variaveis_Socio();//Metodo Criado do Frm_Socio
                    Txt_Nome.Focus();//Cursor descer para o Txt_Nome
                }
                else
                {
                    MessageBox.Show("Digte um E-mail valido:" + " \n " + " 1-@gmail.com" + " \n " + " 2-@hotmail.com" + " \n " + " 3-@outlook.com" + " \n " + " @yahoo.com", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_Email.Focus();//Cursor continua no Txt_Nome
                    Txt_Email.Clear();//Limpra a Txt_Email
                }
            }
        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            Variaveis_Socio();
            Adicionar_Socio();

            Frm_SistemaSocio sistemaSocio = new Frm_SistemaSocio();
            sistemaSocio.Show();
            Hide();
        }

        private void Txt_Nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Somente Letras.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == 13)
            {
                if (Txt_Nome.Text != "")
                {
                    Variaveis_Socio();
                    Txt_Idade.Clear();
                    Txt_Idade.Focus();
                }
                else
                {
                    MessageBox.Show("Você não informou nenhum nome ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_Nome.Focus();
                    Txt_Nome.Clear();
                }

            }

        }

        private void Txt_Idade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Somente Números", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == 13)
            {
                if (Txt_Idade.Text != "")
                {
                    if (int.Parse(Txt_Idade.Text) >= 18)
                    {
                        Variaveis_Socio();
                        Txt_Endereco.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Para ser Sócio é necessario ser maior de idade.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Txt_Idade.Focus();
                        Txt_Idade.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Você não informou a sua idade", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_Endereco.Focus();
                    Txt_Endereco.Clear();
                }
            }
        }

        private void Txt_Bairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Somente Letras", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == 13)
            {
                if (Txt_Bairro.Text != "")
                {
                    Variaveis_Socio();
                    MKD_Cep.Focus();
                }
                else
                {
                    MessageBox.Show("Você não informou nehum Bairro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_Bairro.Focus();
                    Txt_Bairro.Clear();
                }
            }
        }

        private void MKD_Cep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (MKD_Cep.MaskCompleted == true)
                {
                    Variaveis_Socio();
                    MKD_RG.Focus();
                }
                else
                {
                    MessageBox.Show("Você não informou nenhum CEP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MKD_Cep.Clear();
                    MKD_Cep.Focus();
                }
            }
        }

        private void MKD_RG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (MKD_RG.MaskCompleted == true)
                {
                    Variaveis_Socio();
                    MKD_CPF.Focus();
                }
                else
                {
                    MessageBox.Show("Você não informou nehum RG.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MKD_RG.Clear();
                    MKD_RG.Focus();
                }
            }
        }

        private void MKD_CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (MKD_CPF.MaskCompleted == true)
                {
                    Variaveis_Socio();
                    MKD_Celular.Focus();
                }
                else
                {
                    MessageBox.Show("Não foi Informado nenhum CPF", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MKD_CPF.Clear();
                    MKD_CPF.Focus();
                }
            }
        }

        private void MKD_Celular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (MKD_Celular.MaskCompleted == true)
                {
                    Variaveis_Socio();
                    Btn_Salvar.Visible = true;
                }
                else
                {
                    MessageBox.Show("Não foi informado nenhum número de celular", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MKD_Celular.Clear();
                    MKD_Celular.Focus();
                }
            }
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Txt_Endereco_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Somente Letras e Números", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == 13)
            {
                if (Txt_Endereco.Text != "")
                {
                    Variaveis_Socio();
                    Txt_Bairro.Focus();
                }
                else
                {
                    MessageBox.Show("Você não informou nenhum Endereço", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_Endereco.Focus();
                    Txt_Endereco.Clear();
                }
            }
        }

        private void Btn_Limpar_Click(object sender, EventArgs e)
        {
            // Limpa as TextBox //
            Txt_CodigoSocio.Clear();
            Txt_Email.Clear();
            Txt_Nome.Clear();
            Txt_Idade.Clear();
            Txt_Endereco.Clear();
            Txt_Bairro.Clear();
            MKD_Cep.Clear();
            MKD_RG.Clear();
            MKD_CPF.Clear();
            MKD_Celular.Clear();
            
          // Volta o cursor para o E-mail //
            Txt_Email.Focus();

        }
    }
}
     
