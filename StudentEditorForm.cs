using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            // Disable editing in the Student ID text box and grey it out
            StudentIDTextBox.ReadOnly = true;
            StudentIDTextBox.BackColor = SystemColors.Window;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;

                if (EditingExisting)
                {

                }
                else
                {
                    // check if there is 
                    using (SqlCommand insertCommand = new SqlCommand())
                    {
                        insertCommand.Connection = conn;
                        insertCommand.CommandType = CommandType.Text;
                        insertCommand.CommandText = "INSERT INTO Students (StudentID, FamilyID, LastName, FirstName, Homeroom, StudentEmail, KioskPersonalMessage, KioskMessageStartDate, KioskMessageExpiryDate) VALUES (@NewStudentID, @NewFamilyID, @NewFirstName, @NewLastName, @NewHomeroom, @NewStudentEmail, @NewKioskPersonalMessage, @NewKioskMessageStartDate, @NewKioskMessageExpiryDate)";
                        insertCommand.Parameters.AddWithValue("@NewStudentID", StudentIDTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewFamilyID", FamilyIDTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewLastName", LastNameTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewFirstName", FirstNameTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewHomeroom", HomeroomTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewStudentEmail", StudentIDTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewKioskPersonalMessage", KioskPersonalMessageTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewKioskMessageStartDate", StartDatePicker.Value);
                        insertCommand.Parameters.AddWithValue("@NewKioskMessageExpiryDate", EndDatePicker.Value);

                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            this.Close();
                            return;
                        }
                        catch (SqlException se)
                        {
                            //if 
                            MessageBox.Show("A student with this student ID already exists in the database.", "Student Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }
    }
}
