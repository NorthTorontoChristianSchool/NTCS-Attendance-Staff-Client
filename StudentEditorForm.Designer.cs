
namespace NTCSAttendanceStaffClient
{
    partial class StudentEditorForm
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
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StudentIDLabel = new System.Windows.Forms.Label();
            this.StudentIDTextBox = new System.Windows.Forms.TextBox();
            this.FamilyIDLabel = new System.Windows.Forms.Label();
            this.FamilyIDTextBox = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.HomeroomTextBox = new System.Windows.Forms.TextBox();
            this.HomeroomLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.KioskPersonalMessageLabel = new System.Windows.Forms.Label();
            this.KioskPersonalMessageTextBox = new System.Windows.Forms.TextBox();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(9, 7);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(129, 24);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "New Student";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePicker.Location = new System.Drawing.Point(79, 350);
            this.StartDatePicker.Margin = new System.Windows.Forms.Padding(2);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(151, 20);
            this.StartDatePicker.TabIndex = 17;
            // 
            // StudentIDLabel
            // 
            this.StudentIDLabel.AutoSize = true;
            this.StudentIDLabel.Location = new System.Drawing.Point(18, 46);
            this.StudentIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StudentIDLabel.Name = "StudentIDLabel";
            this.StudentIDLabel.Size = new System.Drawing.Size(58, 13);
            this.StudentIDLabel.TabIndex = 1;
            this.StudentIDLabel.Text = "Student ID";
            // 
            // StudentIDTextBox
            // 
            this.StudentIDTextBox.Location = new System.Drawing.Point(80, 43);
            this.StudentIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.StudentIDTextBox.MaxLength = 900;
            this.StudentIDTextBox.Name = "StudentIDTextBox";
            this.StudentIDTextBox.Size = new System.Drawing.Size(160, 20);
            this.StudentIDTextBox.TabIndex = 2;
            // 
            // FamilyIDLabel
            // 
            this.FamilyIDLabel.AutoSize = true;
            this.FamilyIDLabel.Location = new System.Drawing.Point(26, 69);
            this.FamilyIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FamilyIDLabel.Name = "FamilyIDLabel";
            this.FamilyIDLabel.Size = new System.Drawing.Size(50, 13);
            this.FamilyIDLabel.TabIndex = 3;
            this.FamilyIDLabel.Text = "Family ID";
            // 
            // FamilyIDTextBox
            // 
            this.FamilyIDTextBox.Location = new System.Drawing.Point(80, 66);
            this.FamilyIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FamilyIDTextBox.MaxLength = 900;
            this.FamilyIDTextBox.Name = "FamilyIDTextBox";
            this.FamilyIDTextBox.Size = new System.Drawing.Size(160, 20);
            this.FamilyIDTextBox.TabIndex = 4;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(18, 93);
            this.LastNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(58, 13);
            this.LastNameLabel.TabIndex = 5;
            this.LastNameLabel.Text = "Last Name";
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(80, 90);
            this.LastNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.LastNameTextBox.MaxLength = 4000;
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(160, 20);
            this.LastNameTextBox.TabIndex = 6;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(80, 114);
            this.FirstNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FirstNameTextBox.MaxLength = 4000;
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(160, 20);
            this.FirstNameTextBox.TabIndex = 8;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(19, 117);
            this.FirstNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(57, 13);
            this.FirstNameLabel.TabIndex = 7;
            this.FirstNameLabel.Text = "First Name";
            // 
            // HomeroomTextBox
            // 
            this.HomeroomTextBox.Location = new System.Drawing.Point(80, 138);
            this.HomeroomTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.HomeroomTextBox.MaxLength = 255;
            this.HomeroomTextBox.Name = "HomeroomTextBox";
            this.HomeroomTextBox.Size = new System.Drawing.Size(160, 20);
            this.HomeroomTextBox.TabIndex = 10;
            // 
            // HomeroomLabel
            // 
            this.HomeroomLabel.AutoSize = true;
            this.HomeroomLabel.Location = new System.Drawing.Point(18, 141);
            this.HomeroomLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HomeroomLabel.Name = "HomeroomLabel";
            this.HomeroomLabel.Size = new System.Drawing.Size(58, 13);
            this.HomeroomLabel.TabIndex = 9;
            this.HomeroomLabel.Text = "Homeroom";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(80, 162);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EmailTextBox.MaxLength = 4000;
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(160, 20);
            this.EmailTextBox.TabIndex = 12;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(4, 165);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(72, 13);
            this.EmailLabel.TabIndex = 11;
            this.EmailLabel.Text = "Student Email";
            // 
            // KioskPersonalMessageLabel
            // 
            this.KioskPersonalMessageLabel.AutoSize = true;
            this.KioskPersonalMessageLabel.Location = new System.Drawing.Point(10, 193);
            this.KioskPersonalMessageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.KioskPersonalMessageLabel.Name = "KioskPersonalMessageLabel";
            this.KioskPersonalMessageLabel.Size = new System.Drawing.Size(123, 13);
            this.KioskPersonalMessageLabel.TabIndex = 13;
            this.KioskPersonalMessageLabel.Text = "Kiosk Personal Message";
            // 
            // KioskPersonalMessageTextBox
            // 
            this.KioskPersonalMessageTextBox.AcceptsReturn = true;
            this.KioskPersonalMessageTextBox.Location = new System.Drawing.Point(12, 209);
            this.KioskPersonalMessageTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.KioskPersonalMessageTextBox.MaxLength = 4000;
            this.KioskPersonalMessageTextBox.Multiline = true;
            this.KioskPersonalMessageTextBox.Name = "KioskPersonalMessageTextBox";
            this.KioskPersonalMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.KioskPersonalMessageTextBox.Size = new System.Drawing.Size(228, 116);
            this.KioskPersonalMessageTextBox.TabIndex = 14;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(10, 354);
            this.StartDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(48, 13);
            this.StartDateLabel.TabIndex = 16;
            this.StartDateLabel.Text = "between";
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(10, 334);
            this.MessageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(210, 13);
            this.MessageLabel.TabIndex = 15;
            this.MessageLabel.Text = "Message will be displayed when the date is";
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDatePicker.Location = new System.Drawing.Point(79, 374);
            this.EndDatePicker.Margin = new System.Windows.Forms.Padding(2);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(151, 20);
            this.EndDatePicker.TabIndex = 19;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(10, 378);
            this.EndDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(25, 13);
            this.EndDateLabel.TabIndex = 18;
            this.EndDateLabel.Text = "and";
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.BackColor = System.Drawing.Color.Red;
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Location = new System.Drawing.Point(9, 402);
            this.CancelFormButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(84, 24);
            this.CancelFormButton.TabIndex = 20;
            this.CancelFormButton.Text = "Cancel [Esc]";
            this.CancelFormButton.UseVisualStyleBackColor = false;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveButton.Location = new System.Drawing.Point(167, 402);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(79, 24);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Save [Ctrl+S]";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // StudentEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(255, 436);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.KioskPersonalMessageTextBox);
            this.Controls.Add(this.KioskPersonalMessageLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.HomeroomLabel);
            this.Controls.Add(this.HomeroomTextBox);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FamilyIDTextBox);
            this.Controls.Add(this.FamilyIDLabel);
            this.Controls.Add(this.StudentIDTextBox);
            this.Controls.Add(this.StudentIDLabel);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::NTCSAttendanceStaffClient.Properties.Resources.NTCSIcon;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Student";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StudentEditorForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label StudentIDLabel;
        private System.Windows.Forms.TextBox StudentIDTextBox;
        private System.Windows.Forms.Label FamilyIDLabel;
        private System.Windows.Forms.TextBox FamilyIDTextBox;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox HomeroomTextBox;
        private System.Windows.Forms.Label HomeroomLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label KioskPersonalMessageLabel;
        private System.Windows.Forms.TextBox KioskPersonalMessageTextBox;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Button SaveButton;
    }
}