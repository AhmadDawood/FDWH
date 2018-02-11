using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDW_BI
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();   
        }
        private void revenueFactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            revenueAnalysisForm frevenue = new revenueAnalysisForm();
            frevenue.MdiParent = this;
            frevenue.Show(); 
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();  
        }
        private void expenseFactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExpAnalysis formExpAnalysis = new FormExpAnalysis();
            formExpAnalysis.MdiParent = this;
            formExpAnalysis.Show();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Shows ChangePassword Form.
            changePasswordForm chPwForm = new changePasswordForm();
            chPwForm.ShowDialog(this);
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox aboutbox = new AboutBox();
            aboutbox.MdiParent = this;
            aboutbox.Show();
        }
        private void customiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQryBuilder fqb = new fQryBuilder();
            fqb.MdiParent = this;
            fqb.Show();
        }
    }
}
