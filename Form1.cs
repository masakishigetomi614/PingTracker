using System.Net.NetworkInformation;
using System.Text;

namespace PingTracker
{
    public partial class Form1 : Form
    {
        bool bootFlg = false;

        public Form1()
        {
            InitializeComponent();
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        // startボタン押下
        private void startButton_Click(object sender, EventArgs e)
        {
            bootFlg = true;
            // startボタン非活性化
            startButton.Enabled = false;
            // stopボタン活性化
            stopButton.Enabled = true;
            while (bootFlg)
            {
                richTextBox1.Text += GetPingValue().Item1;
                richTextBox2.Text += GetPingValue().Item2;
            }
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            bootFlg = false;
            // startボタン活性化
            startButton.Enabled = true;
            // stopボタン非活性化
            stopButton.Enabled = false;
        }

        private static (string, string) GetPingValue()
        {
            Application.DoEvents();
            string host = "google.com"; // Pingを送りたいホスト名またはIPアドレス
            Ping pingSender = new Ping();
            StringBuilder pingStrBld = new StringBuilder();
            StringBuilder avePingStrBld = new StringBuilder();
            double avePing;
            PingReply reply = pingSender.Send(host);
            double count = 0;
            string pingStr;
            string avePingStr;

            if (reply.Status == IPStatus.Success)
            {
                pingStrBld.Append($"Address: {reply.Address} ");
                pingStrBld.Append($"RoundTrip time: {reply.RoundtripTime} ms ");
                pingStrBld.Append($"Time to live: {reply.Options.Ttl} ");
                pingStrBld.Append($"Buffer size: {reply.Buffer.Length} ");
                pingStrBld.AppendLine("");
                count++;
                avePing = (+reply.RoundtripTime / count);
                avePingStrBld.AppendLine($"Average RoundTrip time:{avePing}");
            }
            else
            {
                pingStrBld.Append($"Ping failed: {reply.Status}");
                pingStrBld.AppendLine("");
            }
            pingStr = pingStrBld.ToString();
            avePingStr = avePingStrBld.ToString();
            return (pingStr, avePingStr);
        }
    }
}
