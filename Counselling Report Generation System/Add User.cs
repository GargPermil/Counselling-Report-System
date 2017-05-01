using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Counselling_Report_Generation_System
{
    public partial class Add_User : Form
    {
        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Add_User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cmdstr = "INSERT INTO USERS (User_ID, Name, Password) VALUES (@UID, @UN, @UPASS)";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            sqlcmd.Parameters.AddWithValue("@UID", textBox3.Text);
            sqlcmd.Parameters.AddWithValue("@UN", textBox1.Text);
            sqlcmd.Parameters.AddWithValue("@UPASS", textBox2.Text);
            
            int result = 0;

            try
            {
                sqlcon.Open();
                result = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (result == 1)
            {
                MessageBox.Show("New User Created Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                
            }
        }
    }
}
