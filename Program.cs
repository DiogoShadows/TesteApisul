using System;
using System.Collections.Generic;
using System.IO;
using TesteApisul.Models;
using Newtonsoft.Json;
using ProvaAdmissionalCSharpApisul;
using TesteApisul.Services;
using System.Linq;

namespace TesteApisul
{
    class Program
    {
        static void Main(string[] args)
        {            
            telaUsuario();
        }

        protected static List<ComandoElevador> LerJson(string path)
        {
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    return JsonConvert.DeserializeObject<List<ComandoElevador>>(r.ReadToEnd());
                }
            }

            catch(Exception)
            {
                Console.WriteLine("Caminho não encontrado");
                Console.WriteLine("Tente Novamente");
            }

            return null;
        }

        protected static void telaUsuario()
        {
            try
            {                
                Console.Write(@"Insira o path do arquivo Json(Exemplo: C: \Users\Home\Desktop\Exemplo\input.json): ");
                var path = Console.ReadLine();
                var comandos = new List<ComandoElevador>();

                if (path != null)
                {
                    comandos = LerJson(path);
                }

                if(comandos != null)
                    menu(comandos);
            }

            catch(Exception)
            {
                Console.WriteLine("Ocorreu um erro");
                return;
            }                      
        }

        protected static void menu(List<ComandoElevador> comandos)
        {
            var elevadorService = new ElevadorService();

            while (true)
            {
                Console.WriteLine("Selecione um método");
                Console.WriteLine("1 - andarMenosUtilizado");
                Console.WriteLine("2 - elevadorMaisFrequentado");
                Console.WriteLine("3 - elevadorMenosFrequentado");
                Console.WriteLine("4 - percentualDeUsoElevadorA");
                Console.WriteLine("5 - percentualDeUsoElevadorB");
                Console.WriteLine("6 - percentualDeUsoElevadorC");
                Console.WriteLine("7 - percentualDeUsoElevadorD");
                Console.WriteLine("8 - percentualDeUsoElevadorE");
                Console.WriteLine("9 - periodoMaiorFluxoElevadorMaisFrequentado");
                Console.WriteLine("10 - periodoMaiorUtilizacaoConjuntoElevadores");
                Console.WriteLine("11 - periodoMenorFluxoElevadorMenosFrequentado");

                var escolha = Console.ReadLine();
                Console.WriteLine("");

                switch (escolha)
                {                   
                    case "1":
                        var a = elevadorService.andarMenosUtilizado(comandos);
                        foreach (var x in a)
                        {
                            Console.WriteLine(x);
                        }                        
                        break;

                    case "2":
                        var b = elevadorService.elevadorMaisFrequentado(comandos);
                        foreach (var x in b)
                        {
                            Console.WriteLine(x);
                        }
                        break;

                    case "3":
                        var c = elevadorService.elevadorMenosFrequentado(comandos);
                        foreach (var x in c)
                        {
                            Console.WriteLine(x);
                        }
                        break;

                    case "4":
                        Console.WriteLine(elevadorService.percentualDeUsoElevadorA(comandos));
                        break;

                    case "5":
                        Console.WriteLine(elevadorService.percentualDeUsoElevadorB(comandos));
                        break;

                    case "6":
                        Console.WriteLine(elevadorService.percentualDeUsoElevadorC(comandos));
                        break;

                    case "7":
                        Console.WriteLine(elevadorService.percentualDeUsoElevadorD(comandos));
                        break;

                    case "8":
                        Console.WriteLine(elevadorService.percentualDeUsoElevadorE(comandos));
                        break;

                    case "9":
                        var d = elevadorService.periodoMaiorFluxoElevadorMaisFrequentado(comandos);
                        foreach (var x in d)
                        {
                            Console.WriteLine(x);
                        }
                        break;

                    case "10":
                        var e = elevadorService.periodoMaiorUtilizacaoConjuntoElevadores(comandos);
                        foreach (var x in e)
                        {
                            Console.WriteLine(x);
                        }
                        break;

                    case "11":
                        var f = elevadorService.periodoMenorFluxoElevadorMenosFrequentado(comandos);
                        foreach (var x in f)
                        {
                            Console.WriteLine(x);
                        }
                        break;

                    default:
                        Console.WriteLine("Comando não encontrado");
                        break;
                }

                Console.WriteLine("");
            }
        }
    }
}
