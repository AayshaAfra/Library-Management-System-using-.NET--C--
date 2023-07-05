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
    public partial class frmAddStudent : Form
    {
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSName.Clear();
            txtCNo.Clear();
            txtDepartment.Clear();
            txtEmail.Clear();
            txtEnroll.Clear();
            txtSemester.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSName.Text != "" && txtEnroll.Text != "" && txtDepartment.Text != "" && txtSemester.Text != "" && txtCNo.Text != "" && txtEmail.Text != "")
            {
                String Name = txtSName.Text;
                String Enroll = txtEnroll.Text;
                String Department = txtDepartment.Text;
                String Sem = txtSemester.Text;
                Int64 Mobile = Int64.Parse(txtCNo.Text);
                String Email = txtEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "INSERT INTO tblNewStudent (SName,Enroll,Dep,Sem,Contact,Email) VALUES ('" + Name + "','" + Enroll + "','" + Department + "','" + Sem + "','" + Mobile + "','" + Email + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSName.Clear();
                txtEnroll.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtCNo.Clear();
                txtEmail.Clear();
            }
            else 
            {
                MessageBox.Show("Fill the Empty Fields!", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
