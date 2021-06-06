using System;
using System.Threading;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    static class Program
    {
        public static MainMenuForm MainMenu;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // make a mutex and detect if another instance of the program is running
            Mutex mutex = new Mutex(true, "AtteNTCSMutex", out bool mutexResult);

            if (!mutexResult)
            {
                MessageBox.Show("Another instance of the Attendance Mangement Client is already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Make a new login form and run it
            LoginForm login = new LoginForm();
            Application.Run(login);

            // Prevent the mutex from being released by the GC
            GC.KeepAlive(mutex);

            // After the user has logged in successfully, run the main menu
            if (login.LoginSuccess)
            {
                MainMenu = new MainMenuForm();
                Application.Run(MainMenu);
            }
        }
    }
}
