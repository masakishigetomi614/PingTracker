using System.Configuration;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PingTracker
{
    public partial class Form1 : Form
    {
        bool bootFlg = false;
        long sumPing = 0; // �݌vPing���Ԃ�ێ�����ϐ�
        List<long> pingList = new List<long>();

        public Form1()
        {
            InitializeComponent();
            startButton.Enabled = true;
            stopButton.Enabled = false;
            comboBox1.SelectedIndex = 15;
        }

        // start�{�^������
        private async void startButton_Click(object sender, EventArgs e)
        {
            bootFlg = true;
            // start�{�^���񊈐���
            startButton.Enabled = false;
            // stop�{�^��������
            stopButton.Enabled = true;

            double count = 0;
            string endPoint = ConfigurationManager.AppSettings[(comboBox1.SelectedIndex + 1).ToString()];

            // Ping�����ʃX���b�h�Ŕ񓯊����s
            await Task.Run(async () =>
            {
                while (bootFlg)
                {
                    count++;
                    var displayPing = GetPingValue(count, endPoint);

                    // UI �X�V�� UI �X���b�h�ōs��
                    Invoke(new Action(() =>
                    {
                        richTextBox1.Focus();
                        richTextBox1.AppendText(displayPing.Item1);
                        richTextBox2.Focus();
                        richTextBox2.AppendText(displayPing.Item2);
                    }));

                    // 1�b�ҋ@�i�񓯊��j
                    await Task.Delay(1000);
                }
            });
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            bootFlg = false;
            // start�{�^��������
            startButton.Enabled = true;
            // stop�{�^���񊈐���
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
                sumPing += reply.RoundtripTime; // �ݐ�Ping���Ԃ��X�V
                avePing = (long)(sumPing / count); // ����Ping���Ԃ��v�Z
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
