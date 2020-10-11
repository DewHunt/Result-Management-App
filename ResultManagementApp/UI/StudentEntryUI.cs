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
    public partial class StudentEntryUI : Form
    {
        public StudentEntryUI()
        {
            InitializeComponent();
        }

        private StudentEntryManager aStudentEntryManager = new StudentEntryManager();

        private void backToHomeButton_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }

        private void StudentEntryUI_Load(object sender, EventArgs e)
        {
            LoadClassesComboBox();

            LoadStudentEntryListview();
        }

        private void LoadClassesComboBox()
        {
            List<ClassEntry> allClasses = aStudentEntryManager.GetAllClasses();

            classComboBox.DataSource = allClasses;
            classComboBox.ValueMember = "Id";
            classComboBox.DisplayMember = "Name";
        }

        private void LoadStudentEntryListview()
        {
            studentListView.Items.Clear();
            List<StudentEntry> allStudents = aStudentEntryManager.GetAllStudents();

            foreach (StudentEntry aStudentEntry in allStudents)
            {
                ListViewItem item = new ListViewItem();
                item.Text = aStudentEntry.Name;
                item.SubItems.Add(aStudentEntry.ClassName);
                item.SubItems.Add(aStudentEntry.Roll);
                item.SubItems.Add(aStudentEntry.Phone);
                item.SubItems.Add(aStudentEntry.OrderBy.ToString());
                item.Tag = aStudentEntry;

                studentListView.Items.Add(item);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StudentEntry aStudentEntry = new StudentEntry();

            aStudentEntry.ClassId = Convert.ToInt32(this.classComboBox.SelectedValue);
            aStudentEntry.Roll = rollTextBox.Text;
            aStudentEntry.Name = nameTextBox.Text;
            aStudentEntry.Phone = phoneTextBox.Text;
            aStudentEntry.OrderBy = Convert.ToInt32(orderByTextBox.Text);

            if (saveButton.Text == "Save")
            {
                string message = aStudentEntryManager.SaveStudent(aStudentEntry);
                MessageBox.Show(message);
            }
            else
            {
                aStudentEntry.Id = Convert.ToInt32(studentIdTextBox.Text);
                string message = aStudentEntryManager.UpdateStudent(aStudentEntry);
                MessageBox.Show(message);
            }

            LoadStudentEntryListview();
        }

        private void studentListView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = studentListView.SelectedItems[0];

            StudentEntry aStudentEntry = (StudentEntry)selectedItem.Tag;

            if (aStudentEntry != null)
            {
                nameTextBox.Text = aStudentEntry.Name;
                phoneTextBox.Text = aStudentEntry.Phone;
                classComboBox.SelectedIndex = classComboBox.FindStringExact(aStudentEntry.ClassName);
                rollTextBox.Text = aStudentEntry.Roll;
                orderByTextBox.Text = aStudentEntry.OrderBy.ToString();
                studentIdTextBox.Text = aStudentEntry.Id.ToString();
                saveButton.Text = "Update";
            }

            deleteButton.Enabled = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Clear();
            phoneTextBox.Clear();
            rollTextBox.Clear();
            orderByTextBox.Clear();

            LoadClassesComboBox();

            saveButton.Text = "Save";
            deleteButton.Enabled = false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            StudentEntry aStudentEntry = new StudentEntry();

            aStudentEntry.Id = Convert.ToInt32(studentIdTextBox.Text);
            string message = aStudentEntryManager.DeleteStudent(aStudentEntry.Id);
            MessageBox.Show(message);

            LoadStudentEntryListview();
        }
    }
}
