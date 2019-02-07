using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Deserto : MapaPai {

    public override void ConstruirObstaculo(Vector3 posicao)
    {
        RemoverComponentesJaOperados();
        if (ComponentesDoMapaEmOperacao["Urubu"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + Random.Range(1, 4),0);
            GameObject go = Instantiate(ComponentesDoMapa[2], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            go.GetComponent<Urubu>().SetarTributos(Experiencia);
            ComponentesDoMapaEmOperacao["Urubu"].TamanhoDaOperacao = 0;
        }
        if(ComponentesDoMapaEmOperacao["Cacto"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y +0.5f, 0);
            Instantiate(ComponentesDoMapa[3], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            ComponentesDoMapaEmOperacao["Cacto"].TamanhoDaOperacao = 0;
        }
        if(ComponentesDoMapaEmOperacao["TempestadeDeAreia"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y +0.5f + Random.Range(0, 4), 0);
            Instantiate(ComponentesDoMapa[4], v1, Quaternion.identity, ConjuntoDeComponents.transform).GetComponent<TempestadeAreiaScript>().SetarAtributos(Experiencia);
            ComponentesDoMapaEmOperacao["TempestadeDeAreia"].TamanhoDaOperacao--;

        }
        if(ComponentesDoMapaEmOperacao["AreiaMovedica"].TaNoStack)
        {
            for (int k = 1; k < 5; k++)
            {
                Vector3 v1 = new Vector3(posicao.x, posicao.y-k, 0);
                Instantiate(ComponentesDoMapa[5], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            }
            ComponentesDoMapaEmOperacao["AreiaMovedica"].TamanhoDaOperacao--;
        }
        if(ComponentesDoMapaEmOperacao["ConstruirCratera"].TaNoStack)
        {
            ComponentesDoMapaEmOperacao["ConstruirCratera"].TamanhoDaOperacao--;
         
        }

       
    }
 


    public override void Start()
    {
        base.Start();
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_Deserto"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_DesertoBaixo"));


        ComponentesDoMapa.Add((GameObject)Resources.Load("Urubu"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Cacto"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("TempestadeDeAreia"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("AreiaMovedica"));

        AdicionarNomeAosComponentes();
    }
    public void AdicionarNomeAosComponentes()
    {
        ComponentesDoMapaEmOperacao.Add("Urubu", new ComponentData() { ExpNecessariaParaSerAcessado = 200, PodeStakar = true, PrecisaDeChao=true, TempoDeIntervalo=0 });
        ComponentesDoMapaEmOperacao.Add("TempestadeDeAreia", new ComponentData() { ExpNecessariaParaSerAcessado = 300, PodeStakar = true, PrecisaDeChao = true, TempoDeIntervalo = 0 });
        ComponentesDoMapaEmOperacao.Add("Cacto", new ComponentData() { ExpNecessariaParaSerAcessado = 450, PodeStakar = false,PrecisaDeChao=true, TempoDeIntervalo = 1 });
        ComponentesDoMapaEmOperacao.Add("AreiaMovedica", new ComponentData() { ExpNecessariaParaSerAcessado = 1, PodeStakar = false,PrecisaDeChao = false, TamanhoDaOperacaoMax=5 , TempoDeIntervalo = 0 });
        ComponentesDoMapaEmOperacao.Add("ConstruirCratera", new ComponentData() { ExpNecessariaParaSerAcessado = 100, PodeStakar = false, PrecisaDeChao = false, TamanhoDaOperacaoMax=2, TempoDeIntervalo = 1 });
    }
}
