using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CidadeGenerator : MapaPai
{



   

    public override void ConstruirObstaculo(Vector3 posicao)
    {
        RemoverComponentesJaOperados();
        if (ComponentesDoMapaEmOperacao["Lixo"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + 1f, 0);
            Instantiate(ComponentesDoMapa[2], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            ComponentesDoMapaEmOperacao["Lixo"].TamanhoDaOperacao = 0;
            //Realiza a operacao e instancia. E se nao precisar do chao coloca construir chao = false;
        }
        if(ComponentesDoMapaEmOperacao["Acido"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y, 0);
            Instantiate(ComponentesDoMapa[3], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            for (int k = 1; k <5 ; k++)
            {
                Vector3 v2 = new Vector3(posicao.x, posicao.y-k, 0);
                Instantiate(ComponentesDoMapa[1], v2, Quaternion.identity, ConjuntoDeComponents.transform);
            }
            ComponentesDoMapaEmOperacao["Acido"].TamanhoDaOperacao--;
        }
        if (ComponentesDoMapaEmOperacao["ConstruirCratera"].TaNoStack)
        {
            ComponentesDoMapaEmOperacao["ConstruirCratera"].TamanhoDaOperacao--;

        }
      
        if (ComponentesDoMapaEmOperacao["ArameFarpado"].TaNoStack)
        {
            Vector3 v2 = new Vector3(posicao.x, posicao.y + 0.8f, 0);
            Instantiate(ComponentesDoMapa[4], v2, Quaternion.identity, ConjuntoDeComponents.transform).GetComponent<ArameFarpadoScript>().SetarAtributos(Experiencia);
            ComponentesDoMapaEmOperacao["ArameFarpado"].TamanhoDaOperacao --;
            

        }
        if (ComponentesDoMapaEmOperacao["Lixo2"].TaNoStack)
        {
            Vector3 v2 = new Vector3(posicao.x, posicao.y + 0.3f, 0);
            Instantiate(ComponentesDoMapa[5], v2, Quaternion.identity, ConjuntoDeComponents.transform);
            ComponentesDoMapaEmOperacao["Lixo2"].TamanhoDaOperacao = 0;
            intervaloEntreObstaculos = 2;

        }
        if (ComponentesDoMapaEmOperacao["Carro"].TaNoStack)
        {
            Vector3 v2 = new Vector3(posicao.x, posicao.y + -1.25f, 0);
            Instantiate(ComponentesDoMapa[6], v2, Quaternion.identity, ConjuntoDeComponents.transform);

            ComponentesDoMapaEmOperacao["Carro"].TamanhoDaOperacao = 0;
            intervaloEntreObstaculos = 4;

        }
        if (ComponentesDoMapaEmOperacao["TempestadeDeAreia"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + 0.5f + Random.Range(0, 4), 0);
            Instantiate(ComponentesDoMapa[7], v1, Quaternion.identity, ConjuntoDeComponents.transform).GetComponent<SpriteRenderer>().color = new Color(0.5f,1,1);
            ComponentesDoMapaEmOperacao["TempestadeDeAreia"].TamanhoDaOperacao--;

        }
    }
   
public override void Start()
    {
        base.Start();
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_Cidade"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_CidadeBaixo"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Lixo"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Acido"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("ArameFarpado"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Lixo2"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Carro"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("TempestadeDeAreia"));
        AdicionarNomeAosComponentes();
    }
    public void AdicionarNomeAosComponentes()
    {
        ComponentesDoMapaEmOperacao.Add("Lixo", new ComponentData() { ExpNecessariaParaSerAcessado = 0, PodeStakar = false, PrecisaDeChao = true,TempoDeIntervalo = 5, Intervalo =3 });
        ComponentesDoMapaEmOperacao.Add("Acido", new ComponentData() { ExpNecessariaParaSerAcessado = 70, PodeStakar = false, PrecisaDeChao = false, TamanhoDaOperacaoMax = 4, TempoDeIntervalo = 1 });
        ComponentesDoMapaEmOperacao.Add("ConstruirCratera", new ComponentData() { ExpNecessariaParaSerAcessado = 110, PodeStakar = false, PrecisaDeChao = false, TamanhoDaOperacaoMax = 2, TempoDeIntervalo = 1 });
        ComponentesDoMapaEmOperacao.Add("ArameFarpado", new ComponentData() { ExpNecessariaParaSerAcessado = 35, PodeStakar = false, PrecisaDeChao = true, TamanhoDaOperacaoMax =2, TempoDeIntervalo = 1 });
        ComponentesDoMapaEmOperacao.Add("Lixo2", new ComponentData() { ExpNecessariaParaSerAcessado = 0, PodeStakar = false, PrecisaDeChao = true, TamanhoDaOperacaoMax = 1, TempoDeIntervalo = 5 });
        ComponentesDoMapaEmOperacao.Add("Carro", new ComponentData() { ExpNecessariaParaSerAcessado = 0, PodeStakar = false, PrecisaDeChao = true, TamanhoDaOperacaoMax = 1, TempoDeIntervalo = 100 });
        ComponentesDoMapaEmOperacao.Add("TempestadeDeAreia", new ComponentData() { ExpNecessariaParaSerAcessado = 150, PodeStakar = true, PrecisaDeChao = true, TempoDeIntervalo = 0 });
    }
    public override Vector3 Construir(Vector3 posicaoDoConstrutor)
    {
        posicaoDoConstrutor = base.Construir(posicaoDoConstrutor);
        return posicaoDoConstrutor;
    }
}
