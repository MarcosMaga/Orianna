using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Orianna_v2._0
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string culture = "pt-BR";

            if (File.Exists(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\language.txt"))
            {
                StreamReader x;
                x = File.OpenText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\language.txt");
                culture = x.ReadLine();
                x.Close();
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            }

            if (!Directory.Exists(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil"))
            {
                Directory.CreateDirectory((Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil"));
            }

            if (File.Exists(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\save.txt"))
            {
                Application.Run(new Form1(culture));
            }
            else
            {
                if (culture == "en-US")
                    Application.Run(new Create("Create your account!", culture));
                else
                    Application.Run(new Create("Crie sua conta!", culture));
            }
        }
    }
}
