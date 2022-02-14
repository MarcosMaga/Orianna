using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Speech.Synthesis;
using Microsoft.Speech.Recognition;
using System.Net.Mail;
using System.Threading;

namespace Orianna_v2._0
{
    public partial class Sistema : Form
    {
        [DllImport("wininet.dll")]
        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue);

        int indice = 0;
        int timer = 100, timerSearch = 360, timerCall = 0, timerSleep = 0;

        int pcd, sa, count = 1;

        bool internet;
        bool chamando;
        bool comando;
        bool repouso;

        public string com = "";
        public string lan;

        Data date = new Data();
        string frase;
        string temp;
        string climate;
        string rain;
        string humidity;
        string wind;

        string cidade;
        string img;
        string nome, sNome, email;

        string action;

        List<string> news = new List<string>();
        List<string> newsLink = new List<string>();

        static SpeechRecognitionEngine reco;
        static CultureInfo ci;
        SpeechSynthesizer fala = new SpeechSynthesizer();

        public SerialPort cx = new SerialPort();

        public List<string> skill = new List<string>();
        public List<string> resp = new List<string>();

        Feelings sentimentos = new Feelings();
        Cripto cripto = new Cripto();

        //string[] listaPalavras = { "orianna", "sim", "não", "que horas são", "que dia é hoje", "obrigado", "temperatura atual", "relatorio", "desligar sistema", "desligar computador", "nada", "silencio", "desligar computador", "licença", "minimize", "para que você serve", "cala boca", "tudo bem", "socorro", "enviar email de emergência", "reiniciar computador", "reiniciar sistema", "bom dia", "boa tarde", "boa noite", "desculpa", "oi", "olá", "modo repouso", "abrir noticia", "parar", "para frente", "para trás", "girar para esquerda", "girar para direita"};
        List<string> listaPalavras = new List<string>();
        List<string> speech = new List<string>();
        public Sistema(string _nome, string _sNome, string _cidade, string _email, string _img, string _lan, int _pcd, int _sa)
        {
            InitializeComponent();
            GeralTimer.Enabled = true;
            img = _img;
            cidade = _cidade;
            nome = _nome;
            sNome = _sNome;
            email = _email;
            pcd = _pcd;
            sa = _sa;
            lan = _lan;
            IniSkill();
        }

