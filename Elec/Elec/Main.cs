using Elec.Controls;
using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

namespace Elec
{
    //  The default baud rate is 115200, 9600
    //https://www.tomshardware.com/how-to/program-raspberry-pi-pico-with-arduino-ide
    //https://www.codeproject.com/Questions/1207905/Reading-serial-port-in-Csharp
    public partial class Main : FormPattern
    {
        internal bool isPortComConnected { get; set; }
        public Main()
        {
            InitializeComponent();
            foreach (string port in SerialPort.GetPortNames()) 
            {
                comPortGuna2ComboBox.Items.Add(port);   
            }
            isPortComConnected = false;
        }
        private void comPortGuna2Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isPortComConnected)
                {
                    comPortHandler.PortName = comPortGuna2ComboBox.Text;
                    comPortHandler.BaudRate = int.Parse(baudsGuna2TextBox.Text);
                    comPortHandler.Open();
                    Helpers.WriteLog("Successfully connected to : " + comPortGuna2ComboBox.Text, logsRichTextBox, Helpers.SUCCESS_COLOR);
                    isPortComConnected = true;
                    comPortGuna2Button.Text = "Disconnect !";
                }
                else 
                {
                    comPortHandler.Close();
                    Helpers.WriteLog("Successfully disconnected to : " + comPortGuna2ComboBox.Text, logsRichTextBox, Helpers.SUCCESS_COLOR);
                    isPortComConnected = false;
                    comPortGuna2Button.Text = "Disconnect !";
                }
            }
            catch (Exception ex)
            {
                isPortComConnected = false;
                Helpers.WriteLog("Error while trying to connect with com port : " + ex.ToString(), logsRichTextBox, Helpers.ERROR_COLOR);
            }
        }

        private void comPortHandler_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int intBuffer;
            intBuffer = comPortHandler.BytesToRead;
            byte[] byteBuffer = new byte[intBuffer];
            comPortHandler.Read(byteBuffer, 0, intBuffer);
            comPortHandler.DiscardInBuffer();
            comPortHandler.DiscardOutBuffer();
            new PayloadHelper((byte[])byteBuffer.Clone());
        }

        private void sendPortGuna2Button_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] textByte = Encoding.UTF8.GetBytes(textComGuna2TextBox.Text);
                byte[] fullPayload = new byte[textByte.Length + 1];
                fullPayload[0] = (byte)PAYLOAD_HELPER.SEND_TEXT;
                Array.Copy(textByte, 0, fullPayload, 1, textByte.Length);
                comPortHandler.Write(fullPayload, 0, fullPayload.Length);
                Helpers.WriteLog("Successfully text sent to com port !", logsRichTextBox, Helpers.SUCCESS_COLOR);
            }
            catch (Exception ex)
            {
                isPortComConnected = false;
                Helpers.WriteLog("Error while sending text to connected com port : " + ex.ToString(), logsRichTextBox, Helpers.ERROR_COLOR);
            }
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.FindForm().Handle, 161, 2, 0);
        }

        private void closeGuna2Button_Click(object sender, EventArgs e)
        {
            comPortHandler.Close();
            this.Close();
        }
    }
}
