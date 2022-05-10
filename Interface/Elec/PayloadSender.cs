using System;
using System.IO.Ports;
using System.Text;

/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

namespace Elec
{
    internal class PayloadSender
    {
        private delegate PAYLOAD_HELPER SendPayloadAsync(PAYLOAD_HELPER payloadType, object payload, SerialPort serialPort);
        private SendPayloadAsync sendPayloadAsync;
        internal PayloadSender(PAYLOAD_HELPER payloadType, object payload, SerialPort serialPort) 
        {
            sendPayloadAsync = new SendPayloadAsync(BeginPayloadSender);
            sendPayloadAsync.BeginInvoke(payloadType, payload, serialPort, new AsyncCallback(EndPayloadSender), null);
        }

        private PAYLOAD_HELPER BeginPayloadSender(PAYLOAD_HELPER payloadType, object payload, SerialPort serialPort) 
        {
            byte[] fullPayload;
            switch (payloadType) 
            {
                case PAYLOAD_HELPER.SEND_TEXT:
                    byte[] textByte = Encoding.UTF8.GetBytes(payload.ToString());
                    fullPayload = new byte[textByte.Length + 1];

                    fullPayload[0] = (byte)PAYLOAD_HELPER.SEND_TEXT;
                    Array.Copy(textByte, 0, fullPayload, 1, textByte.Length);
                    lock (serialPort) 
                    {
                        serialPort.Write(fullPayload, 0, fullPayload.Length);
                    }
                    break;

                case PAYLOAD_HELPER.SET_LIMIT_DISTANCE:
                    byte[] intByte = BitConverter.GetBytes(int.Parse(payload.ToString()));
                    fullPayload = new byte[intByte.Length + 1];
                    fullPayload[0] = (byte)PAYLOAD_HELPER.SET_LIMIT_DISTANCE;
                    Array.Copy(intByte, 0, fullPayload, 1, intByte.Length);
                    lock (serialPort)
                    {
                        serialPort.Write(fullPayload, 0, fullPayload.Length);
                    }
                    break;

                case PAYLOAD_HELPER.GET_LIMIT_DISTANCE:
                    fullPayload = new byte[1];
                    fullPayload[0] = (byte)PAYLOAD_HELPER.GET_LIMIT_DISTANCE;
                    lock (serialPort)
                    {
                        serialPort.Write(fullPayload, 0, fullPayload.Length);
                    }

                    break;
            }
            return payloadType;
        }

        private void EndPayloadSender(IAsyncResult ar) 
        {
            PAYLOAD_HELPER payloadHelper = sendPayloadAsync.EndInvoke(ar);
            Helpers.WriteLog("Payload send : " + payloadHelper.ToString(), Program.main.logsRichTextBox, Helpers.SUCCESS_COLOR);
        }
    }
}
