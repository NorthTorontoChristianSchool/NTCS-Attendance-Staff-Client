
namespace NTCSAttendanceStaffClient
{
    partial class AttendanceLogEditorForm
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.LogTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StudentIDLabel = new System.Windows.Forms.Label();
            this.StudentIDTextBox = new System.Windows.Forms.TextBox();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.ScanLocationTextBox = new System.Windows.Forms.TextBox();
            this.ScanLocationLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ScanTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ScanTypeLabel = new System.Windows.Forms.Label();
            this.LogTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(295, 29);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "New Attendance Record";
            // 
            // LogTimePicker
            // 
            this.LogTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.LogTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.LogTimePicker.Location = new System.Drawing.Point(119, 56);
            this.LogTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogTimePicker.Name = "LogTimePicker";
            this.LogTimePicker.Size = new System.Drawing.Size(217, 22);
            this.LogTimePicker.TabIndex = 17;
            // 
            // StudentIDLabel
            // 
            this.StudentIDLabel.AutoSize = true;
            this.StudentIDLabel.Location = new System.Drawing.Point(39, 91);
            this.StudentIDLabel.Name = "StudentIDLabel";
            this.StudentIDLabel.Size = new System.Drawing.Size(74, 17);
            this.StudentIDLabel.TabIndex = 1;
            this.StudentIDLabel.Text = "Student ID";
            // 
            // StudentIDTextBox
            // 
            this.StudentIDTextBox.Location = new System.Drawing.Point(119, 88);
            this.StudentIDTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StudentIDTextBox.MaxLength = 900;
            this.StudentIDTextBox.Name = "StudentIDTextBox";
            this.StudentIDTextBox.Size = new System.Drawing.Size(217, 22);
            this.StudentIDTextBox.TabIndex = 2;
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.BackColor = System.Drawing.Color.Red;
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Location = new System.Drawing.Point(12, 197);
            this.CancelFormButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(112, 30);
            this.CancelFormButton.TabIndex = 20;
            this.CancelFormButton.Text = "Cancel [Esc]";
            this.CancelFormButton.UseVisualStyleBackColor = false;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ScanLocationTextBox
            // 
            this.ScanLocationTextBox.Location = new System.Drawing.Point(119, 121);
            this.ScanLocationTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScanLocationTextBox.MaxLength = 4000;
            this.ScanLocationTextBox.Name = "ScanLocationTextBox";
            this.ScanLocationTextBox.Size = new System.Drawing.Size(217, 22);
            this.ScanLocationTextBox.TabIndex = 4;
            // 
            // ScanLocationLabel
            // 
            this.ScanLocationLabel.AutoSize = true;
            this.ScanLocationLabel.Location = new System.Drawing.Point(15, 124);
            this.ScanLocationLabel.Name = "ScanLocationLabel";
            this.ScanLocationLabel.Size = new System.Drawing.Size(98, 17);
            this.ScanLocationLabel.TabIndex = 3;
            this.ScanLocationLabel.Text = "Scan Location";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveButton.Location = new System.Drawing.Point(231, 197);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(105, 30);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Save [Ctrl+S]";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ScanTypeComboBox
            // 
            this.ScanTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScanTypeComboBox.FormattingEnabled = true;
            this.ScanTypeComboBox.Items.AddRange(new object[] {
            "Sign In",
            "Sign Out",
            "Excused Absence"});
            this.ScanTypeComboBox.Location = new System.Drawing.Point(119, 156);
            this.ScanTypeComboBox.Name = "ScanTypeComboBox";
            this.ScanTypeComboBox.Size = new System.Drawing.Size(217, 24);
            this.ScanTypeComboBox.TabIndex = 22;
            // 
            // ScanTypeLabel
            // 
            this.ScanTypeLabel.AutoSize = true;
            this.ScanTypeLabel.Location = new System.Drawing.Point(37, 159);
            this.ScanTypeLabel.Name = "ScanTypeLabel";
            this.ScanTypeLabel.Size = new System.Drawing.Size(76, 17);
            this.ScanTypeLabel.TabIndex = 23;
            this.ScanTypeLabel.Text = "Scan Type";
            // 
            // LogTimeLabel
            // 
            this.LogTimeLabel.AutoSize = true;
            this.LogTimeLabel.Location = new System.Drawing.Point(12, 61);
            this.LogTimeLabel.Name = "LogTimeLabel";
            this.LogTimeLabel.Size = new System.Drawing.Size(101, 17);
            this.LogTimeLabel.TabIndex = 24;
            this.LogTimeLabel.Text = "Log Date/Time";
            // 
            // AttendanceLogEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(348, 238);
            this.Controls.Add(this.LogTimeLabel);
            this.Controls.Add(this.ScanTypeLabel);
            this.Controls.Add(this.ScanTypeComboBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.ScanLocationTextBox);
            this.Controls.Add(this.ScanLocationLabel);
            this.Controls.Add(this.StudentIDTextBox);
            this.Controls.Add(this.StudentIDLabel);
            this.Controls.Add(this.LogTimePicker);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::NTCSAttendanceStaffClient.Properties.Resources.NTCSIcon;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttendanceLogEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Attendance Record";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StudentEditorForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.DateTimePicker LogTimePicker;
        private System.Windows.Forms.Label StudentIDLabel;
        private System.Windows.Forms.TextBox StudentIDTextBox;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.TextBox ScanLocationTextBox;
        private System.Windows.Forms.Label ScanLocationLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox ScanTypeComboBox;
        private System.Windows.Forms.Label ScanTypeLabel;
        private System.Windows.Forms.Label LogTimeLabel;
    }
}