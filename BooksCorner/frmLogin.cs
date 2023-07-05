using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksCorner
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
        }

        private void txtPW_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPW.Text == "Password")
            {
                txtPW.Clear();
                txtPW.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (this.txtPW.Text == "" || this.txtUsername.Text == "")
            {
                MessageBox.Show("Please enter Username And Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string cs = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();

                    string sql = "SELECT * FROM tblLogin";
                    SqlCommand com = new SqlCommand(sql, con);

                    SqlDataReader dr = com.ExecuteReader();
                    int flag = 0;
                    while (dr.Read())
                    {
                        if (this.txtUsername.Text == dr.GetValue(1).ToString() && this.txtPW.Text == dr.GetValue(2).ToString())
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 1)
                    {
                        Dashboard frm = new Dashboard();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtPW.Clear();
                        this.txtUsername.Clear();
                    }
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Oops!Something went wrong.Please try again Later", "Error", MessageBoxButtons.OK);

                }
            }
        }
    }
}

        



                  
    

