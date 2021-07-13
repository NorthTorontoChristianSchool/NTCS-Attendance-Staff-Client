using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class FamilyEditorForm : Form
    {
        public bool EditingExisting = false;

        // Makes an empty form for making a new family
        public FamilyEditorForm()
        {
            InitializeComponent();
        }

        // Makes a filled-in form for editing an existing family
        public FamilyEditorForm(string curFamilyID, string curP1LastName, string curP1FirstName, string curP1Email, string curP2LastName, string curP2FirstName, string curP2Email)
        {
            EditingExisting = true;
            InitializeComponent();

            this.Text = "Edit Family";

            // Disable editing in the Family ID text box and grey it out
            FamilyIDTextBox.ReadOnly = true;
            FamilyIDTextBox.BackColor = SystemColors.Control;

            // Fill in all the information
            TitleLabel.Text = "Edit Family";
            FamilyIDTextBox.Text = curFamilyID;

            P1LastNameTextBox.Text = curP1LastName;
            P1FirstNameTextBox.Text = curP1FirstName;
            P1EmailTextBox.Text = curP1Email;

            P2LastNameTextBox.Text = curP2LastName;
            P2FirstNameTextBox.Text = curP2FirstName;
            P2EmailTextBox.Text = curP2Email;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Check if the family ID box is empty (it shouldn't be) and show an error message if it is
            if (FamilyIDTextBox.Text.Equals(""))
            {
                MessageBox.Show("You must enter a Family ID.", "Family ID Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;

                // If we are editing an existing family, use UPDATE instead of INSERT
                if (EditingExisting)
                {
                    // Make the update command and update the data
                    using (SqlCommand updateCommand = new SqlCommand())
                    {
                        updateCommand.Connection = conn;
                        updateCommand.CommandType = CommandType.Text;
                        updateCommand.CommandText = "UPDATE Families SET Parent1LastName = @NewP1LN, Parent1FirstName = @NewP1FN, Parent1Email = @NewP1Email, Parent2LastName = @NewP2LN, Parent2FirstName = @NewP2FN, Parent2Email = @NewP2Email WHERE FamilyID = @NewFamilyID";
                        updateCommand.Parameters.AddWithValue("@NewFamilyID", FamilyIDTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewP1LN", P1LastNameTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewP1FN", P1FirstNameTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewP1Email", P1EmailTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewP2LN", P2LastNameTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewP2FN", P2FirstNameTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewP2Email", P2EmailTextBox.Text);

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
                        insertCommand.CommandText = "INSERT INTO Families (FamilyID, Parent1LastName, Parent1FirstName, Parent1Email, Parent2LastName, Parent2FirstName, Parent2Email) VALUES (@NewFamilyID, @NewP1LN, @NewP1FN, @NewP1Email, @NewP2LN, @NewP2FN, @NewP2Email)";
                        insertCommand.Parameters.AddWithValue("@NewFamilyID", FamilyIDTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewP1LN", P1LastNameTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewP1FN", P1FirstNameTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewP1Email", P1EmailTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewP2LN", P2LastNameTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewP2FN", P2FirstNameTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewP2Email", P2EmailTextBox.Text);

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
                            // If it's the violation of the primary key constraint, show the error that tells the user that a family already exists
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
        private void FamilyEditorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveButton.PerformClick();
            }
        }
    }
}
