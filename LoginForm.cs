using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security;

namespace NTCSAttendanceStaffClient
{
    public partial class LoginForm : Form
    {
        public bool LoginSuccess { get; private set; }

        public LoginForm()
        {
            InitializeComponent();

            // Load the saved login info
            if (Properties.Settings.Default.RememberLoginInfo)
            {
                RememberCheckBox.Checked = true;
                ServerBox.Text = Properties.Settings.Default.ServerAddress;
                UsernameBox.Text = Properties.Settings.Default.Username;
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
            Application.Exit();
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
                Properties.Settings.Default.RememberLoginInfo = true;
                Properties.Settings.Default.ServerAddress = ServerBox.Text;
                Properties.Settings.Default.Username = UsernameBox.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberLoginInfo = false;
                Properties.Settings.Default.ServerAddress = "";
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Save();
            }

            // Build the SQL connection string and store it
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                ["Server"] = ServerBox.Text,
                ["Database"] = "studentmanagement",  // hard coded name of database
                ["Trusted_Connection"] = "false",    // Won't support Windows Authentication at this time
                ["Connection Timeout"] = 5
            };
            SqlConnectionInfo.ConnectionString = builder.ToString();

            // Turn the string in the PasswordBox into a SecureString
            // (this is bad practice, but I don't know
            // how else to get the password)
            SqlConnectionInfo.SecurePassword = new SecureString();
            foreach (char ch in PasswordBox.Text)
            {
                SqlConnectionInfo.SecurePassword.AppendChar(ch);
            }
            SqlConnectionInfo.SecurePassword.MakeReadOnly();

            SqlConnectionInfo.Credentials = new SqlCredential(UsernameBox.Text, SqlConnectionInfo.SecurePassword);

            bool success = false;
            // Test the connection
            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                try
                {
                    conn.Credential = SqlConnectionInfo.Credentials;
                    conn.Open();
                    conn.Close();
                    success = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login failed. The following error occured:\r\n" + ex.Message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (success)
            {
                LoginSuccess = true;
                // hopefully the password is gone (it probably isn't but whatever)
                PasswordBox.Dispose();
                GC.Collect();
                Close();
            }
        }
    }
}
