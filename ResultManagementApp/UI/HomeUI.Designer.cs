namespace ResultManagementApp.UI
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.entryPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewResuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.individualResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classWiseResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entryPageToolStripMenuItem,
            this.viewResuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // entryPageToolStripMenuItem
            // 
            this.entryPageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classEntryToolStripMenuItem,
            this.subjectEntryToolStripMenuItem,
            this.studentEntryToolStripMenuItem,
            this.resultEntryToolStripMenuItem});
            this.entryPageToolStripMenuItem.Name = "entryPageToolStripMenuItem";
            this.entryPageToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.entryPageToolStripMenuItem.Text = "Entry Page";
            // 
            // classEntryToolStripMenuItem
            // 
            this.classEntryToolStripMenuItem.Name = "classEntryToolStripMenuItem";
            this.classEntryToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.classEntryToolStripMenuItem.Text = "Class Entry";
            this.classEntryToolStripMenuItem.Click += new System.EventHandler(this.classEntryToolStripMenuItem_Click);
            // 
            // subjectEntryToolStripMenuItem
            // 
            this.subjectEntryToolStripMenuItem.Name = "subjectEntryToolStripMenuItem";
            this.subjectEntryToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.subjectEntryToolStripMenuItem.Text = "Subject Entry";
            this.subjectEntryToolStripMenuItem.Click += new System.EventHandler(this.subjectEntryToolStripMenuItem_Click);
            // 
            // studentEntryToolStripMenuItem
            // 
            this.studentEntryToolStripMenuItem.Name = "studentEntryToolStripMenuItem";
            this.studentEntryToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.studentEntryToolStripMenuItem.Text = "Student Entry";
            this.studentEntryToolStripMenuItem.Click += new System.EventHandler(this.studentEntryToolStripMenuItem_Click);
            // 
            // resultEntryToolStripMenuItem
            // 
            this.resultEntryToolStripMenuItem.Name = "resultEntryToolStripMenuItem";
            this.resultEntryToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.resultEntryToolStripMenuItem.Text = "Result Entry";
            this.resultEntryToolStripMenuItem.Click += new System.EventHandler(this.resultEntryToolStripMenuItem_Click);
            // 
            // viewResuToolStripMenuItem
            // 
            this.viewResuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.individualResultToolStripMenuItem,
            this.classWiseResultToolStripMenuItem});
            this.viewResuToolStripMenuItem.Name = "viewResuToolStripMenuItem";
            this.viewResuToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.viewResuToolStripMenuItem.Text = "View Result";
            // 
            // individualResultToolStripMenuItem
            // 
            this.individualResultToolStripMenuItem.Name = "individualResultToolStripMenuItem";
            this.individualResultToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.individualResultToolStripMenuItem.Text = "Individual Result";
            this.individualResultToolStripMenuItem.Click += new System.EventHandler(this.individualResultToolStripMenuItem_Click);
            // 
            // classWiseResultToolStripMenuItem
            // 
            this.classWiseResultToolStripMenuItem.Name = "classWiseResultToolStripMenuItem";
            this.classWiseResultToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.classWiseResultToolStripMenuItem.Text = "Class Wise Result";
            this.classWiseResultToolStripMenuItem.Click += new System.EventHandler(this.classWiseResultToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "HomeUI";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem entryPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewResuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem individualResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classWiseResultToolStripMenuItem;
    }
}