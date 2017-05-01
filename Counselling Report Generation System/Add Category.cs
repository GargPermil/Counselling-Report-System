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

    public partial class Add_Category : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Add_Category()
        {
            InitializeComponent();
        }

        private void Add_Category_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "INSERT INTO COUNSELOR_CATEGORIES (CC_ID, C_ID, NAME, Description) VALUES (@CCID, @CID, @CNAME, @CD)";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            sqlcmd.Parameters.AddWithValue("@CCID", textBox1.Text);
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
                MessageBox.Show("Data inserted Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                
            }
        }
    }
}
