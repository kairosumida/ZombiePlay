using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Floresta : MapaPai {
    
    private int intervaloDeArvore = 5;
    public override void ConstruirChao(Vector3 posicao)
    {
        Vector3 v2 = new Vector3(posicao.x, posicao.y -1, 0);
        Instantiate(ComponentesDoMapa[0], v2, Quaternion.identity, ConjuntoDeComponents.transform);
        ConstruirAbaixoDoChao(v2);
    }
    public override void ConstruirAbaixoDoChao(Vector3 posicao)
    {
        for (int k = 1; k < 5; k++)
        {
            Vector3 v2 = new Vector3(posicao.x, posicao.y - k, 0);
            Instantiate(ComponentesDoMapa[0], v2, Quaternion.identity, ConjuntoDeComponents.transform);
        }

    }
    public void CriarArvore(Vector3 posicao)
    {
        if (intervaloDeArvore <= 0)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + 2, 0);
            GameObject go = Instantiate(ComponentesDoMapa[1], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            intervaloDeArvore = Random.Range(5, 10);
        }
        else
        {
            intervaloDeArvore--;
        }
    }
    public override void ConstruirObstaculo(Vector3 posicao)
    {
        RemoverComponentesJaOperados();
        if (ComponentesDoMapaEmOperacao["Pedra"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x-Random.Range(9,20), posicao.y + Random.Range(6,11), 0);
            Instantiate(ComponentesDoMapa[2], v1, Quaternion.identity, ConjuntoDeComponents.transform).GetComponent<PedraScript>().SetarPropriedades(Experiencia);
            ComponentesDoMapaEmOperacao["Pedra"].TamanhoDaOperacao = 0;
            ComponentesDoMapaEmOperacao["Pedra"].Intervalo = 6;
        }
        if (ComponentesDoMapaEmOperacao["TempestadeDeAreia"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + 0.5f + Random.Range(0, 5), 0);
            Instantiate(ComponentesDoMapa[3], v1, Quaternion.identity, ConjuntoDeComponents.transform).GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f);
            ComponentesDoMapaEmOperacao["TempestadeDeAreia"].TamanhoDaOperacao--;

        }

    }
    
    

    public override void Start()
    {
        base.Start();
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_Agua"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Madeira"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Pedra"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("TempestadeDeAreia"));
        AdicionarNomeAosComponentes();
    }
    public void AdicionarNomeAosComponentes()
    {
        //ComponentesDoMapaEmOperacao.Add("Madeira", new ComponentData() { ExpNecessariaParaSerAcessado = 0, PodeStakar = true, PrecisaDeChao = true, Intervalo = 6, TempoDeIntervalo = 5 });
        ComponentesDoMapaEmOperacao.Add("Pedra", new ComponentData() { ExpNecessariaParaSerAcessado = 130, PodeStakar = true, PrecisaDeChao = true, Intervalo = 3, TempoDeIntervalo = 5 });
        ComponentesDoMapaEmOperacao.Add("TempestadeDeAreia", new ComponentData() { ExpNecessariaParaSerAcessado = 50, PodeStakar = true, PrecisaDeChao = true, TempoDeIntervalo = 4 });
    }
    public override Vector3 Construir(Vector3 posicao)
    {

        if (ConstruirChaoDeSeguranca(posicao))
        {
            RandomizadorDeOperacao();
            ConstruirObstaculo(posicao);


            if (construirChao)
            {
                ConstruirChao(posicao);
            }
            CriarArvore(posicao);
        }
        posicao.x++;
        return posicao;
    }
}
