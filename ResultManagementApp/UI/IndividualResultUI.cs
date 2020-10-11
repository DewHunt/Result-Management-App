using ResultManagementApp.Manager;
using ResultManagementApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultManagementApp.UI
{
    public partial class IndividualResultUI : Form
    {
        private IndividualResultManager aIndividualResultManager = new IndividualResultManager();

        public IndividualResultUI()
        {
            InitializeComponent();
        }

        private void backToHomeButton_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }

        private void IndividualResultUI_Load(object sender, EventArgs e)
        {
            LoadClassesComboBox();
        }

        private void LoadClassesComboBox()
        {
            List<ClassEntry> allClasses = aIndividualResultManager.GetAllClasses();

            classComboBox.ValueMember = "Id";
            classComboBox.DisplayMember = "Name";
            classComboBox.DataSource = allClasses;
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classComboBox.SelectedValue.ToString() != null)
            {
                int classId = Convert.ToInt32(classComboBox.SelectedValue);

                List<StudentEntry> allStudents = aIndividualResultManager.GetAllStudentsByClass(classId);

                studentComboBox.ValueMember = "Id";
                studentComboBox.DisplayMember = "Name";
                studentComboBox.DataSource = allStudents;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int studenId = Convert.ToInt32(studentComboBox.SelectedValue);

            StudentEntry studentInfo = aIndividualResultManager.GetStudentInfoById(studenId);

            float average = aIndividualResultManager.GetResultAverage(studenId);

            studentNameLabel.Text = studentInfo.Name;
            classNameLabel.Text = studentInfo.ClassName;
            rollLabel.Text = studentInfo.Roll;
            averageLabel.Text = average.ToString("0.00");

            LoadAllSubjectsResultListView(studenId);
        }

        private void LoadAllSubjectsResultListView(int studenId)
        {
            resultListView.Items.Clear();
            List<IndividualResult> allSubjectResultInfo = aIndividualResultManager.GetAllSubjectResults(studenId);

            foreach (IndividualResult aSubjectResultInfo in allSubjectResultInfo)
            {
                ListViewItem item = new ListViewItem();

                item.Text = aSubjectResultInfo.SubjectName;
                item.SubItems.Add(aSubjectResultInfo.Marks.ToString());
                item.SubItems.Add(aSubjectResultInfo.LetterGrade);

                resultListView.Items.Add(item);
            }
        }
    }
}
