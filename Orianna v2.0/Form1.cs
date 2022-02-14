using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Orianna_v2._0
{
    public partial class Form1 : Form
    {
        string lan;
        string nome;
        string sNome;
        string cidade;
        string email;
        string img;
        int pcd;
        int sa;

        int i;

        Timer timer = new Timer
        {
            Interval = 50
        };

        public Form1(string _lan)
        {
            InitializeComponent();
            lan = _lan;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader x;
            x = File.OpenText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\save.txt");
            nome = x.ReadLine();
            sNome = x.ReadLine();
            cidade = x.ReadLine();
            email = x.ReadLine();
            pcd = int.Parse(x.ReadLine());
            sa = int.Parse(x.ReadLine());
            img = x.ReadLine();
            x.Close();

            pic.ImageLocation = img;
            userName.Text = nome;
            timer.Enabled = true;
            timer.Tick += new System.EventHandler(timer_tick);
            progress.Value = 0;
        }

        public void timer_tick(object sender, EventArgs e)
        {
            if(i <=100)
            {
                progress.Value = i;
                progress.Text = i.ToString() + "%";
                i+= 4;
            }
            else
            {
                Sistema f = new Sistema(nome, sNome, cidade, email, img, lan, pcd, sa);
                f.Show();
                System.Threading.Thread.Sleep(1000);
                timer.Enabled = false;
                this.Hide();
                this.Visible = false;
            }

            if(i >= 99)
            {
                label2.Text = "CARREGADO!";
            }
        }

    }
}