        public void Gramatica()
        {
            ci = new CultureInfo(lan);
            reco = new SpeechRecognitionEngine(ci);

            var gramatica = new Choices();

            if(lan == "en-US")
            {
                string value = Properties.Resources.reco_enUS;
                string[] values = value.Split(';');

                for (int i = 0; i < values.Length; i++)
                    if (values[i].Trim() != "")
                        listaPalavras.Add(values[i].Trim());
            }
            else
            {
                string value = Properties.Resources.reco_ptBR;
                string[] values = value.Split(';');

                for (int i = 0; i < values.Length; i++)
                    if(values[i].Trim() != "")
                        listaPalavras.Add(values[i].Trim());
            }

            for (int i = 0; i < listaPalavras.Count; i++)
                Console.WriteLine((i+1).ToString() + ". " + listaPalavras[i]);

            gramatica.Add(listaPalavras.ToArray());

            if(skill.Count != 0)
            {
                gramatica.Add(skill.ToArray());
            }

            var gb = new GrammarBuilder();
            gb.Append(gramatica);


            try
            {
                var g = new Grammar(gb);

                try
                {
                    reco.RequestRecognizerUpdate();
                    reco.LoadGrammarAsync(g);
                    reco.SpeechRecognized += Sre_Reconhecimento;
                    reco.SetInputToDefaultAudioDevice();
                    reco.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                {
                    fala.SpeakAsync(speech[0]);
                }

            }
            catch
            {
                fala.SpeakAsync(speech[0]);
            }
        }

        private void Sistema_Load(object sender, EventArgs e)
        {
            Image foto = Image.FromFile(img);
            sentimentos.Init(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil", sa);
            config.BackgroundImage = foto;
        
            try
            {
                fala.SetOutputToDefaultAudioDevice();

                if (lan == "en-US")
                {
                    fala.SelectVoice("Microsoft Zira Desktop");
                    string value2 = Properties.Resources.speech_enUS;
                    string[] values2 = value2.Split(';');

                    for (int i = 0; i < values2.Length; i++)
                        if (values2[i].Trim() != "")
                            speech.Add(values2[i].Trim());
                }
                else
                {
                    fala.SelectVoice("Microsoft Maria Desktop");
                    string value2 = Properties.Resources.speech_ptBR;
                    string[] values2 = value2.Split(';');

                    for (int i = 0; i < values2.Length; i++)
                        if (values2[i].Trim() != "")
                            speech.Add(values2[i].Trim());
                }

                fala.Rate = 3;
                fala.SpeakAsync($"{speech[1]} {sNome}.");
                fala.SpeakAsync(speech[2]);
            }
            catch
            {
                MessageBox.Show("Falha ao criar sintetizador de voz");
            }

            Gramatica();
        }

        void Sre_Reconhecimento(object sender, SpeechRecognizedEventArgs e)
        {
            timerCall = 0;
            if(fala.State != SynthesizerState.Speaking)
            {
                frase = e.Result.Text;
                Console.WriteLine(frase);
            }
            else
            {
                frase = "";
            }

            if(!repouso)
            {
                if(frase == listaPalavras[0])
                { 
                    string[] compri = { speech[3], speech[4], speech[5] + " " + sNome, speech[6]};
                    chamando = true;
                    Random rand = new Random();
                    int num = rand.Next(0, compri.Length - 1);
                    fala.SpeakAsync(compri[num]);
                }
            }

            if(chamando && !comando)
            {
                for(int i=0; i < skill.Count; i++)
                {
                    if(frase.Equals(skill[i]))
                    {
                        fala.SpeakAsync(Decode(resp[i]));
                        break;
                    }
                }

                if(pcd == 1)
                {
                    if (frase.Equals(listaPalavras[30]))
                    {
                        fala.SpeakAsync(speech[7]);
                        SerialSend(cx, "0");
                    }
                    else if (frase.Equals(listaPalavras[31]))
                    {
                        fala.SpeakAsync("");
                        SerialSend(cx, "1");
                    }
                    else if (frase.Equals(listaPalavras[32]))
                    {
                        fala.SpeakAsync("");
                        SerialSend(cx, "2");
                    }
                    else if (frase.Equals(listaPalavras[33]))
                    {
                        fala.SpeakAsync(speech[8]);
                        SerialSend(cx, "3");
                    }
                    else if (frase.Equals(listaPalavras[34]))
                    {
                        fala.SpeakAsync(speech[9]);
                        SerialSend(cx, "4");
                    }
                    else if (frase.Equals(listaPalavras[35]))
                    {
                        SerialSend(cx, "5");
                    }
                    else if(frase.Equals(listaPalavras[36]))
                    {
                        SerialSend(cx, "6");
                    }

                    
                }

                if(frase.Equals(listaPalavras[22]) || frase.Equals(listaPalavras[23]) || frase.Equals(listaPalavras[24]))
                {
                    int hora = int.Parse(DateTime.Now.ToString("HH"));

                    if(hora >= 1 && hora <= 11)
                    {
                        fala.SpeakAsync(speech[10] + sNome);
                        fala.SpeakAsync(speech[11]);
                        action = "REL";
                        comando = true;
                    }
                    else
                    {
                        if (hora >= 12 && hora < 18)
                        {
                            fala.SpeakAsync(speech[12] + sNome);
                        }
                        else if(hora >= 18 || hora == 0)
                        {
                            fala.SpeakAsync($"{speech[13]} {sNome}");
                        }

                        fala.SpeakAsync(speech[14]);
                    }

                    sentimentos.Up(3);
                }
                else if(frase.Equals(listaPalavras[26]) || frase.Equals(listaPalavras[27]))
                {
                    Random rand = new Random();
                    int num = rand.Next(0, 100);
                    sentimentos.Up(1);

                    if(num <= 50)
                    {
                        fala.SpeakAsync(speech[15]);
                    }
                    else
                    {
                        fala.SpeakAsync($"{speech[15]} {sNome}, {speech[16]}");
                        action = "TDB";
                        comando = true;
                    }
                }
                else if (frase.Equals(listaPalavras[5]))
                {
                    fala.SpeakAsync($"{speech[17]} {sNome}");
                    sentimentos.Up(2);
                    chamando = false;
                }
                else if (frase.Equals(listaPalavras[3]))
                {
                    fala.SpeakAsync($"{speech[18]} {DateTime.Now.ToString("HH:mm:ss")}");
                }
                else if (frase.Equals(listaPalavras[4]))
                {
                    fala.SpeakAsync($"{speech[19]} {DateTime.Now.ToString("dd/MM/yyyy")}");
                }
                else if (frase.Equals(listaPalavras[6]))
                {
                    fala.SpeakAsync($"{speech[20]} {cidade} {speech[21]} {temp} {speech[22]}");
                }
                else if (frase.Equals(listaPalavras[8]))
                {
                    action = "OFF_SIS";
                    fala.SpeakAsync(speech[23]);
                    comando = true;
                }
                else if(frase.Equals(listaPalavras[21]))
                {
                    action = "RES_SIS";
                    fala.SpeakAsync(speech[24]);
                    comando = true;
                }
                else if(frase.Equals(listaPalavras[20]))
                {
                    action = "RES_PC";
                    fala.SpeakAsync(speech[25]);
                    comando = true;
                }
                else if (frase.Equals(listaPalavras[12]))
                {
                    action = "OFF_PC";
                    fala.SpeakAsync(speech[26]);
                    comando = true;
                }
                else if (frase.Equals(listaPalavras[10]))
                {
                    fala.SpeakAsync(speech[27]);
                    chamando = false;
                }
                else if (e.Result.Text.Equals(listaPalavras[11]))
                {
                    fala.SpeakAsyncCancelAll();
                }
                else if(e.Result.Text.Equals(listaPalavras[16]))
                {
                    fala.SpeakAsyncCancelAll();
                    fala.SpeakAsync(speech[28]);
                    sentimentos.Down(5);
                    chamando = false;
                }
                else if(frase.Equals(listaPalavras[13]) || frase.Equals(listaPalavras[14]))
                {
                    this.WindowState = FormWindowState.Minimized;
                    fala.SpeakAsync($"{speech[29]} {sNome}");
                }
                else if(frase.Equals(listaPalavras[15]))
                {
                    fala.SpeakAsync(speech[30]);
                    if(pcd == 1)
                        fala.SpeakAsync(speech[31]);
                    fala.SpeakAsync($"{speech[32]} {sNome}");
                }
                else if(frase.Equals(listaPalavras[17]))
                {
                    if(sentimentos.status <= 33)
                    {
                        fala.SpeakAsync(speech[33]);
                    }
                    else if(sentimentos.status > 33 && sentimentos.status < 66)
                    {
                        fala.SpeakAsync($"{speech[34]} {sNome}");
                        action = "TDB";
                        comando = true;
                    }
                    else if(sentimentos.status >= 66)
                    {
                        fala.SpeakAsync($"{speech[35]} {sNome}");
                        action = "TDB";
                        comando = true;
                    }
                }
                else if(frase.Equals(listaPalavras[25]))
                {
                    if(sentimentos.status <= 33)
                    {
                        fala.SpeakAsync($"{speech[36]} {sNome}");
                        sentimentos.Up(30);
                    }
                    else
                    {
                        fala.SpeakAsync(speech[37]);
                    }
                }
                else if(frase.Equals(listaPalavras[29]))
                {
                    fala.SpeakAsync(speech[38]);
                    Process.Start(newsLink[indice]);
                    fala.SpeakAsync(news[indice]);
                }
                else if(frase.Equals(listaPalavras[28]))
                {
                    fala.SpeakAsync(speech[39]);
                    action = "RPS";
                    comando = true;
                }
                else if(frase.Equals(listaPalavras[18]) || frase.Equals(listaPalavras[19]))
                {
                    fala.SpeakAsync(speech[40]);
                    action = "EMG";
                    comando = true;
                }
                else if(frase.Equals(listaPalavras[7]))
                {
                    Relatorio();
                }
            }
            else
            {
                if(frase.Equals(listaPalavras[1]))
                {
                    Action(action, true);
                }
                else if(frase.Equals(listaPalavras[2]))
                {
                    Action(action, false);
                }
            }
        }

        private void Action(string command, bool resp)
        {
            switch(command)
            {
                case "OFF_SIS": 
                    if(resp)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        fala.SpeakAsync(speech[41]);
                    }
                    action = "";
                    break;
                case "RES_SIS":
                    if (resp)
                        Application.Restart();
                    else
                        fala.SpeakAsync(speech[41]);
                    break;
                case "RES_PC":
                    if (resp)
                    {
                        Process.Start("shutdown", "-r -t 3");
                        fala.SpeakAsync($"{speech[42]} {sNome}");
                    }
                    else
                    {
                        fala.SpeakAsync(speech[43]);

                    }
                    break;
                case "OFF_PC":
                    if(resp)
                    {
                        Process.Start("shutdown", "-s -t 3");
                        fala.SpeakAsync(speech[44]);
                    }
                    else
                    {
                        fala.SpeakAsync(speech[43]);

                    }
                    break;
                case "TDB":
                    if(resp)
                    {
                        if (sentimentos.status <= 33)
                        {
                            fala.SpeakAsync(speech[45]);
                        }
                        else if (sentimentos.status > 33 && sentimentos.status < 66)
                        {
                            fala.SpeakAsync(speech[46]);
                        }
                        else if(sentimentos.status >= 66)
                        {
                            fala.SpeakAsync($"{speech[47]} {sNome}");
                        }

                    }
                    else
                    {
                        fala.SpeakAsync(speech[48]);
                        Process.Start("https://www.youtube.com/watch?v=v4ps7jmSVsc&ab_channel=UnissexTV");
                    }
                    break;
                case "EMG":
                    if(resp)
                    {
                        if(internet)
                        {
                            fala.SpeakAsync(speech[49]);
                            string mensagem = $"Este é um email de EMERGÊNCIA solicitiado pelo usuário {nome} às {DateTime.Now.ToString("HH:mm:ss")} de {DateTime.Now.ToString("dd / MM / yyyy")}. Por favor, verifique o ocorrido.";
                            SendEmail("Email de EMERGÊNCIA", mensagem, email);
                        }
                        else
                        {
                            fala.SpeakAsync($"{sNome}, {speech[50]}");
                        }
                    }
                    else
                    {
                        fala.SpeakAsync(speech[51]);
                    }
                    break;
                case "REL":
                    if(resp)
                    {
                        Relatorio();
                    }
                    else
                    {
                        fala.SpeakAsync(speech[52]);
                    }
                    break;
                case "RPS":
                    if(resp)
                    {
                        fala.SpeakAsync(speech[53]);
                        repouso = true;
                        count = 1;
                    }
                    else
                    {
                        fala.SpeakAsync(speech[54]);
                    }
                    break;
            }
            action = "";
            comando = false;
        }

        private void Relatorio()
        {
            if (internet)
            {
                fala.Rate = 6;
                fala.SpeakAsync($"{speech[56]} {sNome}... {speech[57]}");
                fala.SpeakAsync(DateTime.Now.ToString("HH:mm:ss"));

                if(lan == "en-US")
                    fala.SpeakAsync($"{speech[58]} {DateTime.Now.ToString("dd/MM/yyyy")}, {DateTime.Now.DayOfWeek.ToString()} ");
                else
                    fala.SpeakAsync($"{speech[58]} {DateTime.Now.ToString("dd/MM/yyyy")}, {date.Semana()} "); 
                fala.SpeakAsync($"{speech[20]} {cidade} {speech[21]} {temp} {speech[22]}. {speech[59]} {climate} {speech[60]} {rain}, {humidity}, {wind}");
                fala.SpeakAsync($"{speech[61]} {cidade}");
                fala.SpeakAsync(news[indice]);

            }
            else
            {
                fala.SpeakAsync(speech[62]);
            }

            fala.Rate = 3;
        }

        private void SendEmail(string subject, string msg, string address)
        {
           // try
           // {
                MailMessage mmsg = new MailMessage();
                mmsg.From = new MailAddress(cripto.Decrip("DGxpCCpPHHxHItCIevBpxA{rDB", 666));
                SmtpClient cliente = new SmtpClient();
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new System.Net.NetworkCredential(cripto.Decrip("DGxpCCpPHHxHItCIevBpxA{rDB", 666), cripto.Decrip("3UMZZM#44U45QZ5", 666));
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "smtp.gmail.com";
                mmsg.To.Add(address);
                mmsg.Subject = subject;
                mmsg.SubjectEncoding = Encoding.UTF8;
                mmsg.Body = msg;
                mmsg.BodyEncoding = Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                cliente.Send(mmsg);
            //}
          //  catch
           // {
            //    MessageBox.Show("Erro ao enviar o email");
            //}

        }

        private void config_Click(object sender, EventArgs e)
        {
            Create f;
            if(lan == "en_US")
                f = new Create("Change your account!", lan);
            else
                f = new Create("Altere sua conta!", lan);
            f.Show();
        }

        private void Sistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public static Boolean CheckStatus()
        {
            int Description;
            return InternetGetConnectedState(out Description, 0); 
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            TimerTemp.Start();
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            TimerNews.Start();
        }

        private void TimerTemp_Tick(object sender, EventArgs e)
        {
            var links = webBrowser1.Document.GetElementsByTagName("div");
            foreach(HtmlElement link in links)
            {
                if(link.GetAttribute("className") == "wtr_currWind")
                {
                    string[] a = link.InnerText.Split(':');
                    wind = a[1];
                }
                if(link.GetAttribute("className") == "wtr_currHumi")
                {
                    string[] a = link.InnerText.Split(':');
                    humidity = a[1];
                }
                if(link.GetAttribute("className") == "wtr_currPerci")
                {
                    string[] a = link.InnerText.Split(' ');
                    rain = a[1];
                }
                if(link.GetAttribute("className") == "wtr_currTemp b_focusTextLarge")
                {
                    temp = link.InnerText;
                }
                if (link.GetAttribute("className") == "wtr_caption")
                {
                    climate = link.InnerText;
                }
            }
            TimerTemp.Stop();
        }

        private void TimerNews_Tick(object sender, EventArgs e)
        {
            news.Clear();
            var links = webBrowser2.Document.GetElementsByTagName("a");
            foreach(HtmlElement link in links)
            {
                if(link.GetAttribute("className") == "title")
                {
                    news.Add(link.InnerText);
                    newsLink.Add(link.GetAttribute("href"));
                }
            }
            TimerNews.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Skill f = new Skill(this);
            f.Show();
        }

        private void GeralTimer_Tick(object sender, EventArgs e)
        {
            internet = CheckStatus();

            if(lan == "en-US")
            {
                dateLb.Text = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")) + ", " + date.DiaMes() + ", " + date.Ano() + ", " + DateTime.Now.DayOfWeek.ToString() + ".";
                tempLb.Text = "- Weather: " + temp + " ºC";
                rainLb.Text = "- Rain: " + rain;
                umiLb.Text = "- Humidity:" + humidity;
                windLb.Text = "- Wind:" + wind;
            }
            else
            {
                dateLb.Text = date.DiaMes() + " de " + date.Mes() + " de " + date.Ano() + ", " + date.Semana() + ".";
                tempLb.Text = "- Temperatura: " + temp + " ºC";
                rainLb.Text = "- Chuva: " + rain;
                umiLb.Text = "- Umidade:" + humidity;
                windLb.Text = "- Vento:" + wind;
            }
            horaTxt.Text = DateTime.Now.ToString("HH:mm:ss");

            cityLb.Text = cidade;
            climaLb.Text = climate;
            var x = timer / 10;
            timeLb.Text = "• " + x.ToString() + "s";
            timer--;

            float fram = pRAM.NextValue();
            cirRAM.Value = (int)fram;
            cirRAM.Text = string.Format("{0:0}", fram);

            PowerStatus bat = SystemInformation.PowerStatus;

            if(bat.BatteryChargeStatus.ToString() == "NoSystemBattery")
            {
                cirBAT.Value = 100;
                cirBAT.Text = "100";
            }

            if (chamando)
                timerCall++;

            if (indice >= news.Count - 1)
                indice = 0;

            if (news.Count != 0)
                newsLb.Text = "- " + news[indice];

            if (timer == 0)
            {
                indice++;
                timer = 100;
                timerSearch++;
            }

            if(timerCall >= 350)
            {
                chamando = false;
                timerCall = 0;
            }

            if(timerSearch == 360)
            {
                if(internet)
                {
                    Console.WriteLine("Procurando informações as: " + DateTime.Now.ToString("HH:mm:ss"));
                    webBrowser1.Navigate("https://www.bing.com/search?q=weather+" + RemoveAccents(cidade));
                    webBrowser2.Navigate("https://www.bing.com/news/search?q=" + RemoveAccents(cidade));
                }
                timerSearch = 0;
            }

            if(repouso)
            {
                emoPic.Image = Properties.Resources.sleep;
                chamando = false;
                timerSleep += count;

                if (timerSleep / 10 == 1800)
                {
                    timerSleep = 0;
                    repouso = false;
                    fala.SpeakAsync(speech[63]);
                }

            }
            else
            {
                if (sentimentos.status <= 33)
                    emoPic.Image = Properties.Resources.sad;
                else if (sentimentos.status > 33 && sentimentos.status < 66)
                    emoPic.Image = Properties.Resources.normal;
                else if (sentimentos.status >= 66)
                    emoPic.Image = Properties.Resources.happy;
            }
   
            if (internet)
            {
                if(repouso)
                {
                    statusImage.BackColor = Color.Orange;
                }
                else
                {
                    if (!chamando)
                        statusImage.BackColor = Color.LawnGreen;
                    else
                        statusImage.BackColor = Color.DeepSkyBlue;
                }
            }
            else
            {
                statusImage.BackColor = Color.Red;
            }

        }

        private void emoPic_Click(object sender, EventArgs e)
        {
            if(repouso)
            {
                timerSleep = 0;
                repouso = false;
                fala.SpeakAsync(speech[64]);
            }
            else
                MessageBox.Show($"Este icone demonstra a relação entre você e a assistente virtual (Sentimentos Artificias). \nRespeito: {sentimentos.status}");
        }

        private void newsLb_Click(object sender, EventArgs e)
        {
            Process.Start(newsLink[indice]);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.bing.com/");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            count = 0;
            timerSleep = 0;
            repouso = !repouso;
            this.Icon = Properties.Resources.brain_icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config f = new Config(this);
            f.Show();
        }

        private string Decode(string val)
        {
            if(val.Contains("<copy>"))
            {
                if(Clipboard.ContainsText())
                {
                    val = val.Replace("<copy>", Clipboard.GetText());
                }
                else
                {
                    string v = "";
                    foreach(string file in Clipboard.GetFileDropList())
                    {
                        v = file;
                    }
                    string[] x = v.Split('\\');
                    v = v.Replace('\\' + x[x.Length - 1], "");
                    v = v.Replace('\\', '/');
                    val = val.Replace("<copy>", v);
                }
            }
            if(val.Contains("<copyfile>"))
            {
                try
                {
                    string v = "";
                    foreach (string file in Clipboard.GetFileDropList())
                    {
                        v = file;
                    }
                    string[] x = v.Split('\\'); 
                    val = val.Replace("<copyfile>", x[x.Length - 1]);
                }
                catch
                {
                    MessageBox.Show("Erro ao iniciar o comando <copyfile>");
                }

            }
            if(val.Contains("<temp>"))
            {
                val = val.Replace("<temp>", temp + " graus celsius");
            }
            if(val.Contains("<name>"))
            {
                val = val.Replace("<name>", sNome);
            }
            if(val.Contains("<com>"))
            {                
                while(val.Contains("<com>"))
                {
                    string y = "";
                    int inicio = val.IndexOf("<com>")+5, final = val.IndexOf("</com>");

                    for(int i=inicio; i < final; i++)
                    {
                        y += val[i];
                    }

                    string[] z = y.Split(';');

                    SerialPort serial = new SerialPort();
                    serial.BaudRate = 9600;
                    serial.PortName = z[0].ToUpper().Trim();
                    Console.WriteLine(z[0]);
                    Console.WriteLine(z[1]);
                    try
                    {
                        serial.Open();
                        serial.WriteLine(z[1].Trim());
                        serial.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Error command <com>");
                    }

                    val = val.Replace($"<com>{y}</com>", "");
                }
            }
            if(val.Contains("<link>"))
            { 
                try
                {
                    string[] x = val.Split(new string[] { "<link>" }, StringSplitOptions.None);

                    for (int i = 0; i < x.Length; i++)
                    {
                        if (x[i].Contains("</link>"))
                        {
                            string[] y = x[i].Split(new string[] { "</link>" }, StringSplitOptions.None);
                            System.Diagnostics.Process.Start(y[0]);
                            val = val.Replace($"<link>{y[0]}</link>", "");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Erro ao utilizar a função <link>");
                }
            }
            if(val.Contains("<cmd>"))
            {
                try
                {
                    string[] x = val.Split(new string[] { "<cmd>" }, StringSplitOptions.None);
                    string y;

                    while (val.Contains("<cmd>"))
                    {
                        StreamWriter bat;
                        bat = File.CreateText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\code.bat");
                        y = "";
                        int inicio = val.IndexOf("<cmd>") + 5, fim = val.IndexOf("</cmd>");

                        for (int i = inicio; i < fim; i++)
                        {
                            y += val[i];
                        }

                        Console.WriteLine(y);
                        
                        if (y.Contains(";"))
                        {
                            string[] z = y.Split(';');

                            for(int i=0; i < z.Length; i++)
                            {
                                z[i] = z[i].Trim();
                                bat.WriteLine(z[i]);
                            }
                        }
                        else
                        {
                            bat.WriteLine(y);
                        }

                        bat.Close();
                        Process.Start(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\code.bat");
                        Thread.Sleep(100);
                        val = val.Replace($"<cmd>{y}</cmd>", "");
                    }
                }
                catch
                {
                    MessageBox.Show("Erro ao executar o comando <cmd>");
                }

            }

            return val;
        }
        public void IniSkill()
        {
            if (!Directory.Exists(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands"))
            {
                Directory.CreateDirectory(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands");
            }

            if(!File.Exists(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\cmd.txt"))
            {
                StreamWriter c, d;
                c = File.CreateText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\cmd.txt");
                d = File.CreateText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\rps.txt");
                c.Close();
                d.Close();
            }

            if(File.Exists(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\config.txt"))
            {
                StreamReader j;
                string porta;
                string[] ports = SerialPort.GetPortNames();
                bool loc = false;
                j = File.OpenText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\config.txt");
                porta = j.ReadLine();
                j.Close();

                for(int i=0; i < ports.Length; i++)
                {
                    if(porta == ports[i])
                    {
                        cx.PortName = porta;
                        cx.BaudRate = 9600;
                        loc = true;
                        break;
                    }
                }

                if(!loc)
                    File.Delete(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\config.txt");
            }

            StreamReader x, y;
            x = File.OpenText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\cmd.txt");
            y = File.OpenText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\rps.txt");

            string linha1, linha2;


            while((linha1 = x.ReadLine()) != null)
            {
                skill.Add(linha1);
            }

            while ((linha2 = y.ReadLine()) != null)
            {
                resp.Add(linha2);
            }

        }

        public void SerialSend(SerialPort com, string wr)
        {
            try
            {
                com.Open();
                com.WriteLine(wr);
                com.Close();
            }
            catch
            {
                try
                {
                    MessageBox.Show("Error");
                }
                catch { }
            }
        }

        public void SaveSkill()
        {
            StreamWriter x,y;
            x = File.CreateText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\cmd.txt");
            y = File.CreateText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\Perfil\\Commands\\rps.txt");

            for(int i=0; i < skill.Count; i++)
            {
                x.WriteLine(skill[i]);
                y.WriteLine(resp[i]);
            }

            x.Close();
            y.Close();

            Application.Restart();
        }

        private string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

    }
}
