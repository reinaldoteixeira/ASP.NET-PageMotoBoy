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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtAcrescimo.Text == "" || txtFixo.Text == "" || txtKm.Text == "")
            {
                carregarConfig();
            }
                

        }
        private void carregarConfig()
        {
            try
            {

                SqlCommand comando = new SqlCommand("select * from configuracao where id = 1 ", Banco.conexao);

                Banco.conexao.Open();
                SqlDataReader reg = comando.ExecuteReader();
               
                if (reg.Read())
                {
                    txtFixo.Text = reg[1].ToString();
                    txtKm.Text = reg[2].ToString();
                    txtAcrescimo.Text = reg[3].ToString();
                    
                }

                Banco.conexao.Close();

            }

            catch (Exception erro)
            {
                
            }
        }
        protected void bt_Inserir_Click(object sender, EventArgs e)
        {
            
        }

        protected void bt_Login_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand comando = new SqlCommand("update configuracao  set preco_fixo=@preco_fixo,Apartir=@Apartir,preco_km=@preco_km where id = 1 ", Banco.conexao);
                comando.Parameters.AddWithValue("@preco_fixo",Convert.ToDouble(txtFixo.Text));
                comando.Parameters.AddWithValue("@Apartir", Convert.ToDouble(txtKm.Text));
                comando.Parameters.AddWithValue("@preco_km", Convert.ToDouble(txtAcrescimo.Text));

                Banco.conexao.Open();
                comando.ExecuteNonQuery();
                Banco.conexao.Close();

                lblAviso.Text = "Configuração Salva";

            }

            catch (Exception erro)
            {
                lblAviso.Text = "Erro - " + erro;
            }
        }
    }
}