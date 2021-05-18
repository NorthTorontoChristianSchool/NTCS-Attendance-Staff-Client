using System.Data.SqlClient;
using System.Security;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public static class SqlConnectionInfo
    {
        public static SecureString SecurePassword { get; set; }
        public static SqlCredential Credentials { get; set; }
        public static string ConnectionString { get; set; }
        public static void ShowRuntimeConnectionErrorMessage()
        {
            MessageBox.Show("The connection to the SQL Server failed.\r\n\r\nIf your password was changed, close and reopen the program to log in again using your new password.\r\nOtherwise, make sure that you are connected to a network, and try refreshing this window.", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowRuntimeConnectionErrorMessage(string errorMessage)
        {
            MessageBox.Show($"The connection to the SQL Server failed.\r\nThe error was as follows:\r\n{errorMessage}\r\n\r\nIf your password was changed, close and reopen the program to log in again using your new password.\r\nOtherwise, make sure that you are connected to a network, and try refreshing this window.", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
