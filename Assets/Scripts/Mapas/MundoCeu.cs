using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MundoCeu : MapaPai {
    private int posicaoMaxDaNuvem= 15;
    private float posicaoAtualDaNuvem;
    private int qtdNuvensAoLado;
    private int vaoEntreNuvens;
    public void ConstruirNuvem(Vector3 posicao)
    {
        if (qtdNuvensAoLado <= 0)
        {
            if(vaoEntreNuvens <= 0)
            {
                vaoEntreNuvens = Random.Range(0, 2);
                qtdNuvensAoLado = Random.Range(1, 4);
                if(posicaoAtualDaNuvem < 3)
                {
                    posicaoAtualDaNuvem = Random.Range(0f, 1.5f);
                }
                else if(posicaoAtualDaNuvem > posicaoMaxDaNuvem - 3)
                {
                    posicaoAtualDaNuvem = Random.Range(-1.5f, 0f);
                }
                else
                {
                    posicaoAtualDaNuvem = Random.Range(-1.5f, 1.5f);
                }
            }
            else
            {
                vaoEntreNuvens--;
            }
        }
        else
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + posicaoAtualDaNuvem, 0);
            Instantiate(ComponentesDoMapa[0], v1, Quaternion.identity, ConjuntoDeComponents.transform).GetComponent<Comp_Nuvem>().SetarAtributos(Experiencia);
            
            qtdNuvensAoLado--;
        }
     
    }
  

    public override void ConstruirObstaculo(Vector3 posicao)
    {
        RemoverComponentesJaOperados();
        if (ComponentesDoMapaEmOperacao["TempestadeDeAreia"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + posicaoAtualDaNuvem + Random.Range(-2, 2), 0);
            Instantiate(ComponentesDoMapa[1], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            ComponentesDoMapaEmOperacao["TempestadeDeAreia"].TamanhoDaOperacao--;
        }
    }
    public override void Start()
    {
        base.Start();
        ComponentesDoMapa.Add((GameObject)Resources.Load("Nuvem"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("TempestadeDeAreia"));
        AdicionarNomeAosComponentes();
    }
    public void AdicionarNomeAosComponentes()
    {
        ComponentesDoMapaEmOperacao.Add("TempestadeDeAreia", new ComponentData() { ExpNecessariaParaSerAcessado = 1, PodeStakar = true, PrecisaDeChao = true, TempoDeIntervalo = 0 });
    }
    public override Vector3 Construir(Vector3 posicaoDoConstrutor)
    {
        if (ConstruirChaoDeSeguranca(posicaoDoConstrutor))
        {
            RandomizadorDeOperacao();
            ConstruirNuvem(posicaoDoConstrutor);
            ConstruirObstaculo(posicaoDoConstrutor);
        }

        posicaoDoConstrutor.x++;
        return posicaoDoConstrutor;
    }
}
