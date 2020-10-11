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
    public partial class ResultEntryUI : Form
    {
        ResultEntryManager aResultEntryManager = new ResultEntryManager();

        public ResultEntryUI()
        {
            InitializeComponent();
        }

        private void backtoHomeButton_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }

        private void ResultEntryUI_Load(object sender, EventArgs e)
        {
            LoadClassesComboBox();
            LoadSubjectsComboBox();
            LoadResultEntryListView();
        }

        private void LoadResultEntryListView()
        {
            resultListView.Items.Clear();
            List<ResultEntry> allResults = aResultEntryManager.GetAllResults();

            foreach (ResultEntry aResultEntry in allResults)
            {
                ListViewItem item = new ListViewItem();
                item.Text = aResultEntry.StudentName;
                item.SubItems.Add(aResultEntry.ClassName);
                item.SubItems.Add(aResultEntry.Roll);
                item.SubItems.Add(aResultEntry.SubjectName);
                item.SubItems.Add(aResultEntry.Marks.ToString());
                item.Tag = aResultEntry;

                resultListView.Items.Add(item);
            }
        }

        private void LoadSubjectsComboBox()
        {
            List<SubjectEntry> allSubjects = aResultEntryManager.GetAllSubjects();

            subjectComboBox.ValueMember = "Id";
            subjectComboBox.DisplayMember = "Name";
            subjectComboBox.DataSource = allSubjects;
        }

        private void LoadClassesComboBox()
        {
            List<ClassEntry> allClasses = aResultEntryManager.GetAllClasses();

            classComboBox.ValueMember = "Id";
            classComboBox.DisplayMember = "Name";
            classComboBox.DataSource = allClasses;
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classComboBox.SelectedValue.ToString() != null)
            {
                int classId = Convert.ToInt32(classComboBox.SelectedValue);

                List<StudentEntry> allStudents = aResultEntryManager.GetAllStudentsByClass(classId);

                studentComboBox.ValueMember = "Id";
                studentComboBox.DisplayMember = "Name";
                studentComboBox.DataSource = allStudents;
            }
        }

        private void studentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (studentComboBox.SelectedValue.ToString() != null)
            {
                int studentId = Convert.ToInt32(studentComboBox.SelectedValue);

                StudentEntry studentInfo = aResultEntryManager.GetStudentInfoById(studentId);

                nameLabel.Text = studentInfo.Name;
                classLabel.Text = studentInfo.ClassName;
                phoneLabel.Text = studentInfo.Phone;
                rollLabel.Text = studentInfo.Roll;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ResultEntry aResultEntry = new ResultEntry();

            aResultEntry.StudentId = Convert.ToInt32(this.studentComboBox.SelectedValue);
            aResultEntry.SubjectId = Convert.ToInt32(this.subjectComboBox.SelectedValue);
            aResultEntry.Marks = Convert.ToInt32(marksTextBox.Text);

            if (saveButton.Text == "Save")
            {
                string message = aResultEntryManager.SaveResult(aResultEntry);
                MessageBox.Show(message);
            }
            else
            {
                aResultEntry.Id = Convert.ToInt32(resultIdTextBox.Text);

                string message = aResultEntryManager.UpdateResult(aResultEntry);
                MessageBox.Show(message);
            }

            LoadResultEntryListView();
        }

        private void resultListView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = resultListView.SelectedItems[0];

            ResultEntry aResultEntry = (ResultEntry)selectedItem.Tag;

            if (aResultEntry != null)
            {
                resultIdTextBox.Text = aResultEntry.Id.ToString();
                classComboBox.SelectedIndex = classComboBox.FindStringExact(aResultEntry.ClassName);
                studentComboBox.SelectedIndex = studentComboBox.FindStringExact(aResultEntry.StudentName);
                subjectComboBox.SelectedIndex = subjectComboBox.FindStringExact(aResultEntry.SubjectName);
                marksTextBox.Text = aResultEntry.Marks.ToString();

                saveButton.Text = "Update";
            }

            deleteButton.Enabled = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ResultEntry aResultEntry = new ResultEntry();

            aResultEntry.Id = Convert.ToInt32(resultIdTextBox.Text);
            string message = aResultEntryManager.DeleteResult(aResultEntry.Id);
            MessageBox.Show(message);

            LoadResultEntryListView();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            marksTextBox.Clear();
            resultIdTextBox.Clear();
            LoadClassesComboBox();
            LoadSubjectsComboBox();

            saveButton.Text = "Save";
            deleteButton.Enabled = false;
        }
    }
}
