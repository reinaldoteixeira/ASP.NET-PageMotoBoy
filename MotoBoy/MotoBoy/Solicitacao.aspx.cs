using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace MotoBoy
{
    public partial class Solicitacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Inserir_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand comando = new SqlCommand("insert into solicitacao (nome,endereco) values (@nome, @endereco)", Banco.conexao);

                comando.Parameters.AddWithValue("@nome", TextBox1.Text);
                comando.Parameters.AddWithValue("@endereco", TextBox2.Text);

                Banco.conexao.Open();
                comando.ExecuteNonQuery();
                Banco.conexao.Close();
                Label3.Text = "Registro Inserido com Sucesso!";
                TextBox1.Text = TextBox2.Text = "";
                TextBox1.Focus();
            }

            catch (Exception erro)
            {

                Label3.Text = "Erro ao Incluir >> " + erro.Message;
                TextBox1.Text = TextBox2.Text = "";
                TextBox1.Focus();
                

            }

        }
    }
}