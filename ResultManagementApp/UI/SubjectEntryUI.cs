using ResultManagementApp.Manager;
using ResultManagementApp.Model;
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
    public partial class SubjectEntryUI : Form
    {
        public SubjectEntryUI()
        {
            InitializeComponent();
        }

        private SubjectEntryManager aSubjectEntryManager = new SubjectEntryManager();

        private void backToHomeButton_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SubjectEntry aSubjectEntry = new SubjectEntry();

            aSubjectEntry.Name = nameTextBox.Text;
            aSubjectEntry.OrderBy = Convert.ToInt32(orderByTextBox.Text);

            if (saveButton.Text == "Save")
            {
                string message = aSubjectEntryManager.SaveSubject(aSubjectEntry);
                MessageBox.Show(message);
            }
            else
            {
                aSubjectEntry.Id = Convert.ToInt32(subjectIdTextBox.Text);
                string message = aSubjectEntryManager.UpdateSubject(aSubjectEntry);
                MessageBox.Show(message);
            }

            LoadSubjectEntryListView();
        }

        private void SubjectEntryUI_Load(object sender, EventArgs e)
        {
            LoadSubjectEntryListView();
        }

        private void LoadSubjectEntryListView()
        {
            subjectEntryListView.Items.Clear();
            List<SubjectEntry> allSubjects = aSubjectEntryManager.GetAllSubjects();

            foreach (SubjectEntry aSubjectEntry in allSubjects)
            {
                ListViewItem item = new ListViewItem();
                item.Text = aSubjectEntry.Name;
                item.SubItems.Add(aSubjectEntry.OrderBy.ToString());
                item.Tag = aSubjectEntry;

                subjectEntryListView.Items.Add(item);
            }
        }

        private void subjectEntryListView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selecteditem = subjectEntryListView.SelectedItems[0];

            SubjectEntry aSubjectEntry = (SubjectEntry)selecteditem.Tag;

            deleteButton.Enabled = true;

            if (aSubjectEntry != null)
            {
                nameTextBox.Text = aSubjectEntry.Name;
                orderByTextBox.Text = aSubjectEntry.OrderBy.ToString();
                subjectIdTextBox.Text = aSubjectEntry.Id.ToString();

                saveButton.Text = "Update";
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Clear();
            orderByTextBox.Clear();
            subjectIdTextBox.Clear();

            saveButton.Text = "Save";
            deleteButton.Enabled = false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            SubjectEntry aSubjectEntry = new SubjectEntry();

            aSubjectEntry.Id = Convert.ToInt32(subjectIdTextBox.Text);
            string message = aSubjectEntryManager.DeleteSubject(aSubjectEntry.Id);
            MessageBox.Show(message);

            LoadSubjectEntryListView();
        }
    }
}
