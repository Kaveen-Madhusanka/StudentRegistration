using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //SqlConnection con =new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Student1;Integrated Security=True");
        Dbconnection db;


        public Form1()
        {
            InitializeComponent();
        }

        private void savedata_Click(object sender, EventArgs e)
        {
            db= new Dbconnection();


            if (txtname.TextLength == 0 || txtpassword.TextLength == 0 || txtid.TextLength == 0)
            {

                MessageBox.Show("null values ara not allowd");

            }
            else
            {


                        try
                        {
                            SqlCommand cmd = new SqlCommand("insert into login values('" + txtname.Text + "','" + txtpassword.Text + "'," + txtid.Text + ")", db.con);
                            db.con.Open();
                            //String name = Convert.ToString(cmd.ExecuteScalar());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("inserted");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error" + ex.Message);
                        }
                        finally
                        {
                            db.con.Close();

                        }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db = new Dbconnection();
            SqlDataAdapter adp = new SqlDataAdapter("select * from login",db.con);
            db.con.Open();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            db.con.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            db = new Dbconnection();
            SqlCommand cmd = new SqlCommand("delete from login where userid = '"+txtid.Text+"'  ",db.con);
            db.con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted");
            db.con.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            db = new Dbconnection();
            SqlCommand cmd = new SqlCommand("update login set userName='"+txtname.Text+"',password='"+txtpassword.Text+"'  where userid = '" + txtid.Text + "'  ", db.con);
            db.con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated");
            db.con.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            db = new Dbconnection();
            SqlDataAdapter adp = new SqlDataAdapter("select * from login where userid = '" + txtid.Text + "'  ", db.con);
            db.con.Open();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            db.con.Close();
            

        }

        private void contrl_Click(object sender, EventArgs e)
        {

            controller c1 = new controller();
            c1.setname(txtname.Text);
            c1.setpassword(txtpassword.Text);
            c1.setid(Convert.ToInt16(txtid.Text));
            c1.insertdata();
            
        }
    }
}
