using System.Reflection;
using System.Windows.Forms;

namespace NTCSAttendanceStaffClient
{
    public static class ControlDoubleBuffering
    {
        /// <summary>
        /// Sets a WinForms control to use double buffering if not connected via RDP.
        /// </summary>
        /// <param name="c">The control to enable double buffering on.</param>
        public static void SetDoubleBuffered(Control c)
        {
            // Don't use double buffering over RDP
            if (SystemInformation.TerminalServerSession)
                return;

            PropertyInfo aProp =
                  typeof(Control).GetProperty(
                        "DoubleBuffered",
                        BindingFlags.NonPublic |
                        BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }
    }
}
