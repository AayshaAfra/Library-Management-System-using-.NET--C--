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
    public partial class frmReturnBook : Form
    {
        public frmReturnBook()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
           

            cmd.CommandText = "select * from tblIBook where std_enroll = '"+ txtEnterEnroll.Text + "' and book_return_date IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if(ds.Tables[0].Rows.Count != 0)
            {
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or No Book Issued!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReturnBook_Load(object sender, EventArgs e)
        {
            guna2Panel4.Visible = false;
            txtEnterEnroll.Clear();
        }

        String bname;
        String bdate;
        Int64 rowid;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2Panel4.Visible = true;

            if(guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = guna2DataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = guna2DataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtName.Text = bname;
            txtIDate.Text = bdate;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd.CommandText = "update tblIBook set book_return_date = '" + guna2DateTimePicker1.Text + "' where std_enroll = '"+txtEnterEnroll.Text+"' and ID = "+rowid+"";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Book Returned Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmReturnBook_Load(this, null);
        }

        private void txtEnterEnroll_TextChanged(object sender, EventArgs e)
        {
            if(txtEnterEnroll.Text == "")
            {
                guna2Panel4.Visible = false;
                guna2DataGridView1.DataSource = null;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEnterEnroll.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            guna2Panel4.Visible = false;
        }
    }
}
