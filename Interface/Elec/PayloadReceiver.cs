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
        internal static uint currentDistanceLimit = 0;
        internal string errorLog { get; set; }

        internal PayloadReceiver(byte[] payload) 
        {
            asyncPayloadParser = new AsyncPayloadParser(BeginPayloadParser);
            asyncPayloadParser.BeginInvoke(payload, new AsyncCallback(EndPayloadParser), null);
        }

        private PAYLOAD_HELPER BeginPayloadParser(byte[] fullPayload) 
        {
            try
            {
                PAYLOAD_HELPER payloadHelper = (PAYLOAD_HELPER)fullPayload[0];

                byte[] payload = new byte[fullPayload.Length - 1];
            
                Buffer.BlockCopy(fullPayload, 1, payload, 0, fullPayload.Length - 1);

                switch (payloadHelper)
                {
                    case PAYLOAD_HELPER.SEND_TEXT:
                        Task.Run(() => MessageBox.Show(payloadHelper.ToString() + " " + Encoding.UTF8.GetString(payload)));
                        break;

                    case PAYLOAD_HELPER.SET_LIMIT_DISTANCE:
                        Task.Run(() => MessageBox.Show(payloadHelper.ToString() + " " + Encoding.UTF8.GetString(payload)));
                        break;

                    case PAYLOAD_HELPER.GET_LIMIT_DISTANCE:
                        //https://www.educative.io/edpresso/how-to-convert-an-integer-into-a-specific-byte-array-in-cpp
                        uint limitDistance = (uint) payload[0] << 24;
                        limitDistance |= (uint) payload[1] << 16;
                        limitDistance |= (uint)payload[2] << 8;
                        limitDistance |= (uint) payload[3];
                        currentDistanceLimit = limitDistance;

                        Program.main.Invoke((MethodInvoker)(() =>
                        {
                            Program.main.label8.Text = $"{limitDistance.ToString()} mm";
                        }));

                        break;

                    case PAYLOAD_HELPER.GET_DISTANCE_CAPTED:
                        uint captedDistance = (uint)payload[0] << 24;
                        captedDistance |= (uint)payload[1] << 16;
                        captedDistance |= (uint)payload[2] << 8;
                        captedDistance |= (uint)payload[3];

                        Program.main.Invoke((MethodInvoker)(() =>
                        {
                            Program.main.label7.Text = $"Current distance : {captedDistance} mm";

                            if(currentDistanceLimit > captedDistance)
                                Program.main.guna2Shapes1.FillColor = System.Drawing.Color.Red;
                            else
                                Program.main.guna2Shapes1.FillColor = System.Drawing.Color.Green;

                        }));  
                        break;
                }
                return payloadHelper;
            }
            catch (Exception ex)
            {
                errorLog = ex.ToString();
                return PAYLOAD_HELPER.EXCEPTION;
            }
        }

        private void EndPayloadParser(IAsyncResult ar) 
        {
            PAYLOAD_HELPER payloadHelper = asyncPayloadParser.EndInvoke(ar);

           /* if(payloadHelper == PAYLOAD_HELPER.EXCEPTION)
                Helpers.WriteLog("An error occured : " + errorLog, Program.main.logsRichTextBox, Helpers.ERROR_COLOR);
            else
                Helpers.WriteLog("Payload parsed : " + payloadHelper.ToString(), Program.main.logsRichTextBox, Helpers.SUCCESS_COLOR);*/
        }
    }
}
