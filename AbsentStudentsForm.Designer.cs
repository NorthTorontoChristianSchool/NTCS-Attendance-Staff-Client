
namespace NTCSAttendanceStaffClient
{
    partial class AbsentStudentsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.SendEmailsButton = new System.Windows.Forms.Button();
            this.AbsentDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AbsentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(545, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "These students have not signed in today and do not have an \"Excused Absence\" log:" +
    "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(527, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Press \"Send Emails\" below to send emails to the parents of these absent students." +
    "";
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelFormButton.BackColor = System.Drawing.Color.Red;
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelFormButton.Location = new System.Drawing.Point(12, 446);
            this.CancelFormButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(133, 49);
            this.CancelFormButton.TabIndex = 3;
            this.CancelFormButton.Text = "Cancel";
            this.CancelFormButton.UseVisualStyleBackColor = false;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SendEmailsButton
            // 
            this.SendEmailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendEmailsButton.BackColor = System.Drawing.Color.YellowGreen;
            this.SendEmailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendEmailsButton.Location = new System.Drawing.Point(463, 446);
            this.SendEmailsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendEmailsButton.Name = "SendEmailsButton";
            this.SendEmailsButton.Size = new System.Drawing.Size(133, 49);
            this.SendEmailsButton.TabIndex = 4;
            this.SendEmailsButton.Text = "Send Emails";
            this.SendEmailsButton.UseVisualStyleBackColor = false;
            this.SendEmailsButton.Click += new System.EventHandler(this.SendEmailsButton_Click);
            // 
            // AbsentDataGridView
            // 
            this.AbsentDataGridView.AllowUserToAddRows = false;
            this.AbsentDataGridView.AllowUserToDeleteRows = false;
            this.AbsentDataGridView.AllowUserToResizeRows = false;
            this.AbsentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AbsentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AbsentDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.AbsentDataGridView.Location = new System.Drawing.Point(16, 45);
            this.AbsentDataGridView.Name = "AbsentDataGridView";
            this.AbsentDataGridView.ReadOnly = true;
            this.AbsentDataGridView.RowHeadersWidth = 51;
            this.AbsentDataGridView.RowTemplate.Height = 24;
            this.AbsentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AbsentDataGridView.Size = new System.Drawing.Size(580, 355);
            this.AbsentDataGridView.TabIndex = 1;
            // 
            // AbsentStudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(614, 506);
            this.Controls.Add(this.AbsentDataGridView);
            this.Controls.Add(this.SendEmailsButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = global::NTCSAttendanceStaffClient.Properties.Resources.NTCSIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbsentStudentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Absent Students";
            this.Load += new System.EventHandler(this.AbsentStudentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AbsentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Button SendEmailsButton;
        private System.Windows.Forms.DataGridView AbsentDataGridView;
    }
}