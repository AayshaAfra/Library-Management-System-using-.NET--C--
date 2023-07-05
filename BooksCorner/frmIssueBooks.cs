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
    public partial class frmIssueBooks : Form
    {
        public frmIssueBooks()
        {
            InitializeComponent();
        }

        private void frmIssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand ("select BName from tblNewBook",con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            while(Sdr.Read())
            {
                for(int i = 0; i < Sdr.FieldCount; i++)
                {
                    ComboBoxBooks.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();
        }

        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtEnrollNo.Text != "")
            {
                String eid = txtEnrollNo.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from tblNewStudent where Enroll = '"+eid+"'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                cmd.CommandText = "select COUNT(std_enroll) from tblIBook where std_enroll = '" + eid + "' and book_return_date is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtSName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtCNo.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    txtSName.Clear();
                    txtDepartment.Clear();
                    txtSemester.Clear();
                    txtCNo.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Invalid Enrollment No!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if(txtSName.Text != "")
            {
                if(ComboBoxBooks.SelectedIndex != -1 && count <=2)
                {
                    String enroll = txtEnrollNo.Text;
                    String sname = txtSName.Text;
                    String sdep = txtDepartment.Text;
                    String sem = txtSemester.Text;
                    Int64 contact = Int64.Parse(txtCNo.Text);
                    String email = txtEmail.Text;
                    String bookName = ComboBoxBooks.Text;
                    String BIssueDate = guna2DateTimePicker1.Text;
                    

                    String eid = txtEnrollNo.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = cmd.CommandText = "insert into tblIBook (std_enroll, std_name, std_dep, std_sem, std_contact, std_email, book_name, book_issue_date) values( '" + enroll + "','" + sname + "','" + sdep + "','" + sem + "'," + contact + ",'" + email + "','" + bookName + "','" + BIssueDate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Either Select a book Or Maximum Number of Books Issued!", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Enter Valid Enrollment No!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnrollNo_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrollNo.Text == "")
            {
                txtSName.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtCNo.Clear();
                txtEmail.Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEnrollNo.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
