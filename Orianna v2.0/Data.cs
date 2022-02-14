using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orianna_v2._0
{
    class Data
    {
        public string Semana()
        {
            string a = DateTime.Now.DayOfWeek.ToString();
            string b="";

            switch(a)
            {
                case "Sunday": b = "Domingo"; break;
                case "Monday": b = "Segunda-Feira"; break;
                case "Tuesday": b = "Terça-Feira"; break;
                case "Wednesday": b = "Quarta-Feira"; break;
                case "Thursday": b = "Quinta-Feira"; break;
                case "Friday": b = "Sexta-Feira"; break;
                case "Saturday": b = "Sábado"; break;
                default: b = "Error"; break;
            }

            return b;
        }

        public string DiaMes()
        {
            string a = DateTime.Now.Day.ToString();
            return a;
        }

        public string Ano()
        {
            string a = DateTime.Now.Year.ToString();
            return a;
        }

        public string Mes()
        {
            var a = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("pt-br"));
            var b = char.ToUpper(a[0]) + a.Substring(1);
            return b;
        }

    }
}
