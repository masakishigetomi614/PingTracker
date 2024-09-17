using System.Net.NetworkInformation;
using System.Text;

namespace PingTracker
{
    public partial class Form1 : Form
    {
        bool boolFlg = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Text += DisplayPing(boolFlg = true);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DisplayPing(boolFlg = false);
        }

        private static string DisplayPing(bool bootFlg)
        {
            string result = string.Empty;
            // stopボタンを活性化
            Button button2 = new Button();
            button2.Enabled = false;
            // 起動フラグがTRUEの場合
            if (bootFlg) {
                string host = "google.com"; // Pingを送りたいホスト名またはIPアドレス
                Ping pingSender = new Ping();
                StringBuilder pingStr = new StringBuilder();
                PingReply reply = pingSender.Send(host);

                if (reply.Status == IPStatus.Success)
                {
                    pingStr.Append($"Address: {reply.Address} ");
                    pingStr.Append($"RoundTrip time: {reply.RoundtripTime} ms ");
                    pingStr.Append($"Time to live: {reply.Options.Ttl} ");
                    pingStr.Append($"Buffer size: {reply.Buffer.Length} ");
                    pingStr.AppendLine("");
                }
                else
                {
                    pingStr.Append($"Ping failed: {reply.Status}");
                    pingStr.AppendLine("");
                }
                result = pingStr.ToString();
            }
            // 起動フラグがFALSEの場合
            else
            {
                result = string.Empty;
            }
            return result;
        }
    }
}
