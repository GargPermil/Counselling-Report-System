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
    public partial class Add_Appointment : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Add_Appointment()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Add_Appointment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "INSERT INTO APPOINTMENT (AP_ID, S_ID, C_ID, AP_DATE, USER_ID, TOPIC) VALUES (@AID, @ASID, @ACID, @AD, @AUID, @AT)";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            sqlcmd.Parameters.AddWithValue("@AID", textBox1.Text);
            sqlcmd.Parameters.AddWithValue("@ASID", textBox2.Text);
            sqlcmd.Parameters.AddWithValue("@ACID", textBox3.Text);
            sqlcmd.Parameters.AddWithValue("@AD", dateTimePicker1.Value);
            sqlcmd.Parameters.AddWithValue("@AUID", textBox5.Text);
            sqlcmd.Parameters.AddWithValue("@AT", textBox7.Text);

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
                textBox5.Text = "";
                textBox7.Text = "";
            }
        }
    }
}
