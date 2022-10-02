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
    public partial class seat : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }
        public seat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new cinema().Show();
            this.Hide();
        }

        private void seat1_Load(object sender, EventArgs e)
        {
            b1.BackColor = Color.LawnGreen;
            b4.BackColor = Color.LawnGreen;
            b5.BackColor = Color.LawnGreen;
            b6.BackColor = Color.LawnGreen;
            b7.BackColor = Color.LawnGreen;
            b8.BackColor = Color.LawnGreen;
            b3.BackColor = Color.LawnGreen;
            b2.BackColor = Color.LawnGreen;
            b9.BackColor = Color.LawnGreen;
            b10.BackColor = Color.LawnGreen;
            b11.BackColor = Color.LawnGreen;
            b12.BackColor = Color.LawnGreen;
            b13.BackColor = Color.LawnGreen;
            b14.BackColor = Color.LawnGreen;
            b15.BackColor = Color.LawnGreen;
            string sql = $"SELECT * FROM `member1` WHERE time='{time}' and movies_name='{movies.movies_name}'";
            string coom = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
            MySqlConnection conn = new MySqlConnection(coom);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                if (reader.GetString(4) == "A1")
                {
                    b1.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "A2")
                {
                    b2.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "A3")
                {
                    b3.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "A4")
                {
                    b4.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "A5")
                {
                    b5.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "A6")
                {
                    b6.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "A7")
                {
                    b7.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "B1")
                {
                    b8.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "B2")
                {
                    b9.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "B3")
                {
                    b10.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "B4")
                {
                    b11.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "B5")
                {
                    b12.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "C1")
                {
                    b13.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "C2")
                {
                    b14.BackColor = Color.Red;
                }
                if (reader.GetString(4) == "C3")
                {
                    b15.BackColor = Color.Red;
                }

            }
            ////////////////////////////////////////
            label1.Text = movies.moviesnum;
            label2.Text = $"โรงภาพยนต์ที่ {movies.moviesnum}";
            label3.Text = movies.movies_name;
            
        }

        int raka = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (b1.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b1.BackColor = Color.Red;
                    textBox1.Text += b1.Text +' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }

            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b1.BackColor = Color.LawnGreen;

                    textBox1.Text = textBox1.Text.Replace(b1.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }




            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (b2.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b2.BackColor = Color.Red;
                    textBox1.Text += b2.Text +' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b2.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b2.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (b3.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    b3.BackColor = Color.Red;
                textBox1.Text += b3.Text + ' ';
                raka += 100;
                textBox2.Text = $"{raka}";
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b3.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b3.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (b4.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b4.BackColor = Color.Red;
                    textBox1.Text += b4.Text + ' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b4.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b4.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (b5.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b5.BackColor = Color.Red;
                    textBox1.Text += b5.Text + ' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b5.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b5.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (b6.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b6.BackColor = Color.Red;
                    textBox1.Text += b6.Text + ' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b6.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b6.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (b7.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b7.BackColor = Color.Red;
                    textBox1.Text += b7.Text + ' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b7.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b7.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (b8.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    b8.BackColor = Color.Red;
                    textBox1.Text += b8.Text + ' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b8.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b8.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (b9.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b9.BackColor = Color.Red;
                    textBox1.Text += b9.Text + ' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b9.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b9.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (b10.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    b10.BackColor = Color.Red;
                textBox1.Text += b10.Text + ' ';
                raka += 100;
                textBox2.Text = $"{raka}";
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b10.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b10.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (b11.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {


                    b11.BackColor = Color.Red;
                    textBox1.Text += b11.Text + ' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b11.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b11.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (b12.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b12.BackColor = Color.Red;
                    textBox1.Text += b12.Text +' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {

                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b12.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b12.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (b13.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b13.BackColor = Color.Red;
                    textBox1.Text += b13.Text + ' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }

            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b13.BackColor = Color.LawnGreen;

                    textBox1.Text = textBox1.Text.Replace(b13.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";

                }

            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (b14.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b14.BackColor = Color.Red;
                    textBox1.Text += b14.Text + ' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b14.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b14.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (b15.BackColor == Color.LawnGreen)
            {
                if (MessageBox.Show("คูณต้องการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b15.BackColor = Color.Red;
                    textBox1.Text += b15.Text + ' ';
                    raka += 100;
                    textBox2.Text = $"{raka}";
                }
            }
            else
            {
                if (MessageBox.Show("คูณต้องยกเลิกการจองที่นั่งนี้ใช่หรือไม่", "Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    b15.BackColor = Color.LawnGreen;
                    textBox1.Text = textBox1.Text.Replace(b15.Text, "");
                    raka -= 100;
                    textBox2.Text = $"{raka}";
                }
            }

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public static string seat_, price, time;
        private void button2_Click(object sender, EventArgs e)
        {
            seat.seat_ = textBox1.Text;
            seat.price = textBox2.Text;
            MySqlConnection conn = databaseConnection();
            String sql = $"UPDATE member1 set movies_name = '{movies.movies_name}',seat = '{seat.seat_}',time = '{seat.time}',โรงหนัง = '{movies.moviesnum}' WHERE id = '{Form1.id}' and phone = '{Form1.globalphone}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);


            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                new check1().Show();
                this.Hide();

            }

        }
    }
}
