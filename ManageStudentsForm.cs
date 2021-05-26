using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NTCSAttendanceStaffClient
{
    public partial class ManageStudentsForm : Form
    {
        private bool SearchActive = false;
        private string SearchString = "";

        public ManageStudentsForm()
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
                            sqlCmd.CommandText = "SELECT StudentID AS 'Student ID', FamilyID AS 'Family ID', LastName AS 'Last Name', FirstName AS 'First Name', Homeroom, StudentEmail AS 'Student Email', KioskPersonalMessage AS 'Kiosk Personal Message', KioskMessageStartDate AS 'Kiosk Message Start Date', KioskMessageExpiryDate AS 'Kiosk Message Expiry Date' FROM Students WHERE (StudentID LIKE @Search OR FamilyID LIKE @Search OR CONCAT(FirstName, ' ', LastName) LIKE @Search OR Homeroom LIKE @Search OR StudentEmail LIKE @Search OR KioskPersonalMessage LIKE @Search) ORDER BY LastName";
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
                            sqlCmd.CommandText = "SELECT StudentID AS 'Student ID', FamilyID AS 'Family ID', LastName AS 'Last Name', FirstName AS 'First Name', Homeroom, StudentEmail AS 'Student Email', KioskPersonalMessage AS 'Kiosk Personal Message', KioskMessageStartDate AS 'Kiosk Message Start Date', KioskMessageExpiryDate AS 'Kiosk Message Expiry Date' FROM Students ORDER BY LastName";
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
                SqlError.ShowRuntimeConnectionErrorMessage(ex.Message);
            }
        }

        private void ManageStudentsForm_Load(object sender, EventArgs e)
        {
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
            SearchString = SearchBox.Text;
            this.LoadData();
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            SearchActive = false;
            SearchString = "";
            SearchBox.Text = "";
            this.LoadData();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
