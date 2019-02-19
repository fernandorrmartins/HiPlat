using Eleicao;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiPlat
{
    public class Menu
    {
        /// <summary>
        /// Classe Responsável por Gerenciar o Menu e suas Opções
        /// </summary>
        #region Atributos da Classe
        /// <summary>
        /// Vairável que controla o fluxo do menu. Recebe o comando do usuário
        /// </summary>
        ConsoleKey cmd;
        /// <summary>
        /// Armazena a lista de opções do Menu Principal
        /// </summary>
        StringBuilder opcoesMenuPrincipal = new StringBuilder();
        #endregion

        /// <summary>
        /// Método Construtor da Classe Menu
        /// </summary>
        public Menu()
        {
            // Preenche variável responsavel pelos comandos com vazio
            cmd = ConsoleKey.Z;
            // Preenche o Menu Princiapl e suas opções
            opcoesMenuPrincipal.Append("############################################# Menu Principal #################################################\n");
            opcoesMenuPrincipal.Append("#                                                                                                            #\n");
            opcoesMenuPrincipal.Append("# (1) Calcular preço de item                                                                                 #\n");
            opcoesMenuPrincipal.Append("# (2) Cadastrar e Ordenar de fomar descrescente pelo total de eleitores                                      #\n");
            opcoesMenuPrincipal.Append("# (0) Sair                                                                                                   #\n");
            opcoesMenuPrincipal.Append("#                                                                                                            #\n");
            opcoesMenuPrincipal.Append("##############################################################################################################\nDigite sua opção: ");
            apresentarMenu();
        }

        /// <summary>
        /// Função que apresenta o menu para o usuário e gerencia a escolha das opções
        /// </summary>
        public void apresentarMenu()
        {
            while (!cmd.Equals("0"))
            {
                Console.Write(opcoesMenuPrincipal);
                cmd = Console.ReadKey().Key; // Lê a opção digitada pelo usuário

                switch (cmd)
                {
                    // Solicitação para Funcionalidades do Boleto Padrão
                    case ConsoleKey.D1:
                        Console.Clear();
                        double custo;
                        int validade;
                        while (true) {
                            try
                            {
                                Console.WriteLine("Digite o custo do produto: ");
                                custo = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Digite a validade em dias do produto: ");
                                validade = Convert.ToInt32(Console.ReadLine());
                                break;
                            } catch (Exception e)
                            {
                                HiperMercado.Utilitarios.mensagem(e.Message);
                            }
                        }
                        double preco = HiperMercado.Hi.formulaMagica(custo, validade);
                        Console.WriteLine("Preço final: R$ " + preco.ToString("N2"));
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        cmd = ConsoleKey.Z;
                        Console.Clear();
                        break;
                    // Solicitação para Funcionalidades do Boleto Personalizado
                    case ConsoleKey.D2:
                        Console.Clear();
                        List<Casa> casa = new List<Casa>();
                        Console.WriteLine("Digite os dados solicitados para cadastrar as casas e ruas:");
                        while (true)
                        {
                            try
                            {
                                Console.Clear();
                                IDictionary<String, int> casas = new Dictionary<String, int>();
                                Console.WriteLine("Digite o número da residência: ");
                                casas.Add("numero", Convert.ToInt32(Console.ReadLine()));
                                Console.WriteLine("Digite o número de eleitores da residência: ");
                                casas.Add("totalEleitores", Convert.ToInt32(Console.ReadLine()));

                                Casa registro = new Casa(casas);

                                Dictionary<String, String> ruas = new Dictionary<string, string>();
                                Console.WriteLine("Digite o cep da rua: ");
                                ruas.Add("cep", Console.ReadLine());
                                Console.WriteLine("Digite o nome da rua: ");
                                ruas.Add("nome", Console.ReadLine());

                                Rua rua = new Rua(ruas);

                                registro.rua = rua;

                                casa.Add(registro);

                                Console.Clear();
                                Console.WriteLine("Se desejar encerrar os cadastros de residências pressione 'esc'.");
                                Console.WriteLine("Pressione qualquer outra tecla para continuar com os cadastros.");
                                if(Console.ReadKey().Key == ConsoleKey.Escape)
                                {
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Eleicao.Utilitarios.mensagem(e.Message);
                            }
                        }
                        List<Rua> ruasAApresentar = new List<Rua>();
                        if (casa.Count > 0)
                            ruasAApresentar = Casa.ordenarRuasDasCasasRegistradas(casa);
                        Rua.apresentarNaTelaListaDeRuas(ruasAApresentar);
                        cmd = ConsoleKey.Z;
                        break;
                    // Condição para encerrar a solução
                    case ConsoleKey.D0:
                        Console.Clear();
                        Console.WriteLine("Sistema encerrado. Pressione qualquer tecla para fechar...");
                        Console.ReadKey();
                        break;
                    // Condição padrão para qualquer opção digitada inválida
                    default:
                        Console.Clear();
                        Console.WriteLine("############################################# Opção Invalida #################################################");
                        break;
                }
            }
        }
        
    }
}