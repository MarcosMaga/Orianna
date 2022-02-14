
namespace Orianna_v2._0
{
    partial class Sistema
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sistema));
            this.GeralTimer = new System.Windows.Forms.Timer(this.components);
            this.horaTxt = new System.Windows.Forms.Label();
            this.dateLb = new System.Windows.Forms.Label();
            this.cirRAM = new CircularProgressBar.CircularProgressBar();
            this.cirBAT = new CircularProgressBar.CircularProgressBar();
            this.cityLb = new System.Windows.Forms.Label();
            this.tempLb = new System.Windows.Forms.Label();
            this.rainLb = new System.Windows.Forms.Label();
            this.umiLb = new System.Windows.Forms.Label();
            this.windLb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newsLb = new System.Windows.Forms.Label();
            this.climaLb = new System.Windows.Forms.Label();
            this.timeLb = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.TimerTemp = new System.Windows.Forms.Timer(this.components);
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.TimerNews = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pRAM = new System.Diagnostics.PerformanceCounter();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.emoPic = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btSkill = new System.Windows.Forms.PictureBox();
            this.config = new Orianna_v2._0.CircleButton();
            this.statusImage = new Orianna_v2._0.CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emoPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSkill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusImage)).BeginInit();
            this.SuspendLayout();
            // 
            // GeralTimer
            // 
            this.GeralTimer.Tick += new System.EventHandler(this.GeralTimer_Tick);
            // 
            // horaTxt
            // 
            resources.ApplyResources(this.horaTxt, "horaTxt");
            this.horaTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.horaTxt.ForeColor = System.Drawing.Color.Silver;
            this.horaTxt.Name = "horaTxt";
            // 
            // dateLb
            // 
            resources.ApplyResources(this.dateLb, "dateLb");
            this.dateLb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.dateLb.ForeColor = System.Drawing.Color.Silver;
            this.dateLb.Name = "dateLb";
            // 
            // cirRAM
            // 
            resources.ApplyResources(this.cirRAM, "cirRAM");
            this.cirRAM.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cirRAM.AnimationSpeed = 0;
            this.cirRAM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.cirRAM.ForeColor = System.Drawing.Color.White;
            this.cirRAM.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.cirRAM.InnerMargin = 2;
            this.cirRAM.InnerWidth = -1;
            this.cirRAM.MarqueeAnimationSpeed = 2000;
            this.cirRAM.Name = "cirRAM";
            this.cirRAM.OuterColor = System.Drawing.Color.SteelBlue;
            this.cirRAM.OuterMargin = -20;
            this.cirRAM.OuterWidth = 24;
            this.cirRAM.ProgressColor = System.Drawing.Color.White;
            this.cirRAM.ProgressWidth = 20;
            this.cirRAM.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cirRAM.StartAngle = 270;
            this.cirRAM.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cirRAM.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cirRAM.SubscriptText = "";
            this.cirRAM.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cirRAM.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cirRAM.SuperscriptText = "";
            this.cirRAM.TextMargin = new System.Windows.Forms.Padding(0);
            this.cirRAM.Value = 68;
            // 
            // cirBAT
            // 
            resources.ApplyResources(this.cirBAT, "cirBAT");
            this.cirBAT.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cirBAT.AnimationSpeed = 0;
            this.cirBAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.cirBAT.ForeColor = System.Drawing.Color.White;
            this.cirBAT.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.cirBAT.InnerMargin = 2;
            this.cirBAT.InnerWidth = -1;
            this.cirBAT.MarqueeAnimationSpeed = 2000;
            this.cirBAT.Name = "cirBAT";
            this.cirBAT.OuterColor = System.Drawing.Color.SteelBlue;
            this.cirBAT.OuterMargin = -20;
            this.cirBAT.OuterWidth = 24;
            this.cirBAT.ProgressColor = System.Drawing.Color.White;
            this.cirBAT.ProgressWidth = 20;
            this.cirBAT.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cirBAT.StartAngle = 270;
            this.cirBAT.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cirBAT.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cirBAT.SubscriptText = "";
            this.cirBAT.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cirBAT.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cirBAT.SuperscriptText = "";
            this.cirBAT.TextMargin = new System.Windows.Forms.Padding(0);
            this.cirBAT.Value = 68;
            // 
            // cityLb
            // 
            resources.ApplyResources(this.cityLb, "cityLb");
            this.cityLb.BackColor = System.Drawing.Color.Transparent;
            this.cityLb.ForeColor = System.Drawing.Color.White;
            this.cityLb.Name = "cityLb";
            // 
            // tempLb
            // 
            resources.ApplyResources(this.tempLb, "tempLb");
            this.tempLb.BackColor = System.Drawing.Color.Transparent;
            this.tempLb.ForeColor = System.Drawing.Color.Silver;
            this.tempLb.Name = "tempLb";
            // 
            // rainLb
            // 
            resources.ApplyResources(this.rainLb, "rainLb");
            this.rainLb.BackColor = System.Drawing.Color.Transparent;
            this.rainLb.ForeColor = System.Drawing.Color.Silver;
            this.rainLb.Name = "rainLb";
            // 
            // umiLb
            // 
            resources.ApplyResources(this.umiLb, "umiLb");
            this.umiLb.BackColor = System.Drawing.Color.Transparent;
            this.umiLb.ForeColor = System.Drawing.Color.Silver;
            this.umiLb.Name = "umiLb";
            // 
            // windLb
            // 
            resources.ApplyResources(this.windLb, "windLb");
            this.windLb.BackColor = System.Drawing.Color.Transparent;
            this.windLb.ForeColor = System.Drawing.Color.Silver;
            this.windLb.Name = "windLb";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // newsLb
            // 
            resources.ApplyResources(this.newsLb, "newsLb");
            this.newsLb.BackColor = System.Drawing.Color.Transparent;
            this.newsLb.ForeColor = System.Drawing.Color.Silver;
            this.newsLb.Name = "newsLb";
            this.newsLb.Click += new System.EventHandler(this.newsLb_Click);
            // 
            // climaLb
            // 
            resources.ApplyResources(this.climaLb, "climaLb");
            this.climaLb.BackColor = System.Drawing.Color.Transparent;
            this.climaLb.ForeColor = System.Drawing.Color.Silver;
            this.climaLb.Name = "climaLb";
            // 
            // timeLb
            // 
            resources.ApplyResources(this.timeLb, "timeLb");
            this.timeLb.BackColor = System.Drawing.Color.Transparent;
            this.timeLb.ForeColor = System.Drawing.Color.Silver;
            this.timeLb.Name = "timeLb";
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // TimerTemp
            // 
            this.TimerTemp.Tick += new System.EventHandler(this.TimerTemp_Tick);
            // 
            // webBrowser2
            // 
            resources.ApplyResources(this.webBrowser2, "webBrowser2");
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser2_DocumentCompleted);
            // 
            // TimerNews
            // 
            this.TimerNews.Tick += new System.EventHandler(this.TimerNews_Tick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // pRAM
            // 
            this.pRAM.CategoryName = "Memory";
            this.pRAM.CounterName = "% Committed Bytes in Use";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.LinkColor = System.Drawing.Color.Silver;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.pictureBox2.BackgroundImage = global::Orianna_v2._0.Properties.Resources.mic;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // emoPic
            // 
            resources.ApplyResources(this.emoPic, "emoPic");
            this.emoPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.emoPic.Image = global::Orianna_v2._0.Properties.Resources.normal;
            this.emoPic.Name = "emoPic";
            this.emoPic.TabStop = false;
            this.emoPic.Click += new System.EventHandler(this.emoPic_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btSkill
            // 
            resources.ApplyResources(this.btSkill, "btSkill");
            this.btSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.btSkill.Name = "btSkill";
            this.btSkill.TabStop = false;
            // 
            // config
            // 
            resources.ApplyResources(this.config, "config");
            this.config.Name = "config";
            this.config.UseVisualStyleBackColor = true;
            this.config.Click += new System.EventHandler(this.config_Click);
            // 
            // statusImage
            // 
            resources.ApplyResources(this.statusImage, "statusImage");
            this.statusImage.BackColor = System.Drawing.Color.Red;
            this.statusImage.Name = "statusImage";
            this.statusImage.TabStop = false;
            // 
            // Sistema
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emoPic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.timeLb);
            this.Controls.Add(this.climaLb);
            this.Controls.Add(this.newsLb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.windLb);
            this.Controls.Add(this.umiLb);
            this.Controls.Add(this.rainLb);
            this.Controls.Add(this.tempLb);
            this.Controls.Add(this.cityLb);
            this.Controls.Add(this.cirBAT);
            this.Controls.Add(this.cirRAM);
            this.Controls.Add(this.dateLb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.horaTxt);
            this.Controls.Add(this.config);
            this.Controls.Add(this.statusImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btSkill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Sistema";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sistema_FormClosing);
            this.Load += new System.EventHandler(this.Sistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emoPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSkill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private CircleButton config;
        private CirclePictureBox statusImage;
        private System.Windows.Forms.Timer GeralTimer;
        private System.Windows.Forms.Label horaTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label dateLb;
        private System.Windows.Forms.PictureBox btSkill;
        private CircularProgressBar.CircularProgressBar cirRAM;
        private CircularProgressBar.CircularProgressBar cirBAT;
        private System.Windows.Forms.Label cityLb;
        private System.Windows.Forms.Label tempLb;
        private System.Windows.Forms.Label rainLb;
        private System.Windows.Forms.Label umiLb;
        private System.Windows.Forms.Label windLb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label newsLb;
        private System.Windows.Forms.Label climaLb;
        private System.Windows.Forms.Label timeLb;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Timer TimerTemp;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Timer TimerNews;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox emoPic;
        private System.Diagnostics.PerformanceCounter pRAM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}