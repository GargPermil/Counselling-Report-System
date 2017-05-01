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
    public partial class Edit_Category : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Edit_Category()
        {
            InitializeComponent();
        }

        private void Edit_Category_Load(object sender, EventArgs e)
        {
            string cmdstr = "SELECT CC_ID FROM COUNSELOR_CATEGORIES";

            try
            {
                SqlCeConnection sqlcon = new SqlCeConnection(constr);
                SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
                SqlCeDataAdapter da = new SqlCeDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                sqlcon.Open();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "CC_ID";
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cmdstr = "SELECT * FROM COUNSELOR_CATEGORIES WHERE CC_ID=@CCID";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);

            sqlcmd.Parameters.AddWithValue("@CCID", comboBox1.Text);

            try
            {
                sqlcon.Open();

                SqlCeDataReader sdr = sqlcmd.ExecuteReader();

                while (sdr.Read())
                {
                    textBox2.Text = sdr[1].ToString();
                    textBox3.Text = sdr[2].ToString();
                    textBox4.Text = sdr[3].ToString();
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
            string cmdstr = "UPDATE COUNSELOR_CATEGORIES SET C_ID=@CID, NAME=@CNAME, Description=@CD WHERE CC_ID=@CCID";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);

            sqlcmd.Parameters.AddWithValue("@CCID", comboBox1.Text);
            sqlcmd.Parameters.AddWithValue("@CID", textBox2.Text);
            sqlcmd.Parameters.AddWithValue("@CNAME", textBox3.Text);
            sqlcmd.Parameters.AddWithValue("@CD", textBox4.Text);

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
