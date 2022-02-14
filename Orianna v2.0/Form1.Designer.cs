
namespace Orianna_v2._0
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pic = new Orianna_v2._0.CirclePictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.circlePictureBox1 = new Orianna_v2._0.CirclePictureBox();
            this.userName = new System.Windows.Forms.Label();
            this.progress = new CircularProgressBar.CircularProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            resources.ApplyResources(this.pic, "pic");
            this.pic.Name = "pic";
            this.pic.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // circlePictureBox1
            // 
            this.circlePictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.circlePictureBox1, "circlePictureBox1");
            this.circlePictureBox1.Name = "circlePictureBox1";
            this.circlePictureBox1.TabStop = false;
            // 
            // userName
            // 
            resources.ApplyResources(this.userName, "userName");
            this.userName.BackColor = System.Drawing.Color.Transparent;
            this.userName.Name = "userName";
            // 
            // progress
            // 
            resources.ApplyResources(this.progress, "progress");
            this.progress.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.progress.AnimationSpeed = 0;
            this.progress.BackColor = System.Drawing.Color.Transparent;
            this.progress.ForeColor = System.Drawing.Color.SteelBlue;
            this.progress.InnerColor = System.Drawing.Color.Transparent;
            this.progress.InnerMargin = 2;
            this.progress.InnerWidth = -1;
            this.progress.MarqueeAnimationSpeed = 2000;
            this.progress.Name = "progress";
            this.progress.OuterColor = System.Drawing.Color.SteelBlue;
            this.progress.OuterMargin = -20;
            this.progress.OuterWidth = 22;
            this.progress.ProgressColor = System.Drawing.Color.White;
            this.progress.ProgressWidth = 20;
            this.progress.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.progress.StartAngle = 270;
            this.progress.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progress.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.progress.SubscriptText = "";
            this.progress.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progress.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.progress.SuperscriptText = "";
            this.progress.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.progress.Value = 68;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Name = "label2";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.circlePictureBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CirclePictureBox pic;
        private System.Windows.Forms.Label label1;
        private CirclePictureBox circlePictureBox1;
        private System.Windows.Forms.Label userName;
        private CircularProgressBar.CircularProgressBar progress;
        private System.Windows.Forms.Label label2;
    }
}

