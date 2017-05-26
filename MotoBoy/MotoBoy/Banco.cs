using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace MotoBoy
{
    

    public class Banco
    {
        public static SqlConnection  conexao  = new SqlConnection(@"");
        public  SqlCommand comando = new SqlCommand("",conexao);

                
    }


   
}