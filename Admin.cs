using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinema
{
    public partial class Admin : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Show(string sql)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            DataSet ds = new DataSet();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            new MySqlDataAdapter(cmd).Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        string filename;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.gif; *.png;";//การกดเลือกรูปจากไฟล์ในเครื่อง//

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();//บันทึกชื่อหนัง ประเภท เวลา//
            String sql = "INSERT INTO member2 (name_movie,โรงหนัง,picture) VALUES('" + textBox2.Text + "','5','" + filename.Replace("\\","\\\\") + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("กรอกข้อมูลสำเร็จ");
                comboBox1.Items.Clear();//เมื่อกรอกข้อมูลสำเร็จ ค่าข้างในcomboboxจะถูกเคลียร์ออก
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox9.Items.Clear();
                Admin_Show("SELECT * FROM member2");//นำตารางmember2จากdatabaseมาแสดงในdatagrid

                string sql_ = "SELECT * FROM `member2`";
                string coom = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
                MySqlConnection conn_ = new MySqlConnection(coom);
                MySqlCommand cmd_ = new MySqlCommand(sql_, conn_);
                conn_.Open();
                MySqlDataReader reader = cmd_.ExecuteReader();

                while (reader.Read())//ทำลูปเพื่ออ่านค่า//
                {
                    //อ่านค่าว่าเท่ากับตำแหน่งนั้นหรือไม่ ถ้าเท่ากับก็จะแสดงชื่อหนังตรงcombobox 
                    if (reader.GetInt32(2) == 1)
                    {
                        comboBox1.Text = reader.GetString(1);
                    }
                    if (reader.GetInt32(2) == 2)
                    {
                        comboBox2.Text = reader.GetString(1);
                    }
                    if (reader.GetInt32(2) == 3)
                    {
                        comboBox3.Text = reader.GetString(1);
                    }
                    if (reader.GetInt32(2) == 4)
                    {
                        comboBox4.Text = reader.GetString(1);
                    }
                    //การเก็บชื่อหนังที่อยู่ตำแหน่งที่1ในdatabaseมาไว้ในcom
                    comboBox1.Items.Add(reader.GetString(1));
                    comboBox2.Items.Add(reader.GetString(1));
                    comboBox3.Items.Add(reader.GetString(1));
                    comboBox4.Items.Add(reader.GetString(1));
                    comboBox9.Items.Add(reader.GetString(1));
                }
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            //เป็นการแสดงdatagrid จากdatabase member2 ทุกครั้งที่เปิดหน้าadmin
            Admin_Show("SELECT * FROM member2");
        }

        private void Admin_Shown(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM `member2`";
            string coom = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
            MySqlConnection conn = new MySqlConnection(coom);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
               
                if (reader.GetInt32(2) == 1)
                {
                    comboBox1.Text = reader.GetString(1);
                }
                if (reader.GetInt32(2) == 2)
                {
                    comboBox2.Text = reader.GetString(1);
                }
                if (reader.GetInt32(2) == 3)
                {
                    comboBox3.Text = reader.GetString(1);
                }
                if (reader.GetInt32(2) == 4)
                {
                    comboBox4.Text = reader.GetString(1);
                }
                comboBox1.Items.Add(reader.GetString(1));
                comboBox2.Items.Add(reader.GetString(1));
                comboBox3.Items.Add(reader.GetString(1));
                comboBox4.Items.Add(reader.GetString(1));
                comboBox9.Items.Add(reader.GetString(1));
            }

        }

        private void button3_Click(object sender, EventArgs e)
        { //คำสั่งที่เป็นการเพิ่มโรงหนังเมื่อเพิ่มหนังเข้ามา4เรื่องแล้ว เมื่อเพิ่มหนังเรื่องต่อไป หนังจะอยู่โรงที่5ทันที่เพื่อจะไม่ให้ไปแสดงในโรงที่1-4จนกว่าเราจะเลือกโรงที่จะให้หนังฉาย
            MySqlConnection conn_ = databaseConnection();
            String sql_ = $"UPDATE `member2` SET `โรงหนัง` = '5'";
            MySqlCommand cmd_ = new MySqlCommand(sql_, conn_);

            conn_.Open();
            int rows = cmd_.ExecuteNonQuery();
            conn_.Close();
            if (rows > 0)
            {

                //เป็นคำสั่งการอัพเดตหนังแต่ละเรื่องว่าจะให้อยู่โรงไหน
            }
            conn_ = databaseConnection();
            sql_ = $"UPDATE `member2` SET `โรงหนัง` = '{comboBox5.Text}' WHERE `name_movie` = '{comboBox1.Text}'";
            cmd_ = new MySqlCommand(sql_, conn_);
            MessageBox.Show(sql_);
            conn_.Open();
            rows = cmd_.ExecuteNonQuery();
            conn_.Close();
            if (rows > 0)
            {


            }
            conn_ = databaseConnection();
            sql_ = $"UPDATE `member2` SET `โรงหนัง` = '{comboBox6.Text}' WHERE `name_movie` = '{comboBox2.Text}'";
            cmd_ = new MySqlCommand(sql_, conn_);

            conn_.Open();
            rows = cmd_.ExecuteNonQuery();
            conn_.Close();
            if (rows > 0)
            {


            }
            conn_ = databaseConnection();
            sql_ = $"UPDATE `member2` SET `โรงหนัง` = '{comboBox7.Text}' WHERE `name_movie` = '{comboBox3.Text}'";
            cmd_ = new MySqlCommand(sql_, conn_);

            conn_.Open();
            rows = cmd_.ExecuteNonQuery();
            conn_.Close();
            if (rows > 0)
            {


            }
            conn_ = databaseConnection();
            sql_ = $"UPDATE `member2` SET `โรงหนัง` = '{comboBox8.Text}' WHERE `name_movie` = '{comboBox4.Text}'";
            cmd_ = new MySqlCommand(sql_, conn_);

            conn_.Open();
            rows = cmd_.ExecuteNonQuery();
            conn_.Close();
            if (rows > 0)
            {


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=movies;");
            string sql = "DELETE FROM member2 WHERE id = '" + delId + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if(rows > 0)
            {
                MessageBox.Show("ลบรายการสำเร็จ");
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox9.Items.Clear();
                Admin_Show("SELECT * FROM member2");

                string sql_ = "SELECT * FROM `member2`";
                string coom = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
                MySqlConnection conn_ = new MySqlConnection(coom);
                MySqlCommand cmd_ = new MySqlCommand(sql_, conn_);
                conn_.Open();
                MySqlDataReader reader = cmd_.ExecuteReader();

                while (reader.Read())
                {

                    if (reader.GetInt32(2) == 1)
                    {
                        comboBox1.Text = reader.GetString(1);
                    }
                    if (reader.GetInt32(2) == 2)
                    {
                        comboBox2.Text = reader.GetString(1);
                    }
                    if (reader.GetInt32(2) == 3)
                    {
                        comboBox3.Text = reader.GetString(1);
                    }
                    if (reader.GetInt32(2) == 4)
                    {
                        comboBox4.Text = reader.GetString(1);
                    }
                    comboBox1.Items.Add(reader.GetString(1));
                    comboBox2.Items.Add(reader.GetString(1));
                    comboBox3.Items.Add(reader.GetString(1));
                    comboBox4.Items.Add(reader.GetString(1));
                    comboBox9.Items.Add(reader.GetString(1));

                }
            }
            
        }
        string delId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                delId = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
            }
            catch
            {

           }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            DataSet ds = new DataSet();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM `member1` WHERE `movies_name` = '{comboBox9.Text}'";
            new MySqlDataAdapter(cmd).Fill(ds);
            conn.Close();
            dataGridView2.DataSource = ds.Tables[0];
            
            string sql_ = $"SELECT * FROM `member1` WHERE `movies_name` = '{comboBox9.Text}'";
            string coom = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
            MySqlConnection conn_ = new MySqlConnection(coom);
            MySqlCommand cmd_ = new MySqlCommand(sql_, conn_);
            conn_.Open();
            MySqlDataReader reader = cmd_.ExecuteReader();
            int num=0;
            while (reader.Read())
            {
                num += 1;
            }
            label6.Text = $"{num}";
            label5.Text = $"{num*100}";
       }
    }
}
