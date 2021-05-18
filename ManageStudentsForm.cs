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

                    // command
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.Connection = conn;
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = "SELECT * FROM Students ORDER BY LastName";  // Select all the col's of the Students table
                        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                        DataTable dtRecord = new DataTable();
                        sqlDataAdap.Fill(dtRecord);
                        StudentDataGridView.DataSource = dtRecord;
                    }
                }
            }
            catch (SqlException ex)
            {
                SqlConnectionInfo.ShowRuntimeConnectionErrorMessage(ex.Message);
            }
        }

        private void ManageStudentsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void StudentDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!(MessageBox.Show("Are you sure you want to delete the selected student(s)?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                e.Cancel = true;
            }
        }
    }
}
