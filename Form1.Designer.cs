namespace PingTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startButton = new Button();
            stopButton = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            richTextBox3 = new RichTextBox();
            label4 = new Label();
            richTextBox4 = new RichTextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Location = new Point(45, 34);
            startButton.Name = "startButton";
            startButton.Size = new Size(100, 41);
            startButton.TabIndex = 1;
            startButton.Text = "start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(151, 34);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(100, 41);
            stopButton.TabIndex = 2;
            stopButton.Text = "stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(45, 105);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(294, 286);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(345, 105);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(189, 286);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 81);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 5;
            label1.Text = "RTT Display";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(345, 81);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 6;
            label2.Text = "Average RTT";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "米国東部 (オハイオ)", "米国東部 (バージニア北部)", "米国西部 (北カリフォルニア)", "米国西部 (オレゴン)", "アフリカ (ケープタウン)", "アジアパシフィック (香港)", "アジアパシフィック (ハイデラバード)", "アジアパシフィック (ジャカルタ)", "アジアパシフィック (マレーシア)", "アジアパシフィック (メルボルン)", "アジアパシフィック (ムンバイ)", "アジアパシフィック (大阪)", "アジアパシフィック (ソウル)", "アジアパシフィック (シンガポール)", "アジアパシフィック (シドニー)", "アジアパシフィック (東京)", "カナダ (中部)", "カナダ西部 (カルガリー)", "欧州 (フランクフルト)", "欧州 (アイルランド)", "欧州 (ロンドン)", "ヨーロッパ (ミラノ)", "欧州 (パリ)", "欧州 (スペイン)", "欧州 (ストックホルム)", "欧州 (チューリッヒ)", "イスラエル (テルアビブ)", "中東 (バーレーン)", "中東 (UAE）", "南米 (サンパウロ)", "AWS GovCloud （米国東部）", "AWS GovCloud （米国西部）" });
            comboBox1.Location = new Point(257, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(277, 23);
            comboBox1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(257, 34);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 8;
            label3.Text = "endpoint";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(540, 105);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(189, 119);
            richTextBox3.TabIndex = 9;
            richTextBox3.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(540, 81);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 10;
            label4.Text = "Highest RTT";
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(540, 272);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(189, 119);
            richTextBox4.TabIndex = 11;
            richTextBox4.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(540, 254);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 12;
            label5.Text = "Lowest RTT";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(richTextBox4);
            Controls.Add(label4);
            Controls.Add(richTextBox3);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Name = "Form1";
            Text = "PingTracker";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button startButton;
        private Button stopButton;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private RichTextBox richTextBox3;
        private Label label4;
        private RichTextBox richTextBox4;
        private Label label5;
    }
}
