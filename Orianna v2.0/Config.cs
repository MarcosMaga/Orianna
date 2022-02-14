using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Orianna_v2._0
{
    public partial class Config : Form
    {
        Sistema sis;

        public Config(Sistema s)
        {
            InitializeComponent();
            sis = s;
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text != "")
            {
                StreamWriter x;
                x = File.CreateText(Application.LocalUserAppDataPath + "\\Orianna Save" + "\\config.txt");
                x.WriteLine(comboBox1.Text);
                sis.cx.PortName = comboBox1.Text;
                sis.cx.BaudRate = 9600;
                x.Close();
            }
            this.Close();
        }
    }
}
