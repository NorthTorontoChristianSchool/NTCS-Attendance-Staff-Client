using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class AbsentStudentsForm : Form
    {
        public bool SendEmailShow = false;

        public AbsentStudentsForm()
        {
            InitializeComponent();
        }

        private void AbsentStudentsForm_Load(object sender, EventArgs e)
        {
            ControlDoubleBuffering.SetDoubleBuffered(AbsentDataGridView);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                {
                    // supply the credentials to the connection
                    conn.Credential = SqlConnectionInfo.Credentials;
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.Connection = conn;
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = "SELECT StudentID AS 'Student ID', LastName AS 'Last Name', FirstName AS 'First Name', Homeroom AS 'Homeroom' FROM Students WHERE StudentID NOT IN (SELECT StudentID FROM AttendanceLog WHERE LogTime > CONVERT(date, GETDATE()))";
                        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                        DataTable dtRecord = new DataTable();
                        sqlDataAdap.Fill(dtRecord);

                        // Disable the send emails button if there are no absent students
                        if (dtRecord.Rows.Count == 0)
                        {
                            SendEmailsButton.Enabled = false;
                        }

                        AbsentDataGridView.DataSource = dtRecord;
                    }
                }
            }
            catch (SqlException ex)
            {
                SqlErrorDialog.ShowRuntimeConnectionErrorMessage(ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SendEmailsButton_Click(object sender, EventArgs e)
        {
            SendEmailShow = true;
            Close();
        }
    }
}
