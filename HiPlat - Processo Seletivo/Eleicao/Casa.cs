using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleicao
{
    public class Casa
    {
        public Rua rua { get; set; }
        public int numero { get; set; }
        public int totalEleitores { get; set; }

        public Casa(IDictionary<String, int> casas)
        {
            this.numero = casas["numero"];
            this.totalEleitores = casas["totalEleitores"];
        }

        public static List<Rua> ordenarRuasDasCasasRegistradas(List<Casa> casas)
        {
            casas = casas.OrderByDescending(o => o.totalEleitores).ToList();
            List<Rua> ruas = new List<Rua>();
            foreach(Casa casa in casas){
                ruas.Add(casa.rua);
            }

            return ruas;
        }
    }
}
