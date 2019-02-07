using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaGenerator : MonoBehaviour {
    public int TamanhoDoMapa;
    public int TamanhoDoMapaConstruido;
    public Vector3 PosicaoDoConstrutor;
    [SerializeField]
    public IMapa MapaSelecionado;
    public GameObject MapasGameObject;
    public GameController GCtrl;
    private int posicaoDaUltimaInstanciaDePocao = 0;
    private int posicaoJogadorRegistro =0;
    int CodigoDoMapaConstruindo;
    //Coloque Aqui os mapas que serão utilizados
    private void Start()
    {
        GCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!GCtrl.GameOver)
        {
            AvancarExp();
            AvisarExpDoMapa();
        }
    }
    private void FixedUpdate()
    {
        IniciarConstrucao();
        ConstruirPocao();
    }
    private void AvancarExp()
    {
        if(GetPosicaoJogador() != posicaoJogadorRegistro)
        {
            posicaoJogadorRegistro = GetPosicaoJogador();
            GCtrl.AcrescentarExperiencias(CodigoDoMapaConstruindo, 1);
        }
    }
    public void AvisarExpDoMapa()
    {
        if(GetPosicaoJogador()>0)
        MapaSelecionado.SetNivel(GCtrl.GetExperiencias(CodigoDoMapaConstruindo));
    }
    public void ConstruirPocao()
    {
        if(PosicaoDoConstrutor.x%25 ==0 && PosicaoDoConstrutor.x != 0 && (int)PosicaoDoConstrutor.x != posicaoDaUltimaInstanciaDePocao)
        {
            posicaoDaUltimaInstanciaDePocao = (int)PosicaoDoConstrutor.x;
            Vector3 v1 = new Vector3(PosicaoDoConstrutor.x - 5, PosicaoDoConstrutor.y + 20);
            GCtrl.InstanciarPocao(v1);
        }
    }
    
    public void IniciarConstrucao()
    {
        if (GetPosicaoJogador() + 20 >= PosicaoDoConstrutor.x)//Compara a posicao que o jogador está com a posicao do construtor. Permitindo seja construido sempre que o jogador estiver a certa distancia do construtor
        {
            if (TamanhoDoMapaConstruido >= TamanhoDoMapa)
            {
                TamanhoDoMapa = Random.Range(120, 150);
                TamanhoDoMapaConstruido = 0;
                SelecionarMapa();
            }
            else
            {
                TamanhoDoMapaConstruido++;//Fala que construiu mais um pedaco
                MapaSelecionado.Construir(PosicaoDoConstrutor);
                PosicaoDoConstrutor.x++;//Avanca para o lado, pois a posicao atual ja foi construida
            }
        }
    }
    public void SelecionarMapa()
    {
       
        if(GetPosicaoJogador() <= 75)
        {
            CodigoDoMapaConstruindo = 0;
        }
        else if(GetPosicaoJogador() <= 150)
        {
            CodigoDoMapaConstruindo = 1;
        }
        else if(GetPosicaoJogador() <= 400)
        {
            CodigoDoMapaConstruindo = Random.Range(2, 4);
        }
        else if(GetPosicaoJogador() <= 600)
        {
            CodigoDoMapaConstruindo = Random.Range(4, 6);
        }
        else if(GetPosicaoJogador() <= 900){
            CodigoDoMapaConstruindo = Random.Range(0, 3);
        }
        else if (GetPosicaoJogador() < 1200)
        {
            CodigoDoMapaConstruindo = Random.Range(3, 6);
        }
        else if (GetPosicaoJogador() < 1500)
        {
            CodigoDoMapaConstruindo = 6;
        }
        else if (GetPosicaoJogador() < 2000)
        {
            CodigoDoMapaConstruindo = Random.Range(0, 6);
        }
        else if (GetPosicaoJogador() < 2300)
        {
            CodigoDoMapaConstruindo = 7;
        }
        else
        {
            CodigoDoMapaConstruindo = Random.Range(0, 8);
        }
        foreach (MapaPai go in MapasGameObject.GetComponents<MapaPai>())
        {
            Destroy(go);
        }

        if (CodigoDoMapaConstruindo == 0)
        {
            MapaSelecionado = MapasGameObject.AddComponent<Deserto>();
            
        }
        if(CodigoDoMapaConstruindo == 1)
        {
            MapaSelecionado = MapasGameObject.AddComponent<CidadeGenerator>();
        }
        
        if(CodigoDoMapaConstruindo == 2)
        {
            MapaSelecionado = MapasGameObject.AddComponent<MundoDoce>();
        }
        if(CodigoDoMapaConstruindo == 3)
        {
            MapaSelecionado = MapasGameObject.AddComponent<Floresta>();
            TamanhoDoMapa = 40;
        }
        if(CodigoDoMapaConstruindo == 4)
        {
            MapaSelecionado = MapasGameObject.AddComponent<MundoVerde>();
        }
        if (CodigoDoMapaConstruindo == 5)
        {
            MapaSelecionado = MapasGameObject.AddComponent<MundoCeu>();
        }
        if (CodigoDoMapaConstruindo == 6)
        {
            MapaSelecionado = MapasGameObject.AddComponent<Invisivel>();

        }
        if(CodigoDoMapaConstruindo == 7)
        {
            MapaSelecionado = MapasGameObject.AddComponent<MundoGelo>();
        }
        AvisarExpDoMapa();
        GameObject.FindGameObjectWithTag("BackgroundController").GetComponent<BackGroundController>().SetarBackGround(CodigoDoMapaConstruindo);
       
    }
    
    public int GetPosicaoJogador()
    {//Apesar de pegar a pontuação. A ponduação segue a posicao do jogador
        return GCtrl.GetComponent<GameController>().GetPosicao() ;
    }
}
