using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Invisivel : MapaPai {
    private int posicaoMaxDoChao =15;
    private float posicaoAtualDoChao;
    private int qtdChaosAoLado;
    private int vaoEntreChao;
    private bool randomizarAltura = false;
    public override void ConstruirChao(Vector3 posicao)
    {
        if(Experiencia > 150)
        {
            randomizarAltura = true;
        }
        if (qtdChaosAoLado <= 0)
        {
            if (vaoEntreChao <= 0)
            {
                vaoEntreChao = Random.Range(0, 3);
                qtdChaosAoLado = Random.Range(1, 5);
                if (randomizarAltura)
                {
                    if (posicaoAtualDoChao < 3)
                    {
                        posicaoAtualDoChao = Random.Range(0f, 2f);
                    }
                    else if (posicaoAtualDoChao > posicaoMaxDoChao - 3)
                    {
                        posicaoAtualDoChao = Random.Range(-2f, 0f);
                    }
                    else
                    {
                        posicaoAtualDoChao = Random.Range(-2, 2);
                    }
                }
            }
            else
            {
                vaoEntreChao--;
            }
        }
        else
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + posicaoAtualDoChao, 0);
            GameObject nuv = Instantiate(ComponentesDoMapa[0], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            nuv.GetComponent<ChaoInvScript>().Nivel = Experiencia;
            nuv.GetComponent<ChaoInvScript>().Comecar();
            qtdChaosAoLado--;
        }

    }
    

    public override void ConstruirObstaculo(Vector3 posicao)
    {
        RemoverComponentesJaOperados();
        if (ComponentesDoMapaEmOperacao["TempestadeDeAreia"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + posicaoAtualDoChao + Random.Range(-2, 2), 0);
            Instantiate(ComponentesDoMapa[1], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            ComponentesDoMapaEmOperacao["TempestadeDeAreia"].TamanhoDaOperacao--;
        }
        if (ComponentesDoMapaEmOperacao["Pulador"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + posicaoAtualDoChao, 0);
            GameObject go= Instantiate(ComponentesDoMapa[2], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            go.GetComponent<PuladorScript>().SetarPropriedades(Experiencia);
            ComponentesDoMapaEmOperacao["Pulador"].TamanhoDaOperacao=0;
            
        }
    }
    public override void Start()
    {
        base.Start();
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_Invisivel"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("TempestadeDeAreia"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("Pulador"));
        AdicionarNomeAosComponentes();
    }
    public void AdicionarNomeAosComponentes()
    {
        ComponentesDoMapaEmOperacao.Add("TempestadeDeAreia", new ComponentData() { ExpNecessariaParaSerAcessado = 50, PodeStakar = true, PrecisaDeChao = true, TempoDeIntervalo = 0 });
        ComponentesDoMapaEmOperacao.Add("Pulador", new ComponentData() { ExpNecessariaParaSerAcessado = 10, PodeStakar = false, PrecisaDeChao = false, TempoDeIntervalo = 10 });
    }
  

}
