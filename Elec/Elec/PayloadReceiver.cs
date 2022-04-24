using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

namespace Elec
{
    internal class PayloadReceiver
    {
        private delegate PAYLOAD_HELPER AsyncPayloadParser(byte[] payload);
        private AsyncPayloadParser asyncPayloadParser;

        internal PayloadReceiver(byte[] payload) 
        {
            asyncPayloadParser = new AsyncPayloadParser(BeginPayloadParser);
            asyncPayloadParser.BeginInvoke(payload, new AsyncCallback(EndPayloadParser), null);
        }

        private PAYLOAD_HELPER BeginPayloadParser(byte[] fullPayload) 
        {
            PAYLOAD_HELPER payloadHelper = (PAYLOAD_HELPER)fullPayload[0];

            byte[] payload = new byte[fullPayload.Length - 1];

            Buffer.BlockCopy(fullPayload, 1, payload, 0, fullPayload.Length - 1);

            switch (payloadHelper)
            {
                case PAYLOAD_HELPER.SEND_TEXT:
                    Task.Run(() => MessageBox.Show(payloadHelper.ToString() + " " + Encoding.UTF8.GetString(payload)));
                    break;
            }
            return payloadHelper;
        }

        private void EndPayloadParser(IAsyncResult ar) 
        {
            PAYLOAD_HELPER payloadHelper = asyncPayloadParser.EndInvoke(ar);
            Helpers.WriteLog("Payload parsed : " + payloadHelper.ToString(), Program.main.logsRichTextBox, Helpers.SUCCESS_COLOR);
        }
    }
}
