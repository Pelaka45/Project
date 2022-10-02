using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  

namespace cinema
{
    public partial class Form1 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            

            

        }

        public static string globalname, globalphone,id;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {

                MessageBox.Show("กรุณากรอกข้อมูล", "ERROR !!!");

            }
            else if (textBox2.Text.Length != 10)
            {
                MessageBox.Show("กรุณากรอกเบอร์โทรให้ถูกต้อง");
            }
            else
            {
                globalname = textBox1.Text;
                globalphone = textBox2.Text;
                MySqlConnection conn = databaseConnection();
                String sql = "INSERT INTO member1 (name,phone) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("กรอกข้อมูลสำเร็จ");

                }
                sql = "SELECT * FROM `member1` ";
                string coom = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
                conn = new MySqlConnection(coom);
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader.GetString(0);
                }
                new movies().Show();
                this.Hide();

            }
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" || textBox2.Text == "12345")
            {

                MessageBox.Show("กรอกข้อมูลสำเร็จ");
                new Admin().Show();
                this.Hide();
                  
            }
            else
            {
                MessageBox.Show("ไม่สามารถเข้าสู่ระบบแอดมินได้");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            



        }
    }
    
}
