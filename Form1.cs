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

namespace POSV1._9
{
    public partial class Form1 : Form
    {
        string ConnectionString = @"Data Source=WIN-NKF4P1JLCQQ\SQLEXPRESS;Initial Catalog=db_pos;Integrated Security=True;Encrypt=False";
        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO tbl_productlist VALUES(@productName,@CategoryID, @ExpirationDate, @Price, @Stock)", conn))
                {

                    command.Parameters.AddWithValue("@productName", txtBox0.Text);
                    command.Parameters.AddWithValue("@CategoryID", txtBox1.Text);
                    command.Parameters.AddWithValue("@Stock", txtBox2.Text);
                    command.Parameters.AddWithValue("@Price", txtBox3.Text);
                    command.Parameters.AddWithValue("@ExpirationDate", txtBox4.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Added Successfully");
                    load();
                }
            }

        }


        private void load()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM tbl_productlist", conn))
                {
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        dataGridView1.Rows.Clear();
                        while (read.Read())
                        {

                            dataGridView1.Rows.Add(read["productID"],
                                read["productName"].ToString(),
                                read["CategoryID"].ToString(),

                                read["Stock"].ToString(),
                                 read["Price"].ToString(),
                                read["ExpirationDate"].ToString());
                            {



                            }
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        private void txtBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
