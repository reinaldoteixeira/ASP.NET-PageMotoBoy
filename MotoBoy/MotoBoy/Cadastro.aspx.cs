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

        }
        protected void CarregaGV()
        {
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand("select * from usuarios", Banco.conexao);
            SqlDataReader reg;
            //SqlDataReader data = comando.
    
            dt.Columns.Add("ID", System.Type.GetType("System.String"));
            dt.Columns.Add("Nome", System.Type.GetType("System.String"));
            dt.Columns.Add("Senha", System.Type.GetType("System.String"));
            dt.Columns.Add("ADM", System.Type.GetType("System.String"));
            dt.Columns.Add("Descrição", System.Type.GetType("System.String"));
            Banco.conexao.Open();
            reg = comando.ExecuteReader();
            string placa = "";
            string veiculo = "";
            string nome = "";
            string preco = "";
            string desc = "";
            while (reg.Read())
            {
                placa = reg["Placa"].ToString();
                veiculo = reg["Veículo"].ToString();
                nome = reg["Nome"].ToString();
                preco = reg["Preço"].ToString();
                desc = reg["Descrição"].ToString();
                dt.Rows.Add(new String[] { placa, veiculo, nome, preco, desc });
            }
            Banco.conexao.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}