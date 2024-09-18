using System.Configuration;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PingTracker
{
    public partial class Form1 : Form
    {
        bool bootFlg = false;
        long sumPing = 0; // 累計Ping時間を保持する変数
        List<long> pingList = new List<long>();

        public Form1()
        {
            InitializeComponent();
            startButton.Enabled = true;
            stopButton.Enabled = false;
            comboBox1.SelectedIndex = 15;
        }

        // startボタン押下
        private async void startButton_Click(object sender, EventArgs e)
        {
            bootFlg = true;
            // startボタン非活性化
            startButton.Enabled = false;
            // stopボタン活性化
            stopButton.Enabled = true;

            double count = 0;
            string endPoint = ConfigurationManager.AppSettings[(comboBox1.SelectedIndex + 1).ToString()];

            // Ping操作を別スレッドで非同期実行
            await Task.Run(async () =>
            {
                while (bootFlg)
                {
                    count++;
                    var displayPing = GetPingValue(count, endPoint);

                    // UI 更新は UI スレッドで行う
                    Invoke(new Action(() =>
                    {
                        richTextBox1.Focus();
                        richTextBox1.AppendText(displayPing.Item1);
                        richTextBox2.Focus();
                        richTextBox2.AppendText(displayPing.Item2);
                    }));

                    // 1秒待機（非同期）
                    await Task.Delay(1000);
                }
            });
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            bootFlg = false;
            // startボタン活性化
            startButton.Enabled = true;
            // stopボタン非活性化
            stopButton.Enabled = false;
            sumPing = 0;
        }

        private (string, string) GetPingValue(double count, string endPoint)
        {
            Application.DoEvents();
            Ping pingSender = new Ping();
            StringBuilder pingStrBld = new StringBuilder();
            StringBuilder avePingStrBld = new StringBuilder();
            StringBuilder HighestPingStrBld = new StringBuilder();
            StringBuilder LowestStrBld = new StringBuilder();
            long avePing;
            PingReply reply = pingSender.Send(endPoint);
            string pingStr;
            string avePingStr;

            if (reply.Status == IPStatus.Success)
            {
                pingStrBld.Append($"Address: {reply.Address} ");
                pingStrBld.Append($"RTT: {reply.RoundtripTime} ms ");
                pingStrBld.Append($"TTL: {reply.Options?.Ttl} ");
                pingStrBld.Append($"BS: {reply.Buffer.Length} ");
                pingStrBld.AppendLine("");
                sumPing += reply.RoundtripTime; // 累積Ping時間を更新
                avePing = (long)(sumPing / count); // 平均Ping時間を計算
                avePingStrBld.AppendLine($"AverageRTT: {avePing} ms ");
                pingList.Add(reply.RoundtripTime);
                if (pingList.Count > 1)
                {
                    Invoke(new Action(() =>
                    {
                        richTextBox3.Focus();
                        HighestPingStrBld.AppendLine($"HighestRTT: {pingList.Max().ToString()} ms");
                        richTextBox3.Text = HighestPingStrBld.ToString();
                        richTextBox4.Focus();
                        LowestStrBld.AppendLine($"LowestRTT: {pingList.Min().ToString()} ms");
                        richTextBox4.Text = LowestStrBld.ToString();
                    }));
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            richTextBox2.Text = string.Empty;
            richTextBox3.Text = string.Empty;
            richTextBox4.Text = string.Empty;
        }
    }
}
