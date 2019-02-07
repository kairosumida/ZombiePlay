using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MundoGelo : MapaPai {

   


   
    public override void ConstruirObstaculo(Vector3 posicao)
    {
        RemoverComponentesJaOperados();
        if (ComponentesDoMapaEmOperacao["ConstruirCratera"].TaNoStack)
        {
            ComponentesDoMapaEmOperacao["ConstruirCratera"].TamanhoDaOperacao--;

        }
        if (ComponentesDoMapaEmOperacao["BlocoGelo"].TaNoStack)
        {
            Vector3 v1 = new Vector3(posicao.x, posicao.y + 4, 0);
            GameObject go = Instantiate(ComponentesDoMapa[2], v1, Quaternion.identity, ConjuntoDeComponents.transform);
            ComponentesDoMapaEmOperacao["BlocoGelo"].TamanhoDaOperacao = 0;
        }
        
    }



    public override void Start()
    {
        base.Start();
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_Transparente"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("C_TransparenteBaixo"));
        ComponentesDoMapa.Add((GameObject)Resources.Load("BlocoGelo"));
        AdicionarNomeAosComponentes();
    }
    public void AdicionarNomeAosComponentes()
    {
        ComponentesDoMapaEmOperacao.Add("BlocoGelo", new ComponentData() { ExpNecessariaParaSerAcessado = 0, PodeStakar = true, PrecisaDeChao = true, TamanhoDaOperacaoMax = 1, Intervalo = 7, TempoDeIntervalo = 10 });
        ComponentesDoMapaEmOperacao.Add("ConstruirCratera", new ComponentData() { ExpNecessariaParaSerAcessado = 5, PodeStakar = false, PrecisaDeChao = false, TamanhoDaOperacaoMax = 3, Intervalo = 1, TempoDeIntervalo = 5 });
    }
    public override Vector3 Construir(Vector3 posicaoDoConstruor)
    {
        posicaoDoConstruor = base.Construir(posicaoDoConstruor);
        return posicaoDoConstruor;
    }
}
