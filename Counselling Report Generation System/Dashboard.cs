using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Counselling_Report_Generation_System
{
    public partial class Dashboard : Form
    {

        bool _login = false;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Form frm = new Login();
            if (frm.ShowDialog() == DialogResult.OK)
              _login = true;
            else
                Application.Exit();

        }

        void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Form FRM = new Login();
            FRM.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Delete_User();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Add_Candidate();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form frm = new Edit_Candidate();
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form frm = new Delete_Candidate();
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form frm = new Add_Appointment();
            frm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form frm = new Edit_Appointment();
            frm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form frm = new Delete_Appointment();
            frm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form frm = new Add_Counselor();
            frm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form frm = new Edit_Counselor();
            frm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form frm = new Delete_Counselor();
            frm.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form frm = new Add_Category();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form frm = new Edit_Category();
            frm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form frm = new Delete_Category();
            frm.Show();
        }

        private void vIewToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Add_User();
                frm.ShowDialog();
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Edit_User();
                frm.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Delete_User();
                frm.ShowDialog();
            }
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Add_Candidate();
                frm.ShowDialog();
            }
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Edit_Candidate();
                frm.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Delete_Candidate();
                frm.ShowDialog();
            }
        }

        private void newToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Add_Appointment();
                frm.ShowDialog();
            }
        }

        private void editToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Edit_Appointment();
                frm.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Delete_Appointment();
                frm.ShowDialog();
            }
        }

        private void newToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Add_Counselor();
                frm.ShowDialog();
            }
        }

        private void editToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Edit_Counselor();
                frm.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Delete_Counselor();
                frm.ShowDialog();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Add_Category();
                frm.ShowDialog();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Edit_Counselor();
                frm.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Delete_Counselor();
                frm.ShowDialog();
            }
        }

        private void couselingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logoutToolStripMenuItem.Text == "&Logout")
            {
                _login = false;
                MessageBox.Show("Logged Out");
                logoutToolStripMenuItem.Text = "&Login";
            }
            else
            {
                Form frm = new Login();
                if (frm.ShowDialog() == DialogResult.OK)
                    _login = true;
                else
                    Application.Exit();
                logoutToolStripMenuItem.Text = "&Logout";
            }
        }

        private void viewToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Counseling_Report();
                frm.ShowDialog();
            }
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_login == false)
                MessageBox.Show("Please Login to use this feature");
            else
            {
                Form frm = new Create_Counseling_Report();
                frm.ShowDialog();
            }
        }
    }
}
