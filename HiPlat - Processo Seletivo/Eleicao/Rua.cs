using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleicao
{
    public class Rua
    {
        public String cep;
        public String nome;

        public Rua(IDictionary<String, String> ruas)
        {
            this.cep = ruas["cep"];
            this.nome = ruas["nome"];
        }

        public static void apresentarNaTelaListaDeRuas(List<Rua> ruas)
        {
            Console.Clear();
            Console.WriteLine("Ruas das casas registradas e ordenadas pelo número de eleitores:");
            foreach(Rua rua in ruas)
            {
                Console.WriteLine("#################################################");
                Console.WriteLine("Cep: " + rua.cep);
                Console.WriteLine("Nome: " + rua.nome);
            }
            Console.WriteLine("#################################################");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
