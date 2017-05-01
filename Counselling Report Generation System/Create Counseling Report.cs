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
    public partial class Create_Counseling_Report : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Create_Counseling_Report()
        {
            InitializeComponent();
        }

        private void Create_Counseling_Report_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "INSERT INTO COUNSEL_REPORT (R_ID, AP_ID, R_DATE, Requirement, Comment) VALUES (@GRID, @GAPID, @GRD, @GR, @GC)";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            sqlcmd.Parameters.AddWithValue("@GRID", textBox3.Text);
            sqlcmd.Parameters.AddWithValue("@GAPID", textBox6.Text);
            sqlcmd.Parameters.AddWithValue("@GRD", dateTimePicker1.Value);
            sqlcmd.Parameters.AddWithValue("@GR", textBox1.Text);
            sqlcmd.Parameters.AddWithValue("@GC", textBox2.Text);

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
                MessageBox.Show("Report inserted Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }
    }
}
