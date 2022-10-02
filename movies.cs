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
    public partial class movies : Form
    {
        public movies()
        {
            InitializeComponent();
        }
        public static string movies_name,moviesnum;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            movies_name = linkLabel1.Text;
            moviesnum = "1";
            picture = picture1;
            new cinema().Show();
            this.Hide();
              
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            movies_name = linkLabel2.Text;
            moviesnum = "2";
            picture = picture2;
            new cinema().Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            movies_name = linkLabel3.Text;
            moviesnum = "3";
            picture = picture3;
            new cinema().Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            movies_name = linkLabel4.Text;
            moviesnum = "4";
            picture = picture4;
            new cinema().Show();
            this.Hide();
        }
        string paht = "";
        private void moviespit(string pit)
        {
            string pic = pit;
            paht = "";
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    if (pit[i] == '\\')
                    {
                        paht = paht + "\\";
                    }

                    paht = paht + pic[i];
                }
                catch
                {
                }
            }
            //MessageBox.Show(paht);
        }
        public static string picture;
        string picture1, picture2,picture3, picture4;

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void movies_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM `member2` WHERE โรงหนัง <= 4";
            string coom = "datasource=127.0.0.1;port=3306;username=root;password=;database=movies;";
            MySqlConnection conn = new MySqlConnection(coom);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                moviespit(reader.GetString(3));
               
                if (reader.GetInt32(2) == 1)//อ่านค่าจากdatabase 
                {
                    try
                    {
                        pictureBox1.LoadAsync(reader.GetString(3));
                        picture1 = reader.GetString(3);
                        linkLabel1.Text = reader.GetString(1);
                    }
                    catch
                    {

                    }
                    
                    
                }
                if (reader.GetInt32(2) == 2)
                {
                    try
                    {
                        pictureBox2.LoadAsync(reader.GetString(3));
                        picture2 = reader.GetString(3);
                        linkLabel2.Text = reader.GetString(1);
                    }
                    catch
                    {

                    }

                    
                }
                if (reader.GetInt32(2) == 3)
                {
                    try
                    {
                        pictureBox3.LoadAsync(reader.GetString(3));
                        picture3 = reader.GetString(3);
                        linkLabel3.Text = reader.GetString(1);
                    }
                    catch
                    {

                    }
                    
                }
                if (reader.GetInt32(2) == 4)
                {
                    try
                    {
                        pictureBox4.LoadAsync(reader.GetString(3));
                        picture4 = reader.GetString(3);
                        linkLabel4.Text = reader.GetString(1);
                    }
                    catch
                    {

                    }
                    
                }
            }
        }
    }
}
