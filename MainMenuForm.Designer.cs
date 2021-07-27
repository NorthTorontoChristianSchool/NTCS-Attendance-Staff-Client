
namespace NTCSAttendanceStaffClient
{
    partial class MainMenuForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ManageStudentsButton = new System.Windows.Forms.Button();
            this.ManageFamiliesButton = new System.Windows.Forms.Button();
            this.AttendanceLogButton = new System.Windows.Forms.Button();
            this.KioskMessagesButton = new System.Windows.Forms.Button();
            this.SendEmailsButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AboutButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.Controls.Add(this.ManageStudentsButton);
            this.flowLayoutPanel1.Controls.Add(this.ManageFamiliesButton);
            this.flowLayoutPanel1.Controls.Add(this.AttendanceLogButton);
            this.flowLayoutPanel1.Controls.Add(this.KioskMessagesButton);
            this.flowLayoutPanel1.Controls.Add(this.SendEmailsButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(25, 63);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(396, 461);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ManageStudentsButton
            // 
            this.ManageStudentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageStudentsButton.Location = new System.Drawing.Point(3, 2);
            this.ManageStudentsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageStudentsButton.Name = "ManageStudentsButton";
            this.ManageStudentsButton.Size = new System.Drawing.Size(389, 87);
            this.ManageStudentsButton.TabIndex = 0;
            this.ManageStudentsButton.Text = "Manage Students";
            this.ManageStudentsButton.UseVisualStyleBackColor = true;
            this.ManageStudentsButton.Click += new System.EventHandler(this.ManageStudentsButton_Click);
            // 
            // ManageFamiliesButton
            // 
            this.ManageFamiliesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageFamiliesButton.Location = new System.Drawing.Point(3, 93);
            this.ManageFamiliesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageFamiliesButton.Name = "ManageFamiliesButton";
            this.ManageFamiliesButton.Size = new System.Drawing.Size(389, 87);
            this.ManageFamiliesButton.TabIndex = 1;
            this.ManageFamiliesButton.Text = "Manage Family Emails";
            this.ManageFamiliesButton.UseVisualStyleBackColor = true;
            this.ManageFamiliesButton.Click += new System.EventHandler(this.ManageFamiliesButton_Click);
            // 
            // AttendanceLogButton
            // 
            this.AttendanceLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttendanceLogButton.Location = new System.Drawing.Point(3, 184);
            this.AttendanceLogButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AttendanceLogButton.Name = "AttendanceLogButton";
            this.AttendanceLogButton.Size = new System.Drawing.Size(389, 87);
            this.AttendanceLogButton.TabIndex = 2;
            this.AttendanceLogButton.Text = "Manage Attendance Log";
            this.AttendanceLogButton.UseVisualStyleBackColor = true;
            this.AttendanceLogButton.Click += new System.EventHandler(this.AttendanceLogButton_Click);
            // 
            // KioskMessagesButton
            // 
            this.KioskMessagesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KioskMessagesButton.Location = new System.Drawing.Point(3, 275);
            this.KioskMessagesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.KioskMessagesButton.Name = "KioskMessagesButton";
            this.KioskMessagesButton.Size = new System.Drawing.Size(389, 87);
            this.KioskMessagesButton.TabIndex = 3;
            this.KioskMessagesButton.Text = "Manage Public Kiosk Messages";
            this.KioskMessagesButton.UseVisualStyleBackColor = true;
            this.KioskMessagesButton.Click += new System.EventHandler(this.KioskMessagesButton_Click);
            // 
            // SendEmailsButton
            // 
            this.SendEmailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendEmailsButton.Location = new System.Drawing.Point(3, 366);
            this.SendEmailsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendEmailsButton.Name = "SendEmailsButton";
            this.SendEmailsButton.Size = new System.Drawing.Size(389, 87);
            this.SendEmailsButton.TabIndex = 4;
            this.SendEmailsButton.Text = "Send Emails to Parents of Absent Students";
            this.SendEmailsButton.UseVisualStyleBackColor = true;
            this.SendEmailsButton.Click += new System.EventHandler(this.SendEmailsButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(120, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(216, 51);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "AtteNTCS";
            // 
            // AboutButton
            // 
            this.AboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutButton.Location = new System.Drawing.Point(223, 533);
            this.AboutButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(101, 54);
            this.AboutButton.TabIndex = 1;
            this.AboutButton.Text = "About...";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackColor = System.Drawing.Color.Red;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(331, 533);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(101, 54);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(445, 599);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ExitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::NTCSAttendanceStaffClient.Properties.Resources.NTCSIcon;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AtteNTCS Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ManageStudentsButton;
        private System.Windows.Forms.Button ManageFamiliesButton;
        private System.Windows.Forms.Button AttendanceLogButton;
        private System.Windows.Forms.Button KioskMessagesButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button SendEmailsButton;
    }
}