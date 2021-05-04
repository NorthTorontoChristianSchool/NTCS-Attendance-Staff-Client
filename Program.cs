using System;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // make a mutex and detect if another instance of the program is running
            bool mutexResult;
            var mutex = new System.Threading.Mutex(true, "UniqueAppId", out mutexResult);

            if (!mutexResult)
            {
                MessageBox.Show("Another instance of the Attendance Mangement Client is already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Make a new login form and run it
            LoginForm login = new LoginForm();
            Application.Run(login);

            // Prevent the mutex from being released by the GC
            GC.KeepAlive(mutex);

            // After the user has logged in successfully, rum the main menu
            if (login.LoginSuccess)
            {
                Application.Run(new MainMenuForm());
            }
        }
    }
}
