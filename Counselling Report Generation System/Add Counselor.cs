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
    public partial class Add_Counselor : Form
    {

        static string constr = Properties.Settings.Default.MyDatabase_1ConnectionString;

        public Add_Counselor()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Add_Counselor_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = "INSERT INTO COUNSELOR (C_ID, Name, Address, Phone, Qualification, Skill) VALUES (@CID, @CN, @CDD, @CP, @CQ, @CS)";
            SqlCeConnection sqlcon = new SqlCeConnection(constr);
            SqlCeCommand sqlcmd = new SqlCeCommand(cmdstr, sqlcon);
            sqlcmd.Parameters.AddWithValue("@CID", textBox1.Text);
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
                MessageBox.Show("Data inserted Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
