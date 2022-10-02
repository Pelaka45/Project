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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataTable dt1 = new DataTable();
        private void Admin_Show(string sql)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            new MySqlDataAdapter(cmd).Fill(dt);
            conn.Close();
            dt1 = dt;
            //dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.DataSource = dt;
        }
        

           
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Admin_Show("SELECT * FROM member1");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Admin_Show("SELECT * FROM member1 WHERE name LIKE "+"'" + "%" + textBox1.Text + "%" + "'");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var dv = new DataView(dt1);
            dv.RowFilter = $"name LIKE '%{textBox1.Text}%' ";
            dataGridView1.DataSource = dv;
        }
    }
}
