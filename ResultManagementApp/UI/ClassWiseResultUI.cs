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
    public partial class ClassWiseResultUI : Form
    {
        private ClassWiseResultManager aClassWiseResultManager = new ClassWiseResultManager();

        public ClassWiseResultUI()
        {
            InitializeComponent();
        }

        private void ClassWiseResultUI_Load(object sender, EventArgs e)
        {
            List<ClassEntry> allClasses = aClassWiseResultManager.GetAllClasses();

            classComboBox.ValueMember = "Id";
            classComboBox.DisplayMember = "Name";
            classComboBox.DataSource = allClasses;
        }

        private void backToHomeButton_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int classId = Convert.ToInt32(classComboBox.SelectedValue);
            string className = classComboBox.Text;

            List<StudentEntry> totalStudent = aClassWiseResultManager.CalculateTotalStudentInClass(classId);
            ClassWiseResult passedFailedPercentage = aClassWiseResultManager.CalculatePassedFailedPercentage(classId);

            classNameLabel.Text = className;
            totalStudentLabel.Text = totalStudent.Count.ToString();
            passedLabel.Text = passedFailedPercentage.Passed.ToString("0.00");
            failedLabel.Text = passedFailedPercentage.Failed.ToString("0.00");

            LoadAllStudentResultListView(classId);
        }

        private void LoadAllStudentResultListView(int classId)
        {
            List<ClassWiseResult> allStudentsResultInfo = aClassWiseResultManager.GetAllStudentsResultInfoByClass(classId);

            resultListView.Items.Clear();

            foreach (ClassWiseResult aStudentResultInfo in allStudentsResultInfo)
            {
                ListViewItem item = new ListViewItem();

                item.Text = aStudentResultInfo.StudentName;
                item.SubItems.Add(aStudentResultInfo.TotalMarks.ToString("0.00"));
                item.SubItems.Add(aStudentResultInfo.Average.ToString("0.00"));
                item.SubItems.Add(aStudentResultInfo.LetterGrade);

                resultListView.Items.Add(item);
            }
        }
    }
}
