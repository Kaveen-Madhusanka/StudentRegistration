using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace WindowsFormsApplication1
{
   public class Dbconnection
    {
       
        public static String connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Student1;Integrated Security=True";
        public SqlConnection con = new SqlConnection(connectionString);
       

          public Dbconnection() {
              
          }
          

    }
}
