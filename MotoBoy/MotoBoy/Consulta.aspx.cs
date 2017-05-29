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
    public partial class Consulta : System.Web.UI.Page
    {
        

        private double fixo;
        double km;
        double acrescimo;

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarGrid();            
            carregarConfig();
        }

        private void CarregarGrid()
        {
            try
            {
                Banco.conexao.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("select id,nome,endereco,data,(CAST(hora AS VarChar(10)) + ':' + CAST(minutos AS VarChar(10))) 'Hora' from solicitacao where situacao=0", Banco.conexao);
                DataSet ds = new DataSet();
                adaptador.Fill(ds, "Tabela");
                dgvSolicitacao.DataSource = ds;
                dgvSolicitacao.DataBind();
                Banco.conexao.Close();
            }
                
            catch (Exception erro)
            {
                lblAviso2.Text = "ERRO - " + erro;
            }
        }

        //Login do motorista
        protected void bt_Inserir_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand comando = new SqlCommand("select mt.*,us.* from usuarios us inner join motoboys mt on mt.usuario=us.id " +
                                                    " where us.nome=@nome and us.senha=@senha and us.motoboy=1", Banco.conexao);

                comando.Parameters.AddWithValue("@nome", TextBox1.Text);
                comando.Parameters.AddWithValue("@senha", TextBox2.Text);

                Banco.conexao.Open();

                SqlDataReader reg = comando.ExecuteReader();



                if (reg.HasRows)
                {
                    Banco.conexao.Close();
                    Banco.conexao.Open();
                    reg = comando.ExecuteReader();
                    if (reg.Read())
                    {
                        Banco.motoboy = Convert.ToInt32(reg[0].ToString());
                        lblMotoboy.Text = reg[1].ToString();
                        Panel1.Visible = true;
                        TextBox1.Text = TextBox2.Text = "";
                        Banco.conexao.Close();
                        CarregarGrid();
                        carregarSolicitacao();

                        if (txtId.Text != "")
                        {
                            liberar();
                        }
                        else
                        {
                            Bloquear();
                        }
                    }


                }
                else
                {
                    lblAviso.Text = "Usuario ou Senha incorreto!";
                    TextBox1.Text = TextBox2.Text = "";
                    TextBox1.Focus();
                    Banco.conexao.Close();
                }





            }

            catch (Exception erro)
            {
                Banco.conexao.Close();
                lblAviso.Text = "Erro ao Incluir >> " + erro.Message;
                TextBox1.Text = TextBox2.Text = "";
                TextBox1.Focus();


            }
        }

        //
        private void carregarSolicitacao()
        {
            try
            {
                SqlCommand comando = new SqlCommand("select id,nome,endereco,data,(CAST(hora AS VarChar(10)) + ':' + CAST(minutos AS VarChar(10))) 'Hora' from solicitacao where situacao=1 and motoboy=@motoboy", Banco.conexao);
                comando.Parameters.AddWithValue("@motoboy", Convert.ToInt32(Banco.motoboy));

                Banco.conexao.Open();
                SqlDataReader reg = comando.ExecuteReader();

                if (reg.Read())
                {
                    txtId.Text = reg[0].ToString();
                    txtNome.Text = reg[1].ToString();
                    txtEndereco.Text = reg[2].ToString();
                    txtData.Text = reg[3].ToString();
                    txtHora.Text = reg[4].ToString();

                }
                Banco.conexao.Close();

            }

            catch (Exception erro)
            {
                lblAviso2.Text = "ERRO - " + erro;
            }
        }


        protected void btProximo_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand comando = new SqlCommand("update solicitacao set motoboy = 1,situacao=1 where id=(select top 1 id from solicitacao where situacao = 0)", Banco.conexao);


                Banco.conexao.Open();
                comando.ExecuteNonQuery();
                Banco.conexao.Close();
                carregarSolicitacao();
                CarregarGrid();
                liberar();


            }

            catch (Exception erro)
            {
                lblAviso2.Text = "ERRO - " + erro;
            }
        }
        private void liberar()
        {
            txtDistancia.Enabled = true;
            btProximo.Enabled = false;
            btnTerminar.Enabled = true;
        }
        private void Bloquear()
        {
            txtDistancia.Enabled = false;
            btProximo.Enabled = true;
            btnTerminar.Enabled = false;
            Limpar();
        }
        private void Limpar()
        {
            txtId.Text = txtNome.Text = txtPreco.Text = txtHora.Text = txtEndereco.Text = txtDistancia.Text = txtData.Text = "";
        }


        protected void btnTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand comando = new SqlCommand("update solicitacao set distancia=@distancia,preco_viagem=@preco,situacao=2 where id=@id", Banco.conexao);
                comando.Parameters.AddWithValue("@distancia", Convert.ToDouble(txtDistancia.Text));
                comando.Parameters.AddWithValue("@preco", Convert.ToDouble(txtPreco.Text));
                comando.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));

                Banco.conexao.Open();
                comando.ExecuteNonQuery();
                Banco.conexao.Close();
                carregarSolicitacao();
                CarregarGrid();
                Bloquear();


            }

            catch (Exception erro)
            {
                lblAviso2.Text = "ERRO - " + erro;
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

                    fixo = Convert.ToDouble(reg[1].ToString());
                    km = Convert.ToDouble(reg[2].ToString());
                    acrescimo = Convert.ToDouble(reg[3].ToString());

                }
                Banco.conexao.Close();

            }

            catch (Exception erro)
            {
                lblAviso2.Text = "ERRO - " + erro;
            }
        }

        protected void txtDistancia_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            if (txtDistancia.Text == "")
            {
                txtDistancia.Text = "0";
            }

            double valorAdd = 0;
            double distancia = Convert.ToDouble(txtDistancia.Text);
            if (distancia > km)
            {
                valorAdd = (distancia - km) * acrescimo;
            }

            txtPreco.Text = (fixo + valorAdd).ToString();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}