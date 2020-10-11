using ResultManagementApp.Manager;
using ResultManagementApp.Model;
using ResultManagementApp.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultManagementApp
{
    public partial class ClassEntryUI : Form
    {
        public ClassEntryUI()
        {
            InitializeComponent();
        }

        private ClassEntryManager aClassEntryManager = new ClassEntryManager();

        private void backToHomeButton_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ClassEntry aClassEntry = new ClassEntry();

            aClassEntry.Name = classNameTextBox.Text;
            aClassEntry.OrderBy = Convert.ToInt32(orderByTextBox.Text);

            if (saveButton.Text == "Save")
            {
                string message = aClassEntryManager.SaveClass(aClassEntry);
                MessageBox.Show(message);
            }
            else
            {
                aClassEntry.Id = Convert.ToInt32(classIdTextBox.Text);
                string message = aClassEntryManager.UpdateClass(aClassEntry);
                MessageBox.Show(message);
            }

            LoadClassEntryListView();
        }

        private void ClassEntryUI_Load(object sender, EventArgs e)
        {
            LoadClassEntryListView();
        }

        private void LoadClassEntryListView()
        {
            classEntryListView.Items.Clear();
            List<ClassEntry> allClassess = aClassEntryManager.GetAllClasses();

            foreach (ClassEntry aClassEntry in allClassess)
            {
                ListViewItem item = new ListViewItem();
                item.Text = aClassEntry.Name;
                item.SubItems.Add(aClassEntry.OrderBy.ToString());
                item.Tag = aClassEntry;

                classEntryListView.Items.Add(item);
            }
        }

        private void classEntryListView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = classEntryListView.SelectedItems[0];

            ClassEntry aClassEntry = (ClassEntry)selectedItem.Tag;

            deleteButton.Enabled = true;

            if (aClassEntry != null)
            {
                classNameTextBox.Text = aClassEntry.Name;
                orderByTextBox.Text = aClassEntry.OrderBy.ToString();
                classIdTextBox.Text = aClassEntry.Id.ToString();

                saveButton.Text = "Update";
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            classNameTextBox.Clear();
            orderByTextBox.Clear();
            classIdTextBox.Clear();

            saveButton.Text = "Save";
            deleteButton.Enabled = false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ClassEntry aClassEntry = new ClassEntry();

            aClassEntry.Id = Convert.ToInt32(classIdTextBox.Text);
            string message = aClassEntryManager.DeleteClass(aClassEntry.Id);
            MessageBox.Show(message);

            LoadClassEntryListView();
        }
    }
}
