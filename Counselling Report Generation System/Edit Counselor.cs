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
    public partial class Edit_Counselor : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Edit_Counselor()
        {
            InitializeComponent();
        }

        private void Edit_Counselor_Load(object sender, EventArgs e)
        {
            string cmdstr = "SELECT C_ID FROM COUNSELOR";

            try
            {
                SqlCeConnection sqlcon = new SqlCeConnection(constr);
                SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
                SqlCeDataAdapter da = new SqlCeDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                sqlcon.Open();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "C_ID";
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "UPDATE COUNSELOR SET Name=@CN, Address=@CDD, Phone=@CP, Qualification=@CQ, Skill=@CS Where C_ID=@CID";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            sqlcmd.Parameters.AddWithValue("@CID", comboBox1.Text);
            sqlcmd.Parameters.AddWithValue("@CN", textBox2.Text);
            sqlcmd.Parameters.AddWithValue("@CDD", textBox3.Text);
            sqlcmd.Parameters.AddWithValue("@CP", textBox4.Text);
            sqlcmd.Parameters.AddWithValue("@CQ", textBox5.Text);
            sqlcmd.Parameters.AddWithValue("@CS", textBox6.Text);

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
            string cmdstr = "SELECT * FROM COUNSELOR WHERE C_ID = @cid";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);

            sqlcmd.Parameters.AddWithValue("@cid", comboBox1.Text);

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
                    textBox6.Text = sdr[5].ToString();
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
