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
    public partial class Delete_Category : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Delete_Category()
        {
            InitializeComponent();
        }

        private void Delete_Category_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "DELETE FROM COUNSELOR_CATEGORIES WHERE CC_ID=@UID";
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
    }
}
