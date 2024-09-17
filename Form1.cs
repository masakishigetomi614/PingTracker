using System.Net.NetworkInformation;
using System.Text;

namespace PingTracker
{
    public partial class Form1 : Form
    {
        bool bootFlg = false;
        long sumPing = 0; // �݌vPing���Ԃ�ێ�����ϐ�

        public Form1()
        {
            InitializeComponent();
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        // start�{�^������
        private void startButton_Click(object sender, EventArgs e)
        {
            bootFlg = true;
            // start�{�^���񊈐���
            startButton.Enabled = false;
            // stop�{�^��������
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
            // start�{�^��������
            startButton.Enabled = true;
            // stop�{�^���񊈐���
            stopButton.Enabled = false;
        }

        private (string, string) GetPingValue(double count)
        {
            Application.DoEvents();
            string host = "google.com"; // Ping�𑗂肽���z�X�g���܂���IP�A�h���X
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
                sumPing += reply.RoundtripTime; // �ݐ�Ping���Ԃ��X�V
                avePing = (long)(sumPing / count); // ����Ping���Ԃ��v�Z
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
            // 1000�~���b�i1�b�j�҂�
            Thread.Sleep(1000);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
