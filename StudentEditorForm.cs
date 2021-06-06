using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class StudentEditorForm : Form
    {
        public bool EditingExisting = false;

        // Makes an empty form for making a new student
        public StudentEditorForm()
        {
            InitializeComponent();
            StartDatePicker.Value = DateTime.Now;
            EndDatePicker.Value = DateTime.Now;
        }

        // Makes a filled-in form for editing an existing student
        public StudentEditorForm(string curStudentID, string curFamilyID, string curLastName, string curFirstName, string curHomeroom, string curStudentEmail, string curKioskMessage, DateTime curKioskStart, DateTime curKioskEnd)
        {
            EditingExisting = true;
            InitializeComponent();

            this.Text = "Edit Student";

            // Disable editing in the Student ID text box and grey it out
            StudentIDTextBox.ReadOnly = true;
            StudentIDTextBox.BackColor = SystemColors.Control;

            // Fill in all the information
            TitleLabel.Text = "Edit Student";
            StudentIDTextBox.Text = curStudentID;
            FamilyIDTextBox.Text = curFamilyID;
            LastNameTextBox.Text = curLastName;
            FirstNameTextBox.Text = curFirstName;
            HomeroomTextBox.Text = curHomeroom;
            EmailTextBox.Text = curStudentEmail;
            KioskPersonalMessageTextBox.Text = curKioskMessage;
            StartDatePicker.Value = curKioskStart;
            EndDatePicker.Value = curKioskEnd;
        }

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

                // If we are editing an existing student, use UPDATE instead of INSERT
                if (EditingExisting)
                {
                    // Make the update command and update the data
                    using (SqlCommand updateCommand = new SqlCommand())
                    {
                        updateCommand.Connection = conn;
                        updateCommand.CommandType = CommandType.Text;
                        updateCommand.CommandText = "UPDATE Students SET FamilyID = @NewFamilyID, LastName = @NewLastName, FirstName = @NewFirstName, Homeroom = @NewHomeroom, StudentEmail = @NewStudentEmail, KioskPersonalMessage = @NewKioskPersonalMessage, KioskMessageStartDate = @NewKioskMessageStartDate, KioskMessageExpiryDate = @NewKioskMessageExpiryDate WHERE StudentID = @NewStudentID";
                        updateCommand.Parameters.AddWithValue("@NewStudentID", StudentIDTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewFamilyID", FamilyIDTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewLastName", LastNameTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewFirstName", FirstNameTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewHomeroom", HomeroomTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewStudentEmail", EmailTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewKioskPersonalMessage", KioskPersonalMessageTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewKioskMessageStartDate", StartDatePicker.Value);
                        updateCommand.Parameters.AddWithValue("@NewKioskMessageExpiryDate", EndDatePicker.Value);

                        // Try it, and if it fails, show the error message
                        try
                        {
                            conn.Open();
                            updateCommand.ExecuteNonQuery();
                            this.Close();
                            return;
                        }
                        catch (SqlException se)
                        {
                            MessageBox.Show("An error occured when updating the student into the database. The following error occured:\r\n" + se.Message, "Error Updating Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    // Make the insert command and insert the data
                    using (SqlCommand insertCommand = new SqlCommand())
                    {
                        insertCommand.Connection = conn;
                        insertCommand.CommandType = CommandType.Text;
                        insertCommand.CommandText = "INSERT INTO Students (StudentID, FamilyID, LastName, FirstName, Homeroom, StudentEmail, KioskPersonalMessage, KioskMessageStartDate, KioskMessageExpiryDate) VALUES (@NewStudentID, @NewFamilyID, @NewLastName, @NewFirstName, @NewHomeroom, @NewStudentEmail, @NewKioskPersonalMessage, @NewKioskMessageStartDate, @NewKioskMessageExpiryDate)";
                        insertCommand.Parameters.AddWithValue("@NewStudentID", StudentIDTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewFamilyID", FamilyIDTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewLastName", LastNameTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewFirstName", FirstNameTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewHomeroom", HomeroomTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewStudentEmail", EmailTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewKioskPersonalMessage", KioskPersonalMessageTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewKioskMessageStartDate", StartDatePicker.Value);
                        insertCommand.Parameters.AddWithValue("@NewKioskMessageExpiryDate", EndDatePicker.Value);

                        // Try it, and if it fails, show the error message
                        try
                        {
                            conn.Open();
                            insertCommand.ExecuteNonQuery();
                            this.Close();
                            return;
                        }
                        catch (SqlException se)
                        {
                            // If it's the violation of the primary key constraint, show the error that tells the user that a student already exists
                            if (se.Number == 2627)
                            {
                                MessageBox.Show("A student with this student ID already exists in the database.", "Student Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("An error occured when inserting the student into the database. The following error occured:\r\n" + se.Message, "Error Inserting Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
