using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orianna_v2._0
{
    class Feelings
    {
        public int praise;
        public int offense;
        public int status;
        private string url;
        private int mp;

        public void Init(string urlA, int on)
        {
            url = urlA;
            if(File.Exists(url + "\\feel.txt"))
            {
                StreamReader x;
                x = File.OpenText(url + "\\feel.txt");
                status = int.Parse(x.ReadLine());
                praise = int.Parse(x.ReadLine());
                offense = int.Parse(x.ReadLine());
                x.Close();
            }
            else
            {
                status = 50;
                praise = 0;
                offense = 0;
                Save(url);
            }

            mp = on;
        }

        public void Up(int val)
        {
            if (status > 100)
                status = 100;
            else
                status += val * mp;

            praise++;
            Save(url);
        }

        public void Down(int val)
        {
            if (status < 0)
                status = 0;
            else
                status -= val * mp;

            offense++;
            Save(url);

        }

        public void Save(string url)
        {
            StreamWriter x;
            x = File.CreateText(url + "\\feel.txt");
            x.WriteLine(status.ToString());
            x.WriteLine(praise.ToString());
            x.WriteLine(offense.ToString());
            x.Close();
        }
    }
}
