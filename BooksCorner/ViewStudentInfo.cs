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
    public partial class ViewStudentInfo : Form
    {
        public ViewStudentInfo()
        {
            InitializeComponent();
        }

        private void txtSearchENo_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchENo.Text != "")
            {
                panel1.Visible = false;
                label2.Visible = false;
                Image img = Image.FromFile("C:/Users/User/Desktop/Liberay Management System/search1.gif");
                guna2PictureBox1.Image = img;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from tblNewStudent where Enroll LIKE '"+txtSearchENo.Text+"%' ";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                panel1.Visible = true;
                label2.Visible = true;
                Image img = Image.FromFile("C:/Users/User/Desktop/Liberay Management System/search.gif");
                guna2PictureBox1.Image = img;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from tblNewStudent";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                guna2DataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void ViewStudentInfo_Load(object sender, EventArgs e)
        {
            guna2Panel3.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from tblNewStudent";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        int bid;
        Int64 rowid;

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            guna2Panel3.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from tblNewStudent where StuID = "+bid+" ";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtSName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtEnNo.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSem.Text = ds.Tables[0].Rows[0][4].ToString();
            txtCNo.Text = ds.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Update Data?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String sname = txtSName.Text;
                String eno = txtEnNo.Text;
                String dep = txtDepartment.Text;
                String sem = txtSem.Text;
                Int64 contact = Int64.Parse(txtCNo.Text);
                String email = txtEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                
                cmd.CommandText = "update tblNewStudent set SName = '" + sname + "',Enroll ='" + eno + "',Dep = '" + dep + "',Sem ='" + sem + "',Contact =" + contact + ",Email = '" + email + "' where StuID = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudentInfo_Load(this,null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewStudentInfo_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete Data?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from tblNewStudent where StuID =" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudentInfo_Load(this, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data will be Lost!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
