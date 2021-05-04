using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class MainMenuForm : Form
    {
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
            Application.Exit();
        }

        private void ManageStudentsButton_Click(object sender, EventArgs e)
        {
            ManageStudentsForm manageStudents = new ManageStudentsForm();
            this.Hide();
            manageStudents.ShowDialog();
            this.Show();
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
    }
}
