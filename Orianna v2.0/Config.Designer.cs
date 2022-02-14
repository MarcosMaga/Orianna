
namespace Orianna_v2._0
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.Temp = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.climaLb = new System.Windows.Forms.Label();
            this.btSkill = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btSkill)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // buttonApply
            // 
            this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this.buttonApply, "buttonApply");
            this.buttonApply.ForeColor = System.Drawing.Color.White;
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            // 
            // climaLb
            // 
            this.climaLb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            resources.ApplyResources(this.climaLb, "climaLb");
            this.climaLb.ForeColor = System.Drawing.Color.Silver;
            this.climaLb.Name = "climaLb";
            // 
            // btSkill
            // 
            this.btSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            resources.ApplyResources(this.btSkill, "btSkill");
            this.btSkill.Name = "btSkill";
            this.btSkill.TabStop = false;
            // 
            // Config
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.climaLb);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSkill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Config";
            ((System.ComponentModel.ISupportInitialize)(this.btSkill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Temp;
        private System.Windows.Forms.PictureBox btSkill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label climaLb;
    }
}