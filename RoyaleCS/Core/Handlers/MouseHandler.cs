using System.Runtime.InteropServices;

namespace RoyaleCS.Core.Handlers
{
    internal class MouseHandler
    {
        internal const int MOUSEEVENTF_LEFTDOWN = 2;

        internal const int MOUSEEVENTF_LEFTUP = 4;



        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern void Mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);



        internal static void ImitateClick()
        {
            Mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);

            Mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }
}
