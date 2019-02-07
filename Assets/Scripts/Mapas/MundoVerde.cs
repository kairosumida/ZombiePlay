using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MundoVerde : MapaPai {
  


    
    public override void ConstruirObstaculo(Vector3 posicao)
    {
        RemoverComponentesJaOperados();
        if (ComponentesDoMapaEmOperacao["Golem"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + Random.Range(1, 4), 0);
            GameObject go = Instantiate(ComponentesDoMapa[2], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            go.GetComponent<GolemScript>().SetarAtributos(Experiencia);
            ComponentesDoMapaEmOperacao["Golem"].TamanhoDaOperacao = 0;
        }
        if (ComponentesDoMapaEmOperacao["Espinho"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + Random.Range(1, 4), 0);
            Instantiate(ComponentesDoMapa[3], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            
            ComponentesDoMapaEmOperacao["Espinho"].TamanhoDaOperacao = 0;
        }
        if (ComponentesDoMapaEmOperacao["ArameFarpado"].TaNoStack)
        {
            Vector3 v2 = new Vector3(posicao.x, posicao.y + 0.8f, 0);
            Instantiate(ComponentesDoMapa[4], v2, Quaternion.identity, ConjuntoDeComponents.transform).GetComponent<ArameFarpadoScript>().SetarAtributos(Experiencia);
            ComponentesDoMapaEmOperacao["ArameFarpado"].TamanhoDaOperacao--;


        }
        if (ComponentesDoMapaEmOperacao["Caixa"].TaNoStack)
        {
            Vector3 v2 = new Vector3(posicao.x, posicao.y + 0.8f, 0);
            Instantiate(ComponentesDoMapa[5], v2, Quaternion.identity, ConjuntoDeComponents.transform);
            ComponentesDoMapaEmOperacao["Caixa"].TamanhoDaOperacao--;


        }
        if (ComponentesDoMapaEmOperacao["ConstruirCratera"].TaNoStack)
        {
            ComponentesDoMapaEmOperacao["ConstruirCratera"].TamanhoDaOperacao=0;

        }
    }
   


    public override void Start()
    {
        base.Start();
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_MundoVerde"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_CidadeBaixo"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Golem"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Espinho"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("ArameFarpado"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Caixa"));
        AdicionarNomeAosComponentes();
    }
    public void AdicionarNomeAosComponentes()
    {
        ComponentesDoMapaEmOperacao.Add("Golem", new ComponentData() { ExpNecessariaParaSerAcessado = 50, PodeStakar = true, PrecisaDeChao = true, Intervalo = 3, TempoDeIntervalo = 3 });
        ComponentesDoMapaEmOperacao.Add("Espinho", new ComponentData() { ExpNecessariaParaSerAcessado = 3, PodeStakar = false, PrecisaDeChao = true, Intervalo = 5, TempoDeIntervalo = 5 });
        ComponentesDoMapaEmOperacao.Add("ArameFarpado", new ComponentData() { ExpNecessariaParaSerAcessado = 70, PodeStakar = false, PrecisaDeChao = true, TamanhoDaOperacaoMax = 2, TempoDeIntervalo = 8 });
        ComponentesDoMapaEmOperacao.Add("Caixa", new ComponentData() { ExpNecessariaParaSerAcessado = 5, PodeStakar = false, PrecisaDeChao = true, TamanhoDaOperacaoMax = 2, TempoDeIntervalo = 9 });
        ComponentesDoMapaEmOperacao.Add("ConstruirCratera", new ComponentData() { ExpNecessariaParaSerAcessado = 100, PodeStakar = false, PrecisaDeChao = false, TempoDeIntervalo = 5 });
    }
    public override Vector3 Construir(Vector3 posicaoDoConstruor)
    {
        posicaoDoConstruor = base.Construir(posicaoDoConstruor);
        return posicaoDoConstruor;
    }
}
