using System;
using System.Runtime.InteropServices;

/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

namespace Elec
{
    internal class NativeHelper
    {
        private const string user32 = "user32.dll"; 
        [DllImport(user32)]
        internal extern static bool ReleaseCapture();
        [DllImport(user32)]
        internal extern static IntPtr SendMessage(IntPtr a, int msg, int wParam, int lParam);
    }
}
