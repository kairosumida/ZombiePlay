using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MundoDoce : MapaPai
{
    private int distanciaEntreBolo = 40;
   
    public override void ConstruirAbaixoDoChao(Vector3 posicao)
    {
        for (int k = 1; k < 5; k++)
        {
            Vector3 v2 = new Vector3(posicao.x, posicao.y - k, 0);
            Instantiate(ComponentesDoMapa[0], v2, Quaternion.identity, ConjuntoDeComponents.transform);
        }

    }
    public void ConstruirDocesExtras(Vector3 posicao)
    {
        if (Experiencia > 150) {
            for (int i = 0; i < Experiencia/60;i++) {
                if (Random.Range(0, 2) == 0)
                {
                    Vector3 v1 = new Vector3(posicao.x, posicao.y + Random.Range(1, 4), 0);
                    GameObject go = Instantiate(ComponentesDoMapa[1], v1, Quaternion.identity, ConjuntoDeComponents.transform);
                }
            }
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                Vector3 v1 = new Vector3(posicao.x, posicao.y + Random.Range(1, 4), 0);
                GameObject go = Instantiate(ComponentesDoMapa[1], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            }
        }
    }

    
    public override void ConstruirObstaculo(Vector3 posicao)
    {
        RemoverComponentesJaOperados();
       
        if (ComponentesDoMapaEmOperacao["ChaoGosmento"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y+0.8f, 0);
            GameObject go = Instantiate(ComponentesDoMapa[3], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            ComponentesDoMapaEmOperacao["ChaoGosmento"].TamanhoDaOperacao--;
        }
        if (ComponentesDoMapaEmOperacao["ConstruirCratera"].TaNoStack)
        {
            ComponentesDoMapaEmOperacao["ConstruirCratera"].TamanhoDaOperacao--;

        }
        if (ComponentesDoMapaEmOperacao["Rolante"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + 4f, 0);
            GameObject go = Instantiate(ComponentesDoMapa[4], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            ComponentesDoMapaEmOperacao["Rolante"].TamanhoDaOperacao=0;
        }
    }

    public void ConstruirBolo(Vector3 posicao)
    {
        if(distanciaEntreBolo <= 0)
        {
            distanciaEntreBolo = 50;
            Vector3 v1 = new Vector3(posicao.x-5, posicao.y+0.5f, 0);
            Instantiate(ComponentesDoMapa[2], v1, Quaternion.identity, ConjuntoDeComponents.transform);
        }
        else
        {

            distanciaEntreBolo--;
        }
    }

    public override void Start()
    {
        base.Start();
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_MundoDoce"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Doce"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Bolo"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("ChaoGosmento"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Rolante"));
        AdicionarNomeAosComponentes();
    }
    public void AdicionarNomeAosComponentes()
    {
        ComponentesDoMapaEmOperacao.Add("ChaoGosmento", new ComponentData() { ExpNecessariaParaSerAcessado = 60, PodeStakar = true, PrecisaDeChao = true, TamanhoDaOperacaoMax = 4, TamanhoDaOperacao = 10 });
        ComponentesDoMapaEmOperacao.Add("ConstruirCratera", new ComponentData() { ExpNecessariaParaSerAcessado = 80, PodeStakar = false, PrecisaDeChao = false, TamanhoDaOperacaoMax = 2, TempoDeIntervalo = 3 });
        ComponentesDoMapaEmOperacao.Add("Rolante", new ComponentData() { ExpNecessariaParaSerAcessado = 220, PodeStakar = true, PrecisaDeChao = true, TempoDeIntervalo = 11 });
    }
    public override Vector3 Construir(Vector3 posicaoDoConstruor)
    {
        posicaoDoConstruor = base.Construir(posicaoDoConstruor);
        ConstruirDocesExtras(posicaoDoConstruor);
        ConstruirBolo(posicaoDoConstruor);
        return posicaoDoConstruor;
    }
}
