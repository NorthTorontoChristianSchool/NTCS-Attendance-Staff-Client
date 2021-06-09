﻿using System;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class MainMenuForm : Form
    {
        public ManageStudentsForm ManageStudents = new ManageStudentsForm();

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close all AtteNTCS windows and exit AtteNTCS?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ManageStudentsButton_Click(object sender, EventArgs e)
        {
            ManageStudents.Show();
            ManageStudents.Focus();
        }

        private void ManageFamiliesButton_Click(object sender, EventArgs e)
        {

        }

        private void AttendanceLogButton_Click(object sender, EventArgs e)
        {

        }

        private void KioskMessagesButton_Click(object sender, EventArgs e)
        {

        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ExitButton.PerformClick();
            }
        }
    }
}
