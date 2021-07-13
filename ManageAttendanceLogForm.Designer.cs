
namespace NTCSAttendanceStaffClient
{
    partial class ManageAttendanceLogForm
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
            this.StudentDataGridView = new System.Windows.Forms.DataGridView();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.NewAttendanceRecordButton = new System.Windows.Forms.Button();
            this.DeleteSelectedButton = new System.Windows.Forms.Button();
            this.ClearSearchButton = new System.Windows.Forms.Button();
            this.SearchActiveLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentDataGridView
            // 
            this.StudentDataGridView.AllowUserToAddRows = false;
            this.StudentDataGridView.AllowUserToDeleteRows = false;
            this.StudentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.StudentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.StudentDataGridView.Location = new System.Drawing.Point(9, 104);
            this.StudentDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.StudentDataGridView.Name = "StudentDataGridView";
            this.StudentDataGridView.RowHeadersWidth = 51;
            this.StudentDataGridView.RowTemplate.Height = 24;
            this.StudentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StudentDataGridView.Size = new System.Drawing.Size(734, 472);
            this.StudentDataGridView.TabIndex = 7;
            this.StudentDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentDataGridView_CellDoubleClick);
            this.StudentDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StudentDataGridView_KeyDown);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(11, 70);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(2);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(81, 24);
            this.RefreshButton.TabIndex = 3;
            this.RefreshButton.Text = "Refresh [F5]";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(576, 11);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(167, 24);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Close and Return to Main Menu";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(11, 42);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(2);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(140, 23);
            this.SearchBox.TabIndex = 0;
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(155, 42);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(56, 24);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // NewAttendanceRecordButton
            // 
            this.NewAttendanceRecordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewAttendanceRecordButton.Location = new System.Drawing.Point(434, 70);
            this.NewAttendanceRecordButton.Margin = new System.Windows.Forms.Padding(2);
            this.NewAttendanceRecordButton.Name = "NewAttendanceRecordButton";
            this.NewAttendanceRecordButton.Size = new System.Drawing.Size(140, 24);
            this.NewAttendanceRecordButton.TabIndex = 4;
            this.NewAttendanceRecordButton.Text = "New Record... [Ctrl+N]";
            this.NewAttendanceRecordButton.UseVisualStyleBackColor = true;
            this.NewAttendanceRecordButton.Click += new System.EventHandler(this.NewStudentButton_Click);
            // 
            // DeleteSelectedButton
            // 
            this.DeleteSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteSelectedButton.Location = new System.Drawing.Point(576, 70);
            this.DeleteSelectedButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteSelectedButton.Name = "DeleteSelectedButton";
            this.DeleteSelectedButton.Size = new System.Drawing.Size(167, 24);
            this.DeleteSelectedButton.TabIndex = 5;
            this.DeleteSelectedButton.Text = "Delete Selected Records [Del]";
            this.DeleteSelectedButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedButton.Click += new System.EventHandler(this.DeleteSelectedButton_Click);
            // 
            // ClearSearchButton
            // 
            this.ClearSearchButton.Location = new System.Drawing.Point(215, 42);
            this.ClearSearchButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClearSearchButton.Name = "ClearSearchButton";
            this.ClearSearchButton.Size = new System.Drawing.Size(80, 24);
            this.ClearSearchButton.TabIndex = 2;
            this.ClearSearchButton.Text = "Clear Search";
            this.ClearSearchButton.UseVisualStyleBackColor = true;
            this.ClearSearchButton.Click += new System.EventHandler(this.ClearSearchButton_Click);
            // 
            // SearchActiveLabel
            // 
            this.SearchActiveLabel.AutoSize = true;
            this.SearchActiveLabel.Location = new System.Drawing.Point(299, 48);
            this.SearchActiveLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SearchActiveLabel.Name = "SearchActiveLabel";
            this.SearchActiveLabel.Size = new System.Drawing.Size(74, 13);
            this.SearchActiveLabel.TabIndex = 8;
            this.SearchActiveLabel.Text = "Search Active";
            this.SearchActiveLabel.Visible = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(11, 9);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(238, 24);
            this.TitleLabel.TabIndex = 9;
            this.TitleLabel.Text = "Manage Attendance Log";
            // 
            // ManageAttendanceLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.SearchActiveLabel);
            this.Controls.Add(this.ClearSearchButton);
            this.Controls.Add(this.DeleteSelectedButton);
            this.Controls.Add(this.NewAttendanceRecordButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.StudentDataGridView);
            this.Icon = global::NTCSAttendanceStaffClient.Properties.Resources.NTCSIcon;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManageAttendanceLogForm";
            this.Text = "Manage Attendance Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageStudentsForm_FormClosing);
            this.Load += new System.EventHandler(this.ManageStudentsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageStudentsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StudentDataGridView;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button NewAttendanceRecordButton;
        private System.Windows.Forms.Button DeleteSelectedButton;
        private System.Windows.Forms.Button ClearSearchButton;
        private System.Windows.Forms.Label SearchActiveLabel;
        private System.Windows.Forms.Label TitleLabel;
    }
}