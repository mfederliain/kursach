using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace kurs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("h:mm:ss");

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            button1.Visible = true;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            button1.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            newTournament createTour = new newTournament();
            createTour.Show();
            createTour.TopMost = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            team teamf = new team();
            teamf.Show();
            teamf.TopMost = true;
            this.TopMost = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button7.Visible = true;
            button8.Visible = true;
            button2.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            add_match_schd addmatch = new add_match_schd();
            addmatch.Show();
            addmatch.TopMost = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            match match = new match();
            match.Show();
            match.TopMost = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            change_info_tournament changeInfo = new change_info_tournament();
            changeInfo.Show();
            changeInfo.TopMost = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kabinet kab = new kabinet();
            kab.Show();
            kab.TopMost = true;

        }
    }
}