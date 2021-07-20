using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ModernLogin1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data;Data Source=db_user.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();


        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void clearFields_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassWord.Text = "";
            txtUserName.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = " SELECT * FROM tbl_user WHERE Username= '" + txtUserName.Text + "' and Password '" + txtPassWord.Text + "'";
            cmd = new OleDbCommand(login,con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new InventoryDashboard().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Invalid Username and/or Password. Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Text = "";
                txtPassWord.Text = "";
                txtUserName.Focus();
            }
        }

        private void showPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassWord.Checked)
            {
                txtPassWord.PasswordChar = '\0';
            }
            else
            {
                txtPassWord.PasswordChar = '*';
            }
        }

        private void txtConPassWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FrmRegister().Show();
            this.Hide();
        }
    }
}
