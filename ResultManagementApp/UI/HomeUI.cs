using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultManagementApp.UI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void classEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassEntryUI classEntryForm = new ClassEntryUI();
            classEntryForm.Show();
            this.Hide();
        }

        private void subjectEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectEntryUI subjectEntryForm = new SubjectEntryUI();
            subjectEntryForm.Show();
            this.Hide();
        }

        private void studentEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentEntryUI studentEntryForm = new StudentEntryUI();
            studentEntryForm.Show();
            this.Hide();
        }

        private void resultEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultEntryUI resultEntryForm = new ResultEntryUI();
            resultEntryForm.Show();
            this.Hide();
        }

        private void individualResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndividualResultUI individualResultForm = new IndividualResultUI();
            individualResultForm.Show();
            this.Hide();
        }

        private void classWiseResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassWiseResultUI classWiseResultForm = new ClassWiseResultUI();
            classWiseResultForm.Show();
            this.Hide();
        }
    }
}
