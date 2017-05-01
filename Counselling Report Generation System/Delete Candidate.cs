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
    public partial class Delete_Candidate : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Delete_Candidate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "DELETE FROM CANDIDATE WHERE S_ID=@UID";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);

            sqlcmd.Parameters.AddWithValue("@UID", comboBox1.Text);

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
                MessageBox.Show("Deleted Created Successfully");
        }

        private void Delete_Candidate_Load(object sender, EventArgs e)
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
    }
}
