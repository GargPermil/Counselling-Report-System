using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Counselling_Report_Generation_System
{
    public partial class Login : Form
    {
        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "Select Password from USERS where Name = @Uname";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            
            sqlcmd.Parameters.AddWithValue("@Uname", textBox1.Text);
            string result = "";
            try
            {
                sqlcon.Open();
                result = (string)sqlcmd.ExecuteScalar();
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if ((textBox2.Text != result) || (textBox2.Text ==""))
                MessageBox.Show("Invalid Username/Password");
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Login_Close(object sender, EventArgs e)
        {
            
        }
    }
}
