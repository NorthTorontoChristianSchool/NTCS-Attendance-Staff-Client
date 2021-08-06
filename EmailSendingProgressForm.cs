using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public partial class EmailSendingProgressForm : Form
    {
        private string SmtpServer;
        private string FromEmailAddress;
        private string Password;
        private int Port;
        private bool UseSsl;

        public EmailSendingProgressForm(string smtpServer, string fromEmailAddress, string password, int port, bool ssl)
        {
            SmtpServer = smtpServer;
            FromEmailAddress = fromEmailAddress;
            Password = password;
            Port = port;
            UseSsl = ssl;

            InitializeComponent();
        }

        private void SendEmails()
        {
            List<string[]> absentStudents = new List<string[]>();
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                {
                    // supply the credentials to the connection
                    conn.Credential = SqlConnectionInfo.Credentials;
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.Connection = conn;
                        conn.Open();

                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = "SELECT StudentID, FamilyID, FirstName, LastName, Homeroom FROM Students WHERE StudentID NOT IN (SELECT StudentID FROM AttendanceLog WHERE LogTime > CONVERT(date, GETDATE()))";
                        using (SqlDataReader reader = sqlCmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    absentStudents.Add(new string[] {
                                        reader[0].ToString(),
                                        reader[1].ToString(),
                                        reader[2].ToString(),
                                        reader[3].ToString(),
                                        reader[4].ToString()
                                    });
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    string parent1First = "";
                    string parent1Last = "";
                    string parent1Email = "";
                    string parent2First = "";
                    string parent2Last = "";
                    string parent2Email = "";

                    foreach (string[] curStudent in absentStudents)
                    {

                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = "SELECT Parent1FirstName, Parent1LastName, Parent1Email, Parent2FirstName, Parent2LastName, Parent2Email FROM Families WHERE FamilyID = @Search";
                            sqlCmd.Parameters.AddWithValue("@Search", curStudent[1]);
                            using (SqlDataReader reader = sqlCmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        parent1First = reader[0].ToString();
                                        parent1Last = reader[1].ToString();
                                        parent1Email = reader[2].ToString();
                                        parent2First = reader[3].ToString();
                                        parent2Last = reader[4].ToString();
                                        parent2Email = reader[5].ToString();
                                    }

                                retryEmail:
                                    try
                                    {
                                        MailMessage mail = new MailMessage();
                                        SmtpClient smtp = new SmtpClient(SmtpServer);
                                        mail.From = new MailAddress(FromEmailAddress);
                                        mail.To.Add(parent1Email);
                                        mail.To.Add(parent2Email);
                                        mail.Subject = $"Student sign in reminder for {curStudent[2]} {curStudent[3]} in {curStudent[4]}";
                                        mail.Body = $@"Dear {parent1First} {parent1Last} and {parent2First} {parent2Last},

{curStudent[2]} {curStudent[3]} in {curStudent[4]} has not signed in today. Please contact your child to ensure they have safely arrived at school. Also, please contact the office if your child has encountered any technical problems when signing in.

Best regards,
NTCS Office";
                                        smtp.Port = Port;
                                        smtp.Credentials = new NetworkCredential(FromEmailAddress, Password);
                                        smtp.EnableSsl = UseSsl;

                                        smtp.Send(mail);
                                    }
                                    catch (Exception ex)
                                    {
                                        var response = MessageBox.Show("An error occured while the email was being sent. The error was:\r\n" + ex.Message + "\r\nWould you like to retry?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                        if (response == DialogResult.Yes)
                                        {
                                            goto retryEmail;
                                        }
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                SqlErrorDialog.ShowRuntimeConnectionErrorMessage(ex.Message);
            }

            MessageBox.Show("Email sending complete.", "Sending Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EmailSendingProgressForm_Shown(object sender, EventArgs e)
        {
            EmailBackgroundWorker.RunWorkerAsync();
        }

        private void EmailBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SendEmails();
        }

        private void EmailBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
