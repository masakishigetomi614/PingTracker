using System.Net.NetworkInformation;
using System.Text;

namespace PingTracker
{
    public partial class Form1 : Form
    {
        bool bootFlg = false;
        long sumPing = 0; // 累計Ping時間を保持する変数

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
            double count = 0;
            while (bootFlg)
            {
                count++;
                var displayPing = GetPingValue(count);
                richTextBox1.Focus();
                richTextBox1.AppendText(displayPing.Item1);
                richTextBox2.Focus();
                richTextBox2.AppendText(displayPing.Item2);
                WaitForOneSecond();
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

        private (string, string) GetPingValue(double count)
        {
            Application.DoEvents();
            string host = "google.com"; // Pingを送りたいホスト名またはIPアドレス
            Ping pingSender = new Ping();
            StringBuilder pingStrBld = new StringBuilder();
            StringBuilder avePingStrBld = new StringBuilder();
            long avePing;
            PingReply reply = pingSender.Send(host);
            string pingStr;
            string avePingStr;

            if (reply.Status == IPStatus.Success)
            {
                pingStrBld.Append($"Address: {reply.Address} ");
                pingStrBld.Append($"RTT: {reply.RoundtripTime} ms ");
                pingStrBld.Append($"TTL: {reply.Options.Ttl} ");
                pingStrBld.Append($"BS: {reply.Buffer.Length} ");
                pingStrBld.AppendLine("");
                sumPing += reply.RoundtripTime; // 累積Ping時間を更新
                avePing = (long)(sumPing / count); // 平均Ping時間を計算
                avePingStrBld.AppendLine($"AverageRTT: {avePing} ms ");
            }
            else
            {
                pingStrBld.Append($"Ping failed: {reply.Status}");
                pingStrBld.AppendLine("");
                avePingStrBld.Append($"Ping failed: {reply.Status}");
                avePingStrBld.AppendLine("");
            }
            pingStr = pingStrBld.ToString();
            avePingStr = avePingStrBld.ToString();
            return (pingStr, avePingStr);
        }

        private void WaitForOneSecond()
        {
            // 1000ミリ秒（1秒）待つ
            Thread.Sleep(1000);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
