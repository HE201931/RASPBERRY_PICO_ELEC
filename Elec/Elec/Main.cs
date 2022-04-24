using Elec.Controls;
using System;
using System.IO.Ports;
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
            new PayloadReceiver(byteBuffer);
        }

        private void sendPortGuna2Button_Click(object sender, EventArgs e)
        {
            try
            {
                new PayloadSender(PAYLOAD_HELPER.SEND_TEXT, textComGuna2TextBox.Text, comPortHandler);
            }
            catch (Exception ex)
            {
                isPortComConnected = false;
                Helpers.WriteLog("Error while sending text to connected com port : " + ex.ToString(), logsRichTextBox, Helpers.ERROR_COLOR);
            }
        }

        private void getCurrentDistanceGuna2Button_Click(object sender, EventArgs e)
        {

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

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
