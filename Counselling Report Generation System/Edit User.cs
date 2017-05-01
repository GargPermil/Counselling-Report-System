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
    public partial class Edit_User : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Edit_User()
        {
            InitializeComponent();
        }

        private void Edit_User_Load(object sender, EventArgs e)
        {
            string cmdstr = "SELECT User_ID FROM USERS";

            try
            {
                SqlCeConnection sqlcon = new SqlCeConnection(constr);
                SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
                SqlCeDataAdapter da = new SqlCeDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                sqlcon.Open();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "User_ID";
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cmdstr = "SELECT * FROM USERS WHERE USER_ID = @uid";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);

            sqlcmd.Parameters.AddWithValue("@uid", comboBox1.Text);

            try
            {
                sqlcon.Open();

                SqlCeDataReader sdr = sqlcmd.ExecuteReader();

                while (sdr.Read())
                {
                    textBox1.Text = sdr[1].ToString();
                    textBox2.Text = sdr[2].ToString();
                }

                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cmdstr = "UPDATE USERS SET NAME=@UN, Password=@UP Where User_ID=@UID";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            sqlcmd.Parameters.AddWithValue("@UID", comboBox1.Text);
            sqlcmd.Parameters.AddWithValue("@UN", textBox1.Text);
            sqlcmd.Parameters.AddWithValue("@UP", textBox2.Text);

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
