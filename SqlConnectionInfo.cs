using System.Data.SqlClient;
using System.Security;

namespace NTCSAttendanceStaffClient
{
    public static class SqlConnectionInfo
    {
        public static SecureString SecurePassword { get; set; }
        public static SqlCredential Credentials { get; set; }
        public static string ConnectionString { get; set; }
    }
}