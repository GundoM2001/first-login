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
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }


        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data;Data Source=db_user.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" && txtPassWord.Text == "" && txtConPassWord.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK);
            }
            else if(txtPassWord.Text == txtConPassWord.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_user VALUES ('" + txtUserName.Text + "','" + txtPassWord.Text + "')";
                cmd = new OleDbCommand(register,con);
                cmd.ExecuteNonQuery();
                con.Close();

                txtUserName.Text = "";
                txtPassWord.Text = "";
                txtConPassWord.Text = "";

                MessageBox.Show("Your account has been Successfully Created!","Registration Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Passwords do not match. Please Re-enter your password", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassWord.Text = "";
                txtConPassWord.Text = "";
                txtPassWord.Focus();
            }
            
        }


        private void showPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassWord.Checked)
            {
                txtPassWord.PasswordChar = '\0';
                txtConPassWord.PasswordChar = '\0';

            }
            else
            {
                txtPassWord.PasswordChar = '*';
                txtConPassWord.PasswordChar = '*';

            }
        }

        private void clearFields_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassWord.Text = "";
            txtConPassWord.Text = "";
            txtUserName.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

    }
    
}
