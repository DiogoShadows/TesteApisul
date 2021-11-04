using ProvaAdmissionalCSharpApisul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteApisul.Models;

namespace TesteApisul.Services
{
    public class ElevadorService : IElevadorService
    {

        public List<int> andarMenosUtilizado(List<ComandoElevador> comandos)
        {
            var menosUtilizados = comandos.GroupBy(x => x.andar)
                                        .Select(x => x.Count())
                                        .Min();

            return comandos.GroupBy(x => x.andar)
                            .Where(x => x.Count() == menosUtilizados)
                            .Select(x => x.Key)
                            .ToList();
        }

        public List<char> elevadorMaisFrequentado(List<ComandoElevador> comandos)
        {
            var maisUtilizados = comandos.GroupBy(x => x.elevador)
                                         .Select(x => x.Count())
                                         .Max();

            return comandos.GroupBy(x => x.elevador)
                           .Where(x => x.Count() == maisUtilizados)
                           .Select(x => x.Key)
                           .ToList();
        }

        public List<char> elevadorMenosFrequentado(List<ComandoElevador> comandos)
        {
            var menosFrequentados = comandos.GroupBy(x => x.elevador)
                                            .Select(x => x.Count())
                                            .Min();

            return comandos.GroupBy(x => x.elevador)
                           .Where(x => x.Count() == menosFrequentados)
                           .Select(x => x.Key)
                           .ToList();
        }

        public float percentualDeUsoElevadorA(List<ComandoElevador> comandos)
        {
            return percentualUsoElevador(comandos, 'A');
        }

        public float percentualDeUsoElevadorB(List<ComandoElevador> comandos)
        {
            return percentualUsoElevador(comandos, 'B');
        }

        public float percentualDeUsoElevadorC(List<ComandoElevador> comandos)
        {
            return percentualUsoElevador(comandos, 'C');
        }

        public float percentualDeUsoElevadorD(List<ComandoElevador> comandos)
        {
            return percentualUsoElevador(comandos, 'D');
        }

        public float percentualDeUsoElevadorE(List<ComandoElevador> comandos)
        {
            return percentualUsoElevador(comandos, 'E');
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado(List<ComandoElevador> comandos)
        {
            var elevadoresMaisFrequentados = elevadorMaisFrequentado(comandos);
            List<char> fluxoElevadores = new List<char>();

            foreach(char elevador in elevadoresMaisFrequentados)
            {
                var comandosElevador = comandos.Where(x => x.elevador == elevador).ToList();
                var periodos = periodosDictionary(comandosElevador);
                
                fluxoElevadores.Add(periodos.FirstOrDefault(x => x.Value == periodos.Values.Max()).Key);
            }

            return fluxoElevadores;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores(List<ComandoElevador> comandos)
        {
            var periodos = periodosDictionary(comandos);

            var a = periodos.Where(x => x.Value == periodos.Values.Max()).ToDictionary(x => x.Key).Keys.ToList();

            return a;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado(List<ComandoElevador> comandos)
        {
            var elevadoresMenosFrequentados = elevadorMenosFrequentado(comandos);
            List<char> fluxoElevadores = new List<char>();

            foreach (char elevador in elevadoresMenosFrequentados)
            {
                var comandosElevador = comandos.Where(x => x.elevador == elevador).ToList();
                var periodos = periodosDictionary(comandosElevador);

                fluxoElevadores.Add(periodos.FirstOrDefault(x => x.Value == periodos.Values.Min()).Key);
            }

            return fluxoElevadores;
        }

        #region Helpers
        protected float percentualUsoElevador(List<ComandoElevador> comandos, char elevador)
        {
            float totalUsoElevadores = comandos.Count();
            float usoElevador = comandos.Where(x => x.elevador == elevador).Count();
            string stringResultado = ((usoElevador * 100) / totalUsoElevadores).ToString("n2");

            return float.Parse(stringResultado);
        }

        protected Dictionary<char, int> periodosDictionary(List<ComandoElevador> comandosElevador)
        {
            Dictionary<char, int> turnosContados = new Dictionary<char, int>();

            foreach (ComandoElevador comandoElevador in comandosElevador)
            {
                if (!turnosContados.ContainsKey(comandoElevador.turno))
                    turnosContados.Add(comandoElevador.turno, 1);

                else
                    turnosContados[comandoElevador.turno] += 1;
            }

            return turnosContados;
        }

        #endregion
    }
}
