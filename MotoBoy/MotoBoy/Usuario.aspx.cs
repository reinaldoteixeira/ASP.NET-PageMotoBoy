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
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Inserir_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand comando = new SqlCommand("select * from usuarios where nome=@nome and senha=@senha", Banco.conexao);

                comando.Parameters.AddWithValue("@nome", TextBox1.Text);
                comando.Parameters.AddWithValue("@senha", TextBox2.Text);

                Banco.conexao.Open();

                SqlDataReader reg = comando.ExecuteReader();

                if (reg.HasRows)
                {
                    
                    Response.Redirect("Cadastro.aspx");
                    
                }
                else
                {
                    lblAviso.Text = "Usuario ou Senha incorreto!";
                    TextBox1.Text = TextBox2.Text = "";
                    TextBox1.Focus();
                }


                Banco.conexao.Close();


            }

            catch (Exception erro)
            {

                lblAviso.Text = "Erro ao Incluir >> " + erro.Message;
                TextBox1.Text = TextBox2.Text = "";
                TextBox1.Focus();


            }   
        }
    }
}