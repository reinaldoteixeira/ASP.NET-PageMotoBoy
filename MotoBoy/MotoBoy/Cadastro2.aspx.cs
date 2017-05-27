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
    public partial class Cadastro2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                       
          
            SqlCommand comando = new SqlCommand("insert into motoboys values(@nome,@placa,@telefone)", Banco.conexao);
            comando.Parameters.AddWithValue("@nome", txtNome.Text);
            comando.Parameters.AddWithValue("@placa", txtPlaca.Text);
            comando.Parameters.AddWithValue("@telefone", txtTelefone.Text);

            Banco.conexao.Open();
            comando.ExecuteNonQuery();
            Banco.conexao.Close();

            lblAviso.Text = "Usuario Inserido com sucesso!!";
            limparCampos();

        }
        private void limparCampos()
        {
            txtNome.Text = txtPlaca.Text = txtId.Text = txtTelefone.Text = "";
        }
    }
}