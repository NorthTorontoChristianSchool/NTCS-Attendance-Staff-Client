using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class ManageAttendanceLogForm : Form
    {
        // There is no ability to edit student records. It is intentional.

        private bool SearchActive = false;
        private string SearchString = "";

        public ManageAttendanceLogForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                {
                    // supply the credentials to the connection
                    conn.Credential = SqlConnectionInfo.Credentials;

                    // use parameterized query if searching
                    if (SearchActive)
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = $"SELECT TOP {(int)MaxResultsCounter.Value} AttendanceLog.LogTime AS 'Log Time', AttendanceLog.StudentID AS 'Student ID', Students.LastName AS 'Last Name', Students.FirstName AS 'First Name', AttendanceLog.ScanLocation AS 'Scan Location', AttendanceLog.ScanType AS 'Scan Type Int', CASE WHEN AttendanceLog.ScanType = 0 THEN 'Sign In' WHEN AttendanceLog.ScanType = 1 THEN 'Sign Out' WHEN AttendanceLog.ScanType = 2 THEN 'Excused Absence' ELSE 'Unknown' END AS 'Scan Type' FROM AttendanceLog, Students WHERE AttendanceLog.StudentID = Students.StudentID AND (AttendanceLog.StudentID LIKE @Search OR AttendanceLog.ScanLocation LIKE @Search OR CONCAT(Students.FirstName, ' ', Students.LastName) LIKE @Search OR CASE WHEN ScanType = 0 THEN 'Sign In' WHEN AttendanceLog.ScanType = 1 THEN 'Sign Out' WHEN AttendanceLog.ScanType = 2 THEN 'Excused Absence' ELSE 'Unknown' END LIKE @Search) ORDER BY LogTime DESC";
                            sqlCmd.Parameters.AddWithValue("@Search", "%" + SearchString + "%");
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            AttendanceDataGridView.DataSource = dtRecord;
                        }
                    }
                    // default to selecting everything
                    else
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = $"SELECT TOP {(int)MaxResultsCounter.Value} AttendanceLog.LogTime AS 'Log Time', AttendanceLog.StudentID AS 'Student ID', Students.LastName AS 'Last Name', Students.FirstName AS 'First Name', AttendanceLog.ScanLocation AS 'Scan Location', AttendanceLog.ScanType AS 'Scan Type Int', CASE WHEN AttendanceLog.ScanType = 0 THEN 'Sign In' WHEN AttendanceLog.ScanType = 1 THEN 'Sign Out' WHEN AttendanceLog.ScanType = 2 THEN 'Excused Absence' ELSE 'Unknown' END AS 'Scan Type' FROM AttendanceLog, Students WHERE AttendanceLog.StudentID = Students.StudentID ORDER BY LogTime DESC";
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            AttendanceDataGridView.DataSource = dtRecord;
                        }
                    }
                }

                // Hide the 'Scan Type Int' column
                AttendanceDataGridView.Columns["Scan Type Int"].Visible = false;
            }
            catch (SqlException ex)
            {
                SqlErrorDialog.ShowRuntimeConnectionErrorMessage(ex.Message);
            }
        }

        private void ManageAttendanceLogForm_Load(object sender, EventArgs e)
        {
            // Enable double buffering to reduce the lag when scrolling the DataGridView
            ControlDoubleBuffering.SetDoubleBuffered(AttendanceDataGridView);

            // Load the data
            this.LoadData();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            SearchBox.Text = SearchString;
            this.LoadData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchActive = true;
            SearchActiveLabel.Show();
            SearchString = SearchBox.Text;
            this.LoadData();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton.PerformClick();
            }
        }

        private void MaxResultsCounter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshButton.PerformClick();
            }
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            SearchActive = false;
            SearchActiveLabel.Hide();
            SearchString = "";
            SearchBox.Text = "";
            this.LoadData();
        }

        private void NewStudentButton_Click(object sender, EventArgs e)
        {
            AttendanceLogEditorForm alef = new AttendanceLogEditorForm();
            alef.ShowDialog();
            RefreshButton.PerformClick();
        }

        private void AttendanceDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            // Ask the user if they are sure that they want to delete the selected rows
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected attendance records?\r\nThis action cannot be undone!", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                {
                    conn.Credential = SqlConnectionInfo.Credentials;
                    try
                    {
                        conn.Open();
                    }
                    catch (SqlException se)
                    {
                        SqlErrorDialog.ShowRuntimeConnectionErrorMessage(se.Message);
                    }

                    // Loop through the selected rows and delete each one
                    foreach (DataGridViewRow row in AttendanceDataGridView.SelectedRows)
                    {
                        using (SqlCommand deleteCommand = new SqlCommand())
                        {
                            deleteCommand.Connection = conn;
                            deleteCommand.CommandType = CommandType.Text;
                            deleteCommand.CommandText = "DELETE TOP(1) FROM AttendanceLog WHERE StudentID = @DeletingStudentID AND LogTime = @DeletingLogTime AND ScanType = @DeletingScanType";
                            deleteCommand.Parameters.AddWithValue("@DeletingStudentID", row.Cells["Student ID"].Value);
                            deleteCommand.Parameters.AddWithValue("@DeletingLogTime", row.Cells["Log Time"].Value);
                            deleteCommand.Parameters.AddWithValue("@DeletingScanType", row.Cells["Scan Type Int"].Value);

                            try
                            {
                                deleteCommand.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                MessageBox.Show("An error occured when deleting the record from the database. The following error occured:\r\n" + se.Message, "Error Deleting Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

            }
            RefreshButton.PerformClick();
        }

        // Hide, don't actually close
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Program.MainMenu.WindowState = FormWindowState.Normal;
            Program.MainMenu.Focus();
            this.Hide();
        }

        // Keyboard shortcuts
        private void ManageAttendanceLogForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                NewAttendanceRecordButton.PerformClick();
            }
            else if (e.KeyCode == Keys.F3)
            {
                this.ActiveControl = SearchBox;
            }
            else if (e.KeyCode == Keys.F5)
            {
                RefreshButton.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedButton.PerformClick();
            }
        }

        private void ManageAttendanceLogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                CloseButton.PerformClick();
            }
        }

        private void AttendanceDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("The editing of attendance records is not supported.", "Cannot Edit Attendance Records");
        }
    }
}
