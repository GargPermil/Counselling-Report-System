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
    public partial class Edit_Candidate : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Edit_Candidate()
        {
            InitializeComponent();
        }

        private void Edit_Candidate_Load(object sender, EventArgs e)
        {
            string cmdstr = "SELECT S_ID FROM CANDIDATE";

            try
            {
                SqlCeConnection sqlcon = new SqlCeConnection(constr);
                SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
                SqlCeDataAdapter da = new SqlCeDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                sqlcon.Open();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "S_ID";
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cmdstr = "SELECT * FROM CANDIDATE WHERE S_ID=@CSID";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);

            sqlcmd.Parameters.AddWithValue("@CSID", comboBox1.Text);

            try
            {
                sqlcon.Open();

                SqlCeDataReader sdr = sqlcmd.ExecuteReader();

                while (sdr.Read())
                {
                    textBox2.Text = sdr[1].ToString();
                    string g = sdr[2].ToString();
                    if (g == "M")
                        radioButton1.Checked = true;
                    else if (g== "F")
                        radioButton2.Checked = true;

                    textBox4.Text = sdr[3].ToString();
                    textBox5.Text = sdr[4].ToString();
                    textBox3.Text = sdr[5].ToString();
                }

                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "UPDATE CANDIDATE SET NAME=@CN, GENDER=@CG, CONTACT=@CC, ADDRESS=@CA, E_MAIL=@CE WHERE S_ID=@CSID";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            sqlcmd.Parameters.AddWithValue("@CSID", comboBox1.Text);
            sqlcmd.Parameters.AddWithValue("@CN", textBox2.Text);
            if (radioButton1.Checked == true)
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
                MessageBox.Show("Data updated Successfully");
            }
        }
    }
}
