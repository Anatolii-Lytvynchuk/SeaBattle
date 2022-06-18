using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class WinPlayerVsBot : Form
    {
        public WinPlayerVsBot()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Hide();
            form1.ShowDialog();
            Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            Hide();
            menu.ShowDialog();
            Close();
        }
    }
}