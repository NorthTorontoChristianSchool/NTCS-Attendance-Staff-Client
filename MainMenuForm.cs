using System;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class MainMenuForm : Form
    {
        public ManageStudentsForm ManageStudents = new ManageStudentsForm();
        public ManageFamiliesForm ManageFamilies = new ManageFamiliesForm();
        public ManageAttendanceLogForm ManageAttendance = new ManageAttendanceLogForm();
        public ManageKioskMessagesForm ManageKioskMessages = new ManageKioskMessagesForm();

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
            // Show a confirmation before exiting
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
            ManageFamilies.Show();
            ManageFamilies.Focus();
        }

        private void AttendanceLogButton_Click(object sender, EventArgs e)
        {
            ManageAttendance.Show();
            ManageAttendance.Focus();
        }

        private void KioskMessagesButton_Click(object sender, EventArgs e)
        {
            ManageKioskMessages.Show();
            ManageKioskMessages.Focus();
        }

        private void SendEmailsButton_Click(object sender, EventArgs e)
        {

        }

        // Click the exit button when closing so that the confirmation dialog pops up
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
