using System;
using System.Drawing;
using System.Windows.Forms;

/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

namespace Elec
{
    internal enum PAYLOAD_HELPER : byte
    {
        GET_DISTANCE_CAPTED =   0,
        SEND_TEXT =             1,
        GET_LIMIT_DISTANCE =    2,
        SET_LIMIT_DISTANCE =    3,
        EXCEPTION =             4
    }

    internal class Helpers
    {
        internal static Color SUCCESS_COLOR =   Color.FromArgb(197, 66, 245);
        internal static Color ERROR_COLOR =     Color.FromArgb(66, 182, 245);
        internal static void WriteLog(string text, RichTextBox logBox, Color color) 
        {
            logBox.BeginInvoke(new Action(() => 
            {
                logBox.SelectionColor = color;
                logBox.AppendText(text + "\n");
            }));
        }
    }
}
