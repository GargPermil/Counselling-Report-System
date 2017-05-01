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
    public partial class Counseling_Report : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Counseling_Report()
        {
            InitializeComponent();
        }

        private void Counseling_Report_Load(object sender, EventArgs e)
        {
            string cmdstr = "SELECT R_ID FROM COUNSEL_REPORT";

            try
            {
                SqlCeConnection sqlcon = new SqlCeConnection(constr);
                SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
                SqlCeDataAdapter da = new SqlCeDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                sqlcon.Open();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "R_ID";
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "SELECT * FROM COUNSEL_REPORT WHERE R_ID=@RID";
            string cmdstr3 = "SELECT S_ID FROM APPOINTMENT WHERE AP_ID=@AID";
            string cmdstr2 = "SELECT S_ID, Name FROM Candidate WHERE S_ID = @sid";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);

            sqlcmd.Parameters.AddWithValue("@RID",comboBox1.Text);
            try
            {
                sqlcon.Open();

                SqlCeDataReader sdr = sqlcmd.ExecuteReader();

                while (sdr.Read())
                {
                    label8.Text = sdr[1].ToString();
                    label5.Text = sdr[2].ToString();
                    textBox1.Text = sdr[3].ToString();
                    textBox2.Text = sdr[4].ToString();
                }

                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                sqlcon.Open();
                SqlCeCommand scmd3 = new SqlCeCommand(cmdstr3, sqlcon);
                scmd3.Parameters.AddWithValue("@AID", label8.Text);
                string sid = scmd3.ExecuteScalar().ToString();
                SqlCeCommand sqlcmd2 = new SqlCeCommand(cmdstr2, sqlcon);
                sqlcmd2.Parameters.AddWithValue("@sid", sid);
                SqlCeDataReader sdr = sqlcmd2.ExecuteReader();

                while (sdr.Read())
                {
                    label6.Text = sdr[0].ToString();
                    label7.Text = sdr[1].ToString();
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
