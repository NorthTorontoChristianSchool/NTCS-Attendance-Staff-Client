using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class KioskMessageEditorForm : Form
    {
        public bool EditingExisting = false;

        private int OldDisplayOrder;
        private string OldDisplayMessage;
        private DateTime OldStartDate;
        private DateTime OldExpiryDate;

        // Makes an empty form for making a new student
        public KioskMessageEditorForm()
        {
            InitializeComponent();
            StartDatePicker.Value = DateTime.Now;
            EndDatePicker.Value = DateTime.Now;
        }

        // Makes a filled-in form for editing an existing student
        public KioskMessageEditorForm(int displayOrder, string displayMessage, DateTime startDate, DateTime expiryDate)
        {
            EditingExisting = true;
            InitializeComponent();

            this.Text = "Edit Kiosk Message";

            // Remember stuff
            OldDisplayOrder = displayOrder;
            OldDisplayMessage = displayMessage;
            OldStartDate = startDate;
            OldExpiryDate = expiryDate;

            // Fill in all the information
            DisplayOrderPicker.Value = displayOrder;
            KioskMessageTextBox.Text = displayMessage;
            StartDatePicker.Value = startDate;
            EndDatePicker.Value = expiryDate;
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

                // If we are editing an existing message, use UPDATE instead of INSERT
                if (EditingExisting)
                {
                    // Make the update command and update the data
                    using (SqlCommand updateCommand = new SqlCommand())
                    {
                        updateCommand.Connection = conn;
                        updateCommand.CommandType = CommandType.Text;
                        updateCommand.CommandText = $"UPDATE TOP(1) KioskPublicMessages SET DisplayOrder = {(int)DisplayOrderPicker.Value}, DisplayMessage = @NewDisplayMessage, StartDate = @NewStartDate, ExpiryDate = @NewExpiryDate WHERE DisplayOrder = {OldDisplayOrder} AND DisplayMessage = @OldDisplayMessage AND StartDate = @OldStartDate AND ExpiryDate = @OldExpiryDate";
                        updateCommand.Parameters.AddWithValue("@NewDisplayMessage", KioskMessageTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewStartDate", StartDatePicker.Value);
                        updateCommand.Parameters.AddWithValue("@NewExpiryDate", EndDatePicker.Value);
                        updateCommand.Parameters.AddWithValue("@OldDisplayMessage", OldDisplayMessage);
                        updateCommand.Parameters.AddWithValue("@OldStartDate", OldStartDate);
                        updateCommand.Parameters.AddWithValue("@OldExpiryDate", OldExpiryDate);


                        // Try it, and if it fails, show the error message
                        try
                        {
                            conn.Open();
                            updateCommand.ExecuteNonQuery();
                            conn.Close();
                            this.Close();
                            return;
                        }
                        catch (SqlException se)
                        {
                            MessageBox.Show("An error occured when updating the kiosk message into the database. The following error occured:\r\n" + se.Message, "Error Updating Kiosk Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        insertCommand.CommandText = $"INSERT INTO KioskPublicMessages (DisplayOrder, DisplayMessage, StartDate, ExpiryDate) VALUES ({(int)DisplayOrderPicker.Value}, @NewDisplayMessage, @NewStartDate, @NewExpiryDate)";
                        insertCommand.Parameters.AddWithValue("@NewDisplayMessage", KioskMessageTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewStartDate", StartDatePicker.Value);
                        insertCommand.Parameters.AddWithValue("@NewExpiryDate", EndDatePicker.Value);

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
                            MessageBox.Show("An error occured when inserting the kiosk message into the database. The following error occured:\r\n" + se.Message, "Error Inserting Kiosk Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
