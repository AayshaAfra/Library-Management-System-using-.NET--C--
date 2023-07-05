using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksCorner
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueBooks ibs = new frmIssueBooks();
            ibs.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure you want to Exit?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddBooks abs = new frmAddBooks();
            abs.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewBooks vb  = new frmViewBooks();
            vb.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddStudent ast = new frmAddStudent();
            ast.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudentInfo vsi = new ViewStudentInfo();
            vsi.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnBook rtb = new frmReturnBook();
            rtb.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompleteBookDetails cbd = new frmCompleteBookDetails();
            cbd.Show();
        }
    }
}
