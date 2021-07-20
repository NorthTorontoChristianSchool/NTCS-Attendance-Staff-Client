using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class ManageAttendanceLogForm : Form
    {
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
                            sqlCmd.CommandText = "SELECT AttendanceLog.LogTime AS 'Log Time', AttendanceLog.StudentID AS 'Student ID', Students.LastName AS 'Last Name', Students.FirstName AS 'First Name', AttendanceLog.ScanLocation AS 'Scan Location', AttendanceLog.ScanType AS 'Scan Type Int', (SELECT CASE AttendanceLog.ScanType WHEN 0 THEN 'Sign In' WHEN 1 THEN 'Sign Out' WHEN 3 THEN 'Excused Absence' ELSE AttendanceLog.ScanType END FROM AttendanceLog) FROM AttendanceLog, Students WHERE AttendanceLog.StudentID = Students.StudentID ORDER BY LogTime DESC";
                            sqlCmd.Parameters.AddWithValue("@Search", "%" + SearchString + "%");
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            StudentDataGridView.DataSource = dtRecord;
                        }
                    }
                    // default to selecting everything
                    else
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = "SELECT AttendanceLog.LogTime AS 'Log Time', AttendanceLog.StudentID AS 'Student ID', Students.LastName AS 'Last Name', Students.FirstName AS 'First Name', AttendanceLog.ScanLocation AS 'Scan Location', AttendanceLog.ScanType AS 'Scan Type Int', (SELECT ELT(ScanType + 1, 'Sign In', 'Sign Out', 'Excused Absence') FROM AttendanceLog) FROM AttendanceLog, Students WHERE AttendanceLog.StudentID = Students.StudentID ORDER BY LogTime DESC";
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            StudentDataGridView.DataSource = dtRecord;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                SqlErrorDialog.ShowRuntimeConnectionErrorMessage(ex.Message);
            }
        }

        private void ManageStudentsForm_Load(object sender, EventArgs e)
        {
            // Enable double buffering to reduce the lag when scrolling the DataGridView
            ControlDoubleBuffering.SetDoubleBuffered(StudentDataGridView);

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
            StudentEditorForm sef = new StudentEditorForm();
            sef.ShowDialog();
            RefreshButton.PerformClick();
        }

        // Edit a student when the row in the DataGridView is double-clicked
        private void EditSelectedRow()
        {
            StudentEditorForm sef = new StudentEditorForm(StudentDataGridView.SelectedRows[0].Cells["Student ID"].Value.ToString(), StudentDataGridView.SelectedRows[0].Cells["Family ID"].Value.ToString(), StudentDataGridView.SelectedRows[0].Cells["Last Name"].Value.ToString(), StudentDataGridView.SelectedRows[0].Cells["First Name"].Value.ToString(), StudentDataGridView.SelectedRows[0].Cells["Homeroom"].Value.ToString(), StudentDataGridView.SelectedRows[0].Cells["Student Email"].Value.ToString(), StudentDataGridView.SelectedRows[0].Cells["Kiosk Personal Message"].Value.ToString(), DateTime.Parse(StudentDataGridView.SelectedRows[0].Cells["Kiosk Message Start Date"].Value.ToString()), DateTime.Parse(StudentDataGridView.SelectedRows[0].Cells["Kiosk Message Expiry Date"].Value.ToString()));
            sef.ShowDialog();
            RefreshButton.PerformClick();
        }

        private void StudentDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            this.EditSelectedRow();
        }

        private void StudentDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.EditSelectedRow();
            }
        }

        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            // Loop through the selected names to gather a list of names that will be deleted
            if (StudentDataGridView.SelectedRows.Count == 0)
                return;
            StringBuilder userListOfNamesToDelete = new StringBuilder();
            foreach (DataGridViewRow row in StudentDataGridView.SelectedRows)
            {
                userListOfNamesToDelete.Append(row.Cells["Student ID"].Value);
                userListOfNamesToDelete.Append("\t");
                userListOfNamesToDelete.Append(row.Cells["First Name"].Value);
                userListOfNamesToDelete.Append(' ');
                userListOfNamesToDelete.Append(row.Cells["Last Name"].Value);
                userListOfNamesToDelete.Append("\r\n");
            }

            // Ask the user if they are sure that they want to delete the selected rows
            DialogResult result = MessageBox.Show("Are you sure you want to delete the following students?\r\n\r\n" + userListOfNamesToDelete.ToString() + "\r\nThis action cannot be undone!", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
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
                    foreach (DataGridViewRow row in StudentDataGridView.SelectedRows)
                    {
                        using (SqlCommand deleteCommand = new SqlCommand())
                        {
                            deleteCommand.Connection = conn;
                            deleteCommand.CommandType = CommandType.Text;
                            deleteCommand.CommandText = "DELETE FROM Students WHERE StudentID = @DeletingStudentID";
                            deleteCommand.Parameters.AddWithValue("@DeletingStudentID", row.Cells["Student ID"].Value);

                            try
                            {
                                deleteCommand.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                MessageBox.Show("An error occured when deleting the student from the database. The following error occured:\r\n" + se.Message, "Error Deleting Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ManageStudentsForm_KeyDown(object sender, KeyEventArgs e)
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

        private void ManageStudentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                CloseButton.PerformClick();
            }
        }
    }
}
