using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RoyaleCS.Core.Handlers
{
    internal class WindowHandler
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();


        [DllImport("user32.dll")]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);



        internal static string GetActiveWindowTitle()
        {
            byte value = byte.MaxValue;

            StringBuilder builder = new StringBuilder(value);

            IntPtr handle = GetForegroundWindow();

            return GetWindowText(handle, builder, value) > 0 ? builder.ToString() : null;
        }

        internal static bool TryGetCSGOWindow()
        {
            string result = GetActiveWindowTitle();

            return result != null && result.Equals(Information.PROCESS_FULLNAME);
        }

        internal static bool TryGetActiveWindowByName(string name)
        {
            string result;
            return (result = GetActiveWindowTitle()) != null && result.Equals(name);
        }
    }
}
