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
    public partial class Edit_Appointment : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Edit_Appointment()
        {
            InitializeComponent();
        }

        private void Edit_Appointment_Load(object sender, EventArgs e)
        {
            string cmdstr = "SELECT AP_ID FROM APPOINTMENT";

            try
            {
                SqlCeConnection sqlcon = new SqlCeConnection(constr);
                SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
                SqlCeDataAdapter da = new SqlCeDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                sqlcon.Open();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "AP_ID";
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "UPDATE APPOINTMENT SET S_ID=@ASID, C_ID=@ACID, AP_DATE=@AD, USER_ID=@AUID, TOPIC=@AT WHERE AP_ID=@AID";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            sqlcmd.Parameters.AddWithValue("@AID", comboBox1.Text);
            sqlcmd.Parameters.AddWithValue("@ASID", textBox2.Text);
            sqlcmd.Parameters.AddWithValue("@ACID", textBox3.Text);
            sqlcmd.Parameters.AddWithValue("@AD", textBox4.Text);
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
                MessageBox.Show("Data updated Successfully");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cmdstr = "SELECT * FROM APPOINTMENT WHERE AP_ID = @sid";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);

            sqlcmd.Parameters.AddWithValue("@sid", comboBox1.Text);

            try
            {
                sqlcon.Open();

                SqlCeDataReader sdr = sqlcmd.ExecuteReader();

                while (sdr.Read())
                {
                    textBox2.Text = sdr[1].ToString();
                    textBox3.Text = sdr[2].ToString();
                    textBox4.Text = sdr[3].ToString();
                    textBox5.Text = sdr[4].ToString();
                    textBox7.Text = sdr[5].ToString();
                }

                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
