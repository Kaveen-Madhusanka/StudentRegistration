using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace WindowsFormsApplication1
{   
   public class controller
    {
       Dbconnection db;
       private String name;
       private String password;
       private int id;

       public string getname() {

           return this.name;

       }
       public void setname(String pname)
       {
           this.name = pname;
       
       }
       public string getpassword()
       {

           return this.password;

       }
       public void setpassword(String ppassword)
       {
           this.password = ppassword;

       }

       public int getid()
       {

           return this.id;

       }
       public void setid(int pid)
       {
           this.id = pid;

       }


       public void insertdata() {
           db = new Dbconnection();
           SqlCommand cmd = new SqlCommand("insert into login values('" +name+ "','" +password+ "'," +id+ ")", db.con);
           db.con.Open();
           cmd.ExecuteNonQuery();
           MessageBox.Show("inserted");
        

       }

 
    }

  
}
