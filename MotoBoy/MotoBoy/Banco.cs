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
        public static SqlConnection  conexao  = new SqlConnection(@"Data Source=DESKTOP-IHRFUSH;Initial Catalog=bd_motoboy;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                
    }


   
}