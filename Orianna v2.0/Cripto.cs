using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orianna_v2._0
{
    class Cripto
    {
        public string Crip(string val, int key)
        {
            int x;
            string retorno = "";
            char[] letras = {' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '"', '#', '$', '%', '&', '(',')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };
            
            for(int i=0; i < val.Length; i++)
            {
                for (int y = 0; y < letras.Length; y++)
                {
                    if(val[i] == letras[y])
                    {
                        x = y + key;
                        while(x > letras.Length -1)
                        {
                            x -= letras.Length - 1;
                        }
                        retorno += letras[x];
                    }
                }
            }
            return retorno;
        }

        public string Decrip(string val, int key)
        {
            int x;
            string retorno = "";
            char[] letras = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '"', '#', '$', '%', '&', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };

            for (int i = 0; i < val.Length; i++)
            {
                for (int y = 0; y < letras.Length; y++)
                {
                    if (val[i] == letras[y])
                    {
                        x = y - key;

                        while(x < 0)
                        {
                            x += letras.Length - 1;
                        }

                        retorno += letras[x];
                    }
                }
            }

            return retorno;
        }
    }
}
