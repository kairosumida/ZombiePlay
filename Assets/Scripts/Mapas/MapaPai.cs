using System.Collections.Generic;
using UnityEngine;

public abstract class MapaPai : MonoBehaviour, IMapa
{
    protected GameObject ConjuntoDeComponents;
    public List<GameObject> ComponentesDoMapa;//Tudo o que necessita ser instanciado no mapa, deve ser adicionado no Start da classeFilha
    public Dictionary<string, ComponentData> ComponentesDoMapaEmOperacao;//O string indica o nome do componente, O bool significa se o objeto ja foi perguntado ou não
    
    protected int intervaloEntreObstaculos;
    protected bool temObjetoQueNaoStaka;
    protected bool construirChao = true; //Variavel que segura a construcao de chao. Isso ocorre pois ao completar uma construcao. Imediatamente o chao é construido, podendo construir em cima da areia movedica
    public int Experiencia = 1;
    protected int primeiraVez = 5;
    public int obstaculoTamanho;
    public string obstaculoEmOperacao;
    private GameObject ChaoDeInicio;

    public abstract void ConstruirObstaculo(Vector3 posicao);
    public virtual Vector3 Construir(Vector3 posicao)
    {

        if (ConstruirChaoDeSeguranca(posicao))
        {
            RandomizadorDeOperacao();
            ConstruirObstaculo(posicao);

            
            if (construirChao)
            {
                ConstruirChao(posicao);
            }
        }
        posicao.x++;
        return posicao;
    }
    public virtual void ConstruirChao(Vector3 posicao)
    {
        Instantiate(ComponentesDoMapa[0], posicao, Quaternion.identity, ConjuntoDeComponents.transform);
        ConstruirAbaixoDoChao(posicao);
    }
    public virtual void ConstruirAbaixoDoChao(Vector3 posicao)
    {
        for (int k = 1; k < 5; k++)
        {
            Vector3 v2 = new Vector3(posicao.x, posicao.y - k, 0);
            Instantiate(ComponentesDoMapa[1], v2, Quaternion.identity, ConjuntoDeComponents.transform);
        }

    }
    public bool ConstruirChaoDeSeguranca(Vector3 posicao)
    {
        
        if (primeiraVez>0)
        {
            ChaoDeInicio = (GameObject)Resources.Load("C_Cidade");
            for (int k = 0; k < 8; k++)
            {
                Vector3 v2 = new Vector3(posicao.x, posicao.y - k, 0);
                Instantiate(ChaoDeInicio, v2, Quaternion.identity, ConjuntoDeComponents.transform);
            }
            primeiraVez--;
            return false;
        }
        else
        {
            return true;
        }
    }
    protected bool esperarIntervaloEntreObstaculos = true;
    // Use this for initialization
    public virtual void Start()
    {

        ComponentesDoMapa = new List<GameObject>();
        ConjuntoDeComponents = GameObject.FindGameObjectWithTag("ConjuntoDeComponentes");
        ComponentesDoMapaEmOperacao = new Dictionary<string,ComponentData>();
    }

    public void SetNivel(int nivel)
    {
        Experiencia = nivel;
    }
    private bool VerificarSeFoiFinalizadoAsOperacao()
    {
        foreach (ComponentData cd in ComponentesDoMapaEmOperacao.Values)
        {
            if (cd.TaNoStack == true)
            {
                return false;
            }
        }
        return true;
    }
    private int QtdComponentesEmOperacoesPermitidas()
    {
        int i = 0;
        foreach (ComponentData cd in ComponentesDoMapaEmOperacao.Values)//Varre todos os componentes e remove eles de operacao
        {
            if (cd.ExpNecessariaParaSerAcessado < Experiencia)
            {
                i++;
            }

        }
        if (i <= 1)
        {
            i = 2;
        }
        return i;
    }
    public void RemoverComponentesJaOperados()
    {
        construirChao = true;
        foreach (ComponentData cd in ComponentesDoMapaEmOperacao.Values)//Varre todos os componentes e remove eles de operacao
        {
            if (cd.TamanhoDaOperacao <=0)
            {
                cd.TaNoStack = false;
            }
            else
            {
                if (!cd.PrecisaDeChao)
                {
                    construirChao = false;
                }
                cd.TaNoStack = true;
            }
            if(!cd.TaNoStack)
            {
                if (cd.Intervalo <= 0)
                {
                    cd.EmEspera = false;
                }
                else
                {
                    cd.EmEspera = true;
                    cd.Intervalo--;
                }
            }
        }
    }
    protected void RandomizadorDeOperacao()
    {
        if (VerificarSeFoiFinalizadoAsOperacao())
        {
            if (intervaloEntreObstaculos <= 0)
            {
                int Repeticoes = (int)Random.Range(1, FucaoMatematica.ValorCrescenteInteiro(ComponentesDoMapaEmOperacao.Count, 1, Experiencia, 0.13f));
                temObjetoQueNaoStaka = false;
                while (Repeticoes > 0)
                {
                    foreach (ComponentData cd in ComponentesDoMapaEmOperacao.Values)
                    {
                        if (cd.ExpNecessariaParaSerAcessado < Experiencia)//tem a exp necessaria
                        {
                            if (!cd.TaNoStack)//Esse componente nao está no stack
                            {
                                if (!cd.EmEspera)
                                {
                                    if (cd.PodeStakar || !temObjetoQueNaoStaka)
                                    {
                                        if (Random.Range(0, QtdComponentesEmOperacoesPermitidas()) == 0)
                                        {
                                            cd.TaNoStack = true;
                                            cd.TamanhoDaOperacao = Random.Range(1, 1+FucaoMatematica.ValorCrescenteAlterado(cd.TamanhoDaOperacaoMax, Experiencia, 0.3f));
    
                                            cd.Intervalo = cd.TempoDeIntervalo;
                                            if (!cd.PodeStakar)
                                            {
                                                temObjetoQueNaoStaka = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                    }//Foreach
                    Repeticoes--;
                }//While
                intervaloEntreObstaculos = Random.Range(0, FucaoMatematica.ValorDecrescenteInteiro(10, 1, Experiencia, 0.3f));
            }
            else
            {
                intervaloEntreObstaculos--;
            }
        }
    }
}
