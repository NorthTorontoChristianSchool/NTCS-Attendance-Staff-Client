using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class ManageFamiliesForm : Form
    {
        private bool SearchActive = false;
        private bool FirstTimeLoaded = false;
        private string SearchString = "";

        public ManageFamiliesForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            HashSet<string> selectedFamilyIDs = new HashSet<string>();
            // Remember which row was selected if refreshing
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in FamilyDataGridView.SelectedRows)
                {
                    selectedFamilyIDs.Add(row.Cells["Family ID"].ToString());
                }
            }

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
                            sqlCmd.CommandText = "SELECT FamilyID AS 'Family ID', Parent1LastName AS 'Parent 1 Last Name', Parent1FirstName AS 'Parent 1 First Name', Parent1Email AS 'Parent 1 Email', Parent2LastName AS 'Parent 2 Last Name', Parent2FirstName AS 'Parent 2 First Name', Parent2Email AS 'Parent 2 Email' FROM Families WHERE (FamilyID LIKE @Search OR CONCAT(Parent1FirstName, ' ', Parent1LastName) LIKE @Search OR CONCAT(Parent2FirstName, ' ', Parent2LastName) LIKE @Search OR Parent1Email LIKE @Search OR Parent2Email LIKE @Search) ORDER BY Parent1LastName";
                            sqlCmd.Parameters.AddWithValue("@Search", "%" + SearchString + "%");
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            FamilyDataGridView.DataSource = dtRecord;
                        }
                    }
                    // default to selecting everything
                    else
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = "SELECT FamilyID AS 'Family ID', Parent1LastName AS 'Parent 1 Last Name', Parent1FirstName AS 'Parent 1 First Name', Parent1Email AS 'Parent 1 Email', Parent2LastName AS 'Parent 2 Last Name', Parent2FirstName AS 'Parent 2 First Name', Parent2Email AS 'Parent 2 Email' FROM Families ORDER BY Parent1LastName";
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            FamilyDataGridView.DataSource = dtRecord;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                SqlErrorDialog.ShowRuntimeConnectionErrorMessage(ex.Message);
            }


            // Re-select the previously selected rows
            bool firstRowSelected = false;
            FamilyDataGridView.ClearSelection();
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in FamilyDataGridView.Rows)
                {
                    if (selectedFamilyIDs.Contains(row.Cells["Family ID"].ToString()))
                    {
                        row.Selected = true;
                        if (!firstRowSelected)
                        {
                            FamilyDataGridView.CurrentCell = row.Cells[0];
                            firstRowSelected = true;
                        }
                    }
                }
            }
            FirstTimeLoaded = true;
        }

        private void ManageFamiliesForm_Load(object sender, EventArgs e)
        {
            // Enable double buffering to reduce the lag when scrolling the DataGridView
            ControlDoubleBuffering.SetDoubleBuffered(FamilyDataGridView);

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

        private void NewFamilyButton_Click(object sender, EventArgs e)
        {
            FamilyEditorForm fef = new FamilyEditorForm();
            fef.ShowDialog();
            RefreshButton.PerformClick();
        }

        // Edit a family when the row in the DataGridView is double-clicked
        private void EditSelectedRow()
        {
            FamilyEditorForm fef = new FamilyEditorForm(FamilyDataGridView.SelectedRows[0].Cells["Family ID"].Value.ToString(), FamilyDataGridView.SelectedRows[0].Cells["Parent 1 Last Name"].Value.ToString(), FamilyDataGridView.SelectedRows[0].Cells["Parent 1 First Name"].Value.ToString(), FamilyDataGridView.SelectedRows[0].Cells["Parent 1 Email"].Value.ToString(), FamilyDataGridView.SelectedRows[0].Cells["Parent 2 Last Name"].Value.ToString(), FamilyDataGridView.SelectedRows[0].Cells["Parent 2 First Name"].Value.ToString(), FamilyDataGridView.SelectedRows[0].Cells["Parent 2 Email"].Value.ToString());
            fef.ShowDialog();
            RefreshButton.PerformClick();
        }

        private void FamilyDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            this.EditSelectedRow();
        }

        private void FamilyDataGridView_KeyDown(object sender, KeyEventArgs e)
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
            if (FamilyDataGridView.SelectedRows.Count == 0)
                return;
            StringBuilder userListOfNamesToDelete = new StringBuilder();
            foreach (DataGridViewRow row in FamilyDataGridView.SelectedRows)
            {
                userListOfNamesToDelete.Append(row.Cells["Family ID"].Value);
                userListOfNamesToDelete.Append("\r\n");
            }

            // Ask the user if they are sure that they want to delete the selected rows
            DialogResult result = MessageBox.Show("Are you sure you want to delete the following families?\r\n\r\n" + userListOfNamesToDelete.ToString() + "\r\nThis action cannot be undone!", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
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
                    foreach (DataGridViewRow row in FamilyDataGridView.SelectedRows)
                    {
                        using (SqlCommand deleteCommand = new SqlCommand())
                        {
                            deleteCommand.Connection = conn;
                            deleteCommand.CommandType = CommandType.Text;
                            deleteCommand.CommandText = "DELETE FROM Families WHERE FamilyID = @DeletingFamilyID";
                            deleteCommand.Parameters.AddWithValue("@DeletingFamilyID", row.Cells["Family ID"].Value);

                            try
                            {
                                deleteCommand.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                MessageBox.Show("An error occured when deleting the family from the database. The following error occured:\r\n" + se.Message, "Error Deleting Family", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ManageFamiliesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                NewFamilyButton.PerformClick();
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

        private void ManageFamiliesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                CloseButton.PerformClick();
            }
        }
    }
}
