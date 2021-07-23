using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class AttendanceLogEditorForm : Form
    {
        public bool EditingExisting = false;

        // Makes an empty form for making a new record
        public AttendanceLogEditorForm()
        {
            InitializeComponent();
            LogTimePicker.Value = DateTime.Now;
            ScanTypeComboBox.SelectedItem = ScanTypeComboBox.Items[0];
        }

        // There is no option to make an already filled-in form for editing.

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Check if the student ID box is empty (it shouldn't be) and show an error message if it is
            if (StudentIDTextBox.Text.Equals(""))
            {
                MessageBox.Show("You must enter a Student ID.", "Student ID Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;

                // Check if the student ID exists, and if it doesn't, show error
                using (SqlCommand selectStudentCommand = new SqlCommand())
                {
                    selectStudentCommand.Connection = conn;
                    selectStudentCommand.CommandType = CommandType.Text;
                    selectStudentCommand.CommandText = "SELECT TOP 1 (FirstName) FROM Students WHERE StudentID = @UserInID";
                    selectStudentCommand.Parameters.AddWithValue("@UserInID", StudentIDTextBox.Text);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader nameReader = selectStudentCommand.ExecuteReader())
                        {
                            if (!nameReader.HasRows)
                            {
                                MessageBox.Show("The Student ID does not exist in the database.", "Student ID Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    catch (SqlException se)
                    {
                        SqlErrorDialog.ShowRuntimeConnectionErrorMessage(se.Message);
                    }
                }

                // Editing existing is not implemented, but I'm too lazy to remove the if statement
                if (EditingExisting)
                {
                    
                }
                else
                {
                    // Make the insert command and insert the data
                    using (SqlCommand insertCommand = new SqlCommand())
                    {
                        insertCommand.Connection = conn;
                        insertCommand.CommandType = CommandType.Text;
                        insertCommand.CommandText = "INSERT INTO AttendanceLog (LogTime, StudentID, ScanLocation, ScanType) VALUES (@NewLogTime, @NewStudentID, @NewScanLocation, @NewScanType)";
                        insertCommand.Parameters.AddWithValue("@NewLogTime", LogTimePicker.Value);
                        insertCommand.Parameters.AddWithValue("@NewStudentID", StudentIDTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewScanLocation", ScanLocationTextBox.Text);
                        switch (ScanTypeComboBox.SelectedItem.ToString())
                        {
                            case "Sign In":
                                insertCommand.Parameters.AddWithValue("@NewScanType", 0);
                                break;
                            case "Sign Out":
                                insertCommand.Parameters.AddWithValue("@NewScanType", 1);
                                break;
                            case "Excused Absence":
                                insertCommand.Parameters.AddWithValue("@NewScanType", 2);
                                break;
                        }


                        // Try it, and if it fails, show the error message
                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            this.Close();
                            return;
                        }
                        catch (SqlException se)
                        {
                            // If it's the violation of the primary key constraint, show the error that tells the user that a student already exists
                            // (Unused for this screen but copied over from the student editor)
                            if (se.Number == 2627)
                            {
                                MessageBox.Show("A student with this student ID already exists in the database.", "Student Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("An error occured when inserting the record into the database. The following error occured:\r\n" + se.Message, "Error Inserting Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return;
                        }
                    }
                }
            }
        }

        // Keyboard shortcuts
        private void StudentEditorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveButton.PerformClick();
            }
        }
    }
}
