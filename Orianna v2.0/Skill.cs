using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace Orianna_v2._0
{
    public partial class Skill : Form
    {
        Sistema s;
        int indice=0;

        string[] englishText = { "Command added successfully", "No command or response added", "No commands created", "Removed" };
        string[] portText = { "Comando adicionado com sucesso", "Nenhum comando oou resposta adicionada", "Sem comandos criados", "Removido" };

        string[] text;

        public Skill(Sistema sis)
        {
            InitializeComponent();
            s = sis;

            if (s.lan == "en-US")
                text = englishText;
            else
                text = portText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s.SaveSkill();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cmdTxt.Text != "" || rpsTxt.Text != "")
            {
                s.skill.Add(cmdTxt.Text.ToLower());
                s.resp.Add(rpsTxt.Text.ToLower());
                lbStatus.Text = text[0];
                cmdTxt.Text = "";
                rpsTxt.Text = "";
            }
            else
            {
                lbStatus.Text = text[1];
            }
        }

        private void Skill_Load(object sender, EventArgs e)
        {
            if(s.skill.Count != 0)
            {
                lbRemove.Text = s.skill[indice];
            }
            else
            {
                lbRemove.Text = text[2];
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(s.skill.Count != 0)
            {
                if (indice >= s.skill.Count - 1)
                {
                    indice = 0;
                }
                else
                {
                    indice++;
                }
                lbRemove.Text = s.skill[indice];
            }
            else
            {
                lbRemove.Text = text[2];
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(s.skill.Count != 0)
            {
                if (indice <= 0)
                {
                    indice = s.skill.Count - 1;
                }
                else
                {
                    indice--;
                }
                lbRemove.Text = s.skill[indice];
            }
            else
            {
                lbRemove.Text = text[2];
            }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(lbRemove.Text != text[3])
            {
                for(int i=0; i < s.skill.Count; i++)
                {
                    if(s.skill[indice] == s.skill[i])
                    {
                        s.skill.RemoveAt(i);
                        s.resp.RemoveAt(i);
                    }
                }
            }
            
            lbRemove.Text = text[3];
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog opf = new FolderBrowserDialog();

            if (opf.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands"))
                {
                    try
                    {
                        ZipFile.CreateFromDirectory(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands", opf.SelectedPath + "\\Commands.orianna");
                    }
                    catch
                    {
                        try
                        {
                            File.Delete(opf.SelectedPath + "\\Commands.orianna");
                            ZipFile.CreateFromDirectory(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands", opf.SelectedPath + "\\Commands.orianna");
                        }
                        catch
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
            }
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.Filter = "Orianna Commands |*.orianna";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                File.Delete(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\rps.txt");
                File.Delete(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\cmd.txt");
                ZipFile.ExtractToDirectory(opf.FileName, Application.StartupPath + "\\Perfil\\Commands");
                Application.Restart();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;

            if (s.lan == "en-US")
                dialogResult = MessageBox.Show("Do you really want to delete all skills?", "Wait!", MessageBoxButtons.YesNo);
            else
                dialogResult = MessageBox.Show("Você realmente deseja deletar todas habilidades?", "Espere!", MessageBoxButtons.YesNo);

            if(dialogResult == DialogResult.Yes)
            {
                File.Delete(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\rps.txt");
                File.Delete(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\cmd.txt");
                Directory.Delete(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands");
                Application.Restart();
            }
        }
    }
}
