using System;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class EmailDetailsForm : Form
    {
        public EmailDetailsForm()
        {
            InitializeComponent();

            // Load the saved login info
            if (Properties.Settings.Default.RememberEmailLogin)
            {
                RememberCheckBox.Checked = true;
                ServerBox.Text = Properties.Settings.Default.SmtpServer;
                UsernameBox.Text = Properties.Settings.Default.SmtpFromEmail;
                PortSelector.Value = Properties.Settings.Default.SmtpPort;
                UseSslCheckBox.Checked = Properties.Settings.Default.SmtpEnableSsl;
                this.ActiveControl = PasswordBox;
            }

            // Add a handler to the textbox to detect when Enter is pressed
            this.ServerBox.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
            this.UsernameBox.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
            this.PasswordBox.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
        }

        // Exit when exit button is clicked
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Click the Login button if Enter is pressed while the text boxes are selected
        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginButton.PerformClick();
            }
        }

        // Login button action
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Remember or forget the login info based on the user's choice
            if (RememberCheckBox.Checked)
            {
                Properties.Settings.Default.RememberEmailLogin = true;
                Properties.Settings.Default.SmtpServer = ServerBox.Text;
                Properties.Settings.Default.SmtpFromEmail = UsernameBox.Text;
                Properties.Settings.Default.SmtpPort = Convert.ToInt32(PortSelector.Value);
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberEmailLogin = false;
                Properties.Settings.Default.SmtpServer = "";
                Properties.Settings.Default.SmtpFromEmail = "";
                Properties.Settings.Default.SmtpPort = 587;
                Properties.Settings.Default.Save();
            }

            // Start the EmailSendingProgressForm to start the sending
            EmailSendingProgressForm emailSending = new EmailSendingProgressForm(ServerBox.Text, UsernameBox.Text, PasswordBox.Text, Convert.ToInt32(PortSelector.Value), UseSslCheckBox.Checked);
            emailSending.ShowDialog();
            this.Close();
        }
    }
}
