using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RoyaleCS.Core.Handlers
{
    internal sealed class InputHandler
    {
        internal const int VK_LBUTTON = 0x01;

        internal const int VK_RBUTTON = 0x02;

        internal const int KEYEVENTF_KEYUP = 0x0002;



        [DllImport("user32.dll")]
        internal static extern short GetAsyncKeyState(int vKey);



        internal static bool GetKeyDown(Keys key)
        {
            return GetAsyncKeyState((int)key) != 0;
        }

        internal static bool GetKeyDown(int key)
        {
            return GetAsyncKeyState(key) != 0;
        }

        internal static bool GetLeftMouseButtonDown()
        {
            return GetKeyDown(VK_LBUTTON);
        }

        internal static bool GetRightMouseButtonDown()
        {
            return GetKeyDown(VK_RBUTTON);
        }
    }
}
