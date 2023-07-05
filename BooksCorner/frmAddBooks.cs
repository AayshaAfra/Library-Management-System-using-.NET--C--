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
    public partial class frmAddBooks : Form
    {
        public frmAddBooks()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBName.Text != "" && txtAName.Text != "" && txtBPublication.Text != "" && guna2DateTimePicker1.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {
                String BName = txtBName.Text;
                String BAuthor = txtAName.Text;
                String Publication = txtBPublication.Text;
                String PDate = guna2DateTimePicker1.Text;
                Int64 Price = Int64.Parse(txtPrice.Text);
                Int64 Quantity = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=AAYNIZ;Initial Catalog=Library;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "INSERT INTO tblNewBook (BName,BAuthor,BPublisher,BDate,BPrice,BQuantity) VALUES ('" + BName + "','" + BAuthor + "','" + Publication + "','" + PDate + "','" + Price + "','" + Quantity + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAName.Clear();
                txtBName.Clear();
                txtBPublication.Clear();
                txtPrice.Clear();
                txtQuantity.Clear();
                
            }
            else
            {
                MessageBox.Show("Fill The Empty Fields!","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure to Exit?", "Alert!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
