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
    public partial class Relatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarGrid1();
            CarregarGrid2();
            CarregarGrid3();
        }
        private void CarregarGrid1()
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
                lblAviso.Text = "ERRO - " + erro;
            }
        }

        private void CarregarGrid2()
        {
            try
            {
                Banco.conexao.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("select mo.nome 'Motoboy',so.nome,endereco,data,(CAST(hora AS VarChar(10)) + ':' + CAST(minutos AS VarChar(10))) 'Hora' from solicitacao so inner join motoboys mo on so.motoboy = mo.id where situacao = 1", Banco.conexao);
                DataSet ds = new DataSet();
                adaptador.Fill(ds, "Tabela");
                dgvSolicitacao0.DataSource = ds;
                dgvSolicitacao0.DataBind();
                Banco.conexao.Close();
            }

            catch (Exception erro)
            {
                lblAviso.Text = "ERRO - " + erro;
            }
        }

        private void CarregarGrid3()
        {
            try
            {
                Banco.conexao.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("select mo.nome 'Motoboy',so.preco_viagem 'Valor da viagem',so.nome,endereco,data,(CAST(hora AS VarChar(10)) + ':' + CAST(minutos AS VarChar(10))) 'Hora' from solicitacao so inner join motoboys mo on so.motoboy = mo.id where situacao = 2; ", Banco.conexao);
                DataSet ds = new DataSet();
                adaptador.Fill(ds, "Tabela");
                dgvSolicitacao1.DataSource = ds;
                dgvSolicitacao1.DataBind();
                Banco.conexao.Close();
            }

            catch (Exception erro)
            {
                lblAviso.Text = "ERRO - " + erro;
            }
        }
        protected void dgvSolicitacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}