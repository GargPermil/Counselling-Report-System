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
    public partial class Add_Candidate : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Add_Candidate()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "INSERT INTO CANDIDATE (S_ID, NAME, GENDER, CONTACT, ADDRESS, E_MAIL) VALUES (@CSID, @CN, @CG, @CC, @CA, @CE)";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            sqlcmd.Parameters.AddWithValue("@CSID", textBox1.Text);
            sqlcmd.Parameters.AddWithValue("@CN", textBox2.Text);
            if(radioButton1.Checked == true)
                sqlcmd.Parameters.AddWithValue("@CG", "M");
            else if (radioButton2.Checked == true)
                sqlcmd.Parameters.AddWithValue("@CG", "F");
            else
                sqlcmd.Parameters.AddWithValue("@CG", "T");
            sqlcmd.Parameters.AddWithValue("@CC", textBox4.Text);
            sqlcmd.Parameters.AddWithValue("@CA", textBox5.Text);
            sqlcmd.Parameters.AddWithValue("@CE", textBox3.Text);

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
                MessageBox.Show("Data inserted Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }
    }
}
