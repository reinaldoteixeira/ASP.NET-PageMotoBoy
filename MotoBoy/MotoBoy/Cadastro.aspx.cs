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
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            if(txtSenha.Text != txtConfirmarSenha.Text)
            {
                lblAviso.Text = "Os campos senha e confirmar senha são diferentes";
                return;
            }

            int motoboy = 0;
            if (CheckBox1.Checked == true)
            {
                motoboy = 1;
            }
            else
            {
                motoboy = 0;
            }

            SqlCommand comando = new SqlCommand("insert into usuarios values(@nome,@senha,"+  motoboy.ToString() + ")" , Banco.conexao);
            comando.Parameters.AddWithValue("@nome", txtNome.Text);
            comando.Parameters.AddWithValue("@senha", txtSenha.Text);

            Banco.conexao.Open();
            comando.ExecuteNonQuery();
            Banco.conexao.Close();

            lblAviso.Text = "Usuario Inserido com sucesso!!";
            limparCampos();
        }
        private void limparCampos()
        {
            txtConfirmarSenha.Text = txtNome.Text = txtId.Text = txtSenha.Text = "";
        }
        protected void CarregaGV()
        {

            
    
        }
    }
}