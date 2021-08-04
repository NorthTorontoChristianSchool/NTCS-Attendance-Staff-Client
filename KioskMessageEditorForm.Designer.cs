
namespace NTCSAttendanceStaffClient
{
    partial class KioskMessageEditorForm
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
            this.KioskMessageLabel = new System.Windows.Forms.Label();
            this.KioskMessageTextBox = new System.Windows.Forms.TextBox();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DisplayOrderLabel = new System.Windows.Forms.Label();
            this.DisplayOrderPicker = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayOrderPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(251, 29);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "New Kiosk Message";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePicker.Location = new System.Drawing.Point(106, 268);
            this.StartDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 22);
            this.StartDatePicker.TabIndex = 17;
            // 
            // KioskMessageLabel
            // 
            this.KioskMessageLabel.AutoSize = true;
            this.KioskMessageLabel.Location = new System.Drawing.Point(14, 75);
            this.KioskMessageLabel.Name = "KioskMessageLabel";
            this.KioskMessageLabel.Size = new System.Drawing.Size(103, 17);
            this.KioskMessageLabel.TabIndex = 13;
            this.KioskMessageLabel.Text = "Kiosk Message";
            // 
            // KioskMessageTextBox
            // 
            this.KioskMessageTextBox.AcceptsReturn = true;
            this.KioskMessageTextBox.Location = new System.Drawing.Point(17, 94);
            this.KioskMessageTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.KioskMessageTextBox.MaxLength = 4000;
            this.KioskMessageTextBox.Multiline = true;
            this.KioskMessageTextBox.Name = "KioskMessageTextBox";
            this.KioskMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.KioskMessageTextBox.Size = new System.Drawing.Size(303, 142);
            this.KioskMessageTextBox.TabIndex = 14;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(14, 273);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(61, 17);
            this.StartDateLabel.TabIndex = 16;
            this.StartDateLabel.Text = "between";
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(14, 248);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(278, 17);
            this.MessageLabel.TabIndex = 15;
            this.MessageLabel.Text = "Message will be displayed when the date is";
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDatePicker.Location = new System.Drawing.Point(106, 297);
            this.EndDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 22);
            this.EndDatePicker.TabIndex = 19;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(14, 302);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(32, 17);
            this.EndDateLabel.TabIndex = 18;
            this.EndDateLabel.Text = "and";
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.BackColor = System.Drawing.Color.Red;
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Location = new System.Drawing.Point(17, 335);
            this.CancelFormButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(112, 30);
            this.CancelFormButton.TabIndex = 20;
            this.CancelFormButton.Text = "Cancel [Esc]";
            this.CancelFormButton.UseVisualStyleBackColor = false;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveButton.Location = new System.Drawing.Point(215, 335);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(105, 30);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Save [Ctrl+S]";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DisplayOrderLabel
            // 
            this.DisplayOrderLabel.AutoSize = true;
            this.DisplayOrderLabel.Location = new System.Drawing.Point(14, 48);
            this.DisplayOrderLabel.Name = "DisplayOrderLabel";
            this.DisplayOrderLabel.Size = new System.Drawing.Size(95, 17);
            this.DisplayOrderLabel.TabIndex = 22;
            this.DisplayOrderLabel.Text = "Display Order";
            // 
            // DisplayOrderPicker
            // 
            this.DisplayOrderPicker.Location = new System.Drawing.Point(200, 46);
            this.DisplayOrderPicker.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.DisplayOrderPicker.Name = "DisplayOrderPicker";
            this.DisplayOrderPicker.Size = new System.Drawing.Size(120, 22);
            this.DisplayOrderPicker.TabIndex = 23;
            // 
            // KioskMessageEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(340, 382);
            this.Controls.Add(this.DisplayOrderPicker);
            this.Controls.Add(this.DisplayOrderLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.KioskMessageTextBox);
            this.Controls.Add(this.KioskMessageLabel);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::NTCSAttendanceStaffClient.Properties.Resources.NTCSIcon;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KioskMessageEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Kiosk Message";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StudentEditorForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayOrderPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label KioskMessageLabel;
        private System.Windows.Forms.TextBox KioskMessageTextBox;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label DisplayOrderLabel;
        private System.Windows.Forms.NumericUpDown DisplayOrderPicker;
    }
}