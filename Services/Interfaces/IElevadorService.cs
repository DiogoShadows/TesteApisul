using System.Collections.Generic;
using TesteApisul.Models;

namespace ProvaAdmissionalCSharpApisul
{
  public interface IElevadorService
  {
    /// <summary> Deve retornar uma List contendo o(s) andar(es) menos utilizado(s). </summary> 
    List<int> andarMenosUtilizado(List<ComandoElevador> comandos);

    /// <summary> Deve retornar uma List contendo o(s) elevador(es) mais frequentado(s). </summary> 
    List<char> elevadorMaisFrequentado(List<ComandoElevador> comandos);

    /// <summary> Deve retornar uma List contendo o período de maior fluxo de cada um dos elevadores mais frequentados (se houver mais de um). </summary> 
    List<char> periodoMaiorFluxoElevadorMaisFrequentado(List<ComandoElevador> comandos);

    /// <summary> Deve retornar uma List contendo o(s) elevador(es) menos frequentado(s). </summary> 
    List<char> elevadorMenosFrequentado(List<ComandoElevador> comandos);

    /// <summary> Deve retornar uma List contendo o período de menor fluxo de cada um dos elevadores menos frequentados (se houver mais de um). </summary> 
    List<char> periodoMenorFluxoElevadorMenosFrequentado(List<ComandoElevador> comandos);

    /// <summary> Deve retornar uma List contendo o(s) periodo(s) de maior utilização do conjunto de elevadores. </summary> 
    List<char> periodoMaiorUtilizacaoConjuntoElevadores(List<ComandoElevador> comandos);

    /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador A em relação a todos os serviços prestados. </summary> 
    float percentualDeUsoElevadorA(List<ComandoElevador> comandos);

    /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador B em relação a todos os serviços prestados. </summary> 
    float percentualDeUsoElevadorB(List<ComandoElevador> comandos);

    /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador C em relação a todos os serviços prestados. </summary> 
    float percentualDeUsoElevadorC(List<ComandoElevador> comandos);

    /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador D em relação a todos os serviços prestados. </summary> 
    float percentualDeUsoElevadorD(List<ComandoElevador> comandos);

    /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador E em relação a todos os serviços prestados. </summary> 
    float percentualDeUsoElevadorE(List<ComandoElevador> comandos);

  }
}