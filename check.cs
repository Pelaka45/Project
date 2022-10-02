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
    public partial class check1 : Form
    {
        public check1()
        {
            InitializeComponent();
        }

        private void check_Shown(object sender, EventArgs e)
        {
            label5.Text = $"โรงภาพยนต์ที่ {movies.moviesnum}";
            textBox1.Text = movies.movies_name;
            label1.Text = seat.seat_;
            label2.Text = seat.price;
            label3.Text = seat.time;
        }

        private void check_Load(object sender, EventArgs e)
        {

        }
    }
}
