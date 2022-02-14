using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orianna_v2._0
{
    public partial class Create : Form
    {
        string lan;
        string img;
        string nome;
        string sNome;
        string cidade;
        string email;
        int pcd;
        int sa;

        public Create(string texto, string _lan)
        {
            InitializeComponent();
            label1.Text = texto;
            lan = _lan;
            img = Application.StartupPath + "\\image\\default_perfil.png";
        }

        private void Create_Load(object sender, EventArgs e)
        {
            pic.ImageLocation = img;

            if(label1.Text == "Create your account!" || label1.Text == "Crie sua conta!")
            {
                if(lan == "en-US")
                {
                    DialogResult dialogResult = MessageBox.Show("First time using Orianna? If so, you need to install its components! Press Yes to install", "First time?", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        Process.Start($"{Application.StartupPath}\\msi\\01.msi");
                        MessageBox.Show("Install the component and press Ok. 1/6");
                        Process.Start($"{Application.StartupPath}\\msi\\02.msi");
                        MessageBox.Show("Install the component and press Ok. 2/6");
                        Process.Start($"{Application.StartupPath}\\msi\\03.msi");
                        MessageBox.Show("Install the component and press Ok. 3/6");
                        Process.Start($"{Application.StartupPath}\\msi\\04.msi");
                        MessageBox.Show("Install the component and press Ok. 4/6");
                        Process.Start($"{Application.StartupPath}\\msi\\05.msi");
                        MessageBox.Show("Install the component and press Ok. 5/6");
                        Process.Start($"{Application.StartupPath}\\msi\\06.msi");
                        MessageBox.Show("Install the component and press Ok. 6/6");
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Primeria vez usando Orianna? Caso sim, é necessário instalar seus componentes! Aperte Sim para instalar", "Primeira vez?", MessageBoxButtons.YesNo);

                    if(dialogResult == DialogResult.Yes)
                    {
                        Process.Start($"{Application.StartupPath}\\msi\\01.msi");
                        MessageBox.Show("Instale o componente e aperte Ok. 1/6");
                        Process.Start($"{Application.StartupPath}\\msi\\02.msi");
                        MessageBox.Show("Instale o componente e aperte Ok. 2/6");
                        Process.Start($"{Application.StartupPath}\\msi\\03.msi");
                        MessageBox.Show("Instale o componente e aperte Ok. 3/6");
                        Process.Start($"{Application.StartupPath}\\msi\\04.msi");
                        MessageBox.Show("Instale o componente e aperte Ok. 4/6");
                        Process.Start($"{Application.StartupPath}\\msi\\05.msi");
                        MessageBox.Show("Instale o componente e aperte Ok. 5/6");
                        Process.Start($"{Application.StartupPath}\\msi\\06.msi");
                        MessageBox.Show("Instale o componente e aperte Ok. 6/6");
                    }
                }

            }
        }

        private void circleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                img = opf.FileName;
                pic.ImageLocation = img;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nome = textBox1.Text;
            sNome = textBox2.Text;
            cidade = textBox3.Text;
            email = textBox4.Text;

            StreamWriter x;
            x = File.CreateText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\save.txt");
            x.WriteLine(nome);
            x.WriteLine(sNome);
            x.WriteLine(cidade);
            x.WriteLine(email);
            x.WriteLine(pcd);
            x.WriteLine(sa);
            x.WriteLine(img);
            x.Close();

            if(checkStartup.Checked)
            {
                if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\Orianna.lnk"))
                {
                    Shortcut shortcut = new Shortcut();
                    shortcut.CreateShortcut(Application.StartupPath + "\\Orianna v2.0.exe", Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\Orianna.lnk");
                }
            }
            else
            {
                if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\Orianna.lnk"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\Orianna.lnk");
                }
            }
            
            if(!File.Exists(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\language.txt"))
            {
                StreamWriter y;
                y = File.CreateText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\language.txt");
                y.WriteLine("pt-BR");
                y.Close();
            }

            Application.Restart();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pcd = 1;

                if(lan == "en_US")
                    MessageBox.Show("The PCD function releases functions to automate a wheelchair");
                else
                    MessageBox.Show("A função PCD libera funções para automatizar uma cadeira de rodas");
            }
            else
                pcd = 0;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                sa = 1;

                if(lan == "en_US")
                    MessageBox.Show("The Artificial Feelings function simulates feelings for the Assistant");
                else
                    MessageBox.Show("A função Sentimentos Artificiais simula sentimentos para a Assistente");
            }
            else
                sa = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter x;
            x = File.CreateText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\language.txt");
            x.WriteLine("en-US");
            x.Close();
            MessageBox.Show("Language changed. Restarting");
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter x;
            x = File.CreateText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\language.txt");
            x.WriteLine("pt-BR");
            x.Close();
            MessageBox.Show("Linguagem alterada. Reiniciando");
            Application.Restart();
        }
    }
}
