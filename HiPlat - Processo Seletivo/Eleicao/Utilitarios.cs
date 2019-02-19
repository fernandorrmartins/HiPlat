using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleicao
{
    public class Utilitarios
    {
        public static void mensagem(String msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
