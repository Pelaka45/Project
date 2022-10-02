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
    public partial class cinema : Form
    {
        public cinema()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            seat.time = checkBox1.Text;
            new seat().Show();
            this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            new movies().Show();
            this.Hide();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            seat.time = checkBox2.Text;
            new seat().Show();
            this.Hide();

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            seat.time = checkBox3.Text;
            new seat().Show();
            this.Hide();
        }
        
        private void cinema1_Load(object sender, EventArgs e)
        {
            pictureBox1.LoadAsync(movies.picture);
            label2.Text= $"โรงภาพยนต์ {movies.moviesnum}";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            seat.time = checkBox4.Text;
            new seat().Show();
            this.Hide();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            seat.time = checkBox4.Text;
            new seat().Show();
            this.Hide();
        }
    }
}
