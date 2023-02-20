using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//Para usar a linguagem de Banco de Dados na programação C#
using System.Windows.Forms;//Usando os comandos do forme

namespace Projeto_SitemaBiblioteca
{
    public class Banco//Todos os forms terão acesso a Classe Banco
    {
        //Criando a String de conexão com a localização do Banco de Dados
        string BD = "SERVER=localhost;USER=root;DATABASE=biblioteca";

        //Criando a conexão com o Banco de Dados
        public MySqlConnection conexao;

        //Criando o Método Conectar
        public void conectar()
        {
            //Se a tentaiva de conexão for verdadeira
            try
            {
                //Recebendo a localização do nosso banco de dados
                conexao = new MySqlConnection(BD);
                conexao.Open();//Abrindo o Banco de Dados
            }
            catch //Se ocorrer falha de conexão
            {
                MessageBox.Show("Erro ao Tentar Fazer Conexão com o Banco de Dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Criando o Método Desconectar
        public void Desconectar()
        {
            try
            {
                conexao = new MySqlConnection(BD);
                conexao.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao Tentar Desconectar o Banco de Dados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
