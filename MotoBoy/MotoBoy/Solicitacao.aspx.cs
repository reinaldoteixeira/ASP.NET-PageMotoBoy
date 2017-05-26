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
            SqlCommand comando = new SqlCommand("insert into usuarios", Banco.conexao);

            comando.Parameters.AddWithValue("@nome", TextBox1.Text);
            comando.Parameters.AddWithValue("@endereco", TextBox2.Text);

            Banco.conexao.Open();
        }
    }
}