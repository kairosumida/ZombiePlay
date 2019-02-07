using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float _speed = 2f;
    private float _jumpForce = 6f;
    Rigidbody2D _rigid;
    private bool lento = false;
    public bool NoChao = true;
    public bool Pulou = false;
    public GameObject Filho;
    public SpriteRenderer BracoDireito;
    public SpriteRenderer Pocao;
    public bool Cura = false;
    public Text Pontuacao;
    public Slider BarraVIda;
    public float Velocidadey;
    public float Velocidadex;
    public PlayerAnimator playerAnim;
    public bool GameOver = false;
    private float tempoAtual;
    public GameObject Sons;
    public AudioClip Andar;
    // Use this for initialization
    public AudioClip CuraSom;
    private float velocidadeYBug;
    private bool emTeste = false;
    public bool PodeAbaixar = true;
    public void VoltarPadrao()
    {
        _speed = 2;
        _jumpForce = 6;
    }
	void Start () {
        _rigid = gameObject.GetComponentInChildren<Rigidbody2D>();
        playerAnim = gameObject.GetComponentInChildren<PlayerAnimator>();
        StartCoroutine(DiminuirVida());
        Pontuacao.text = "Pontuação: 0";
        
    }
	public Transform GetPlayerPosicao()
    {
        return Filho.transform;
    }
    public void SetPlayerPosicao(Vector3 posicao)
    {
        Filho.transform.position = posicao;
    }
    public AudioClip Dano;
    public void CausarDano(float potencia)
    {
        if (!GameOver)
        {
            BarraVIda.value += potencia;
            gameObject.GetComponent<AudioSource>().clip = Dano;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
    public void CausarDanoSemSom(float potencia)
    {
        if (!GameOver)
        {
            BarraVIda.value += potencia;
        }
    }

    public Text fpsText;
    public float deltaTime;

    // Update is called once per frame
    void Update () {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();

        Pontuacao.text = ((int)Filho.transform.position.x).ToString();
        
       
        if(Cura)
        {
            Pocao.color = new Color(1,1,1,1);
            BarraVIda.value = 0;
            gameObject.GetComponent<AudioSource>().clip = CuraSom;
            gameObject.GetComponent<AudioSource>().Play();
            Cura = false;
        }
        else
        {
            Pocao.color = new Color(1, 1, 1, 0);
        }
        if (Filho.transform.position.y < -2)
            DiminuirCoracao();
        if (GameOver)
            return;
      
     
        if ((Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.W))) && DeuOTempo)
        {
            StartCoroutine(PararDeAndar());
        }
        
        

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("Horizontal") > 0)
        {
            _rigid.velocity = new Vector2( _speed * 2, _rigid.velocity.y);
            Parar = false;
        }
        else if (Parar)
        {
            _rigid.velocity = new Vector2(0, _rigid.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("Horizontal") < 0)
        {
            _rigid.velocity = new Vector2( _speed / 2, _rigid.velocity.y);
        }
        else
        {
            _rigid.velocity = new Vector2(_speed, _rigid.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") < 0 || Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick4Button0) )
        {
            if (PodeAbaixar)
            {
                playerAnim.Abaixar(true);
            }
        }
        else
        playerAnim.Abaixar(false);
        
        if (( Input.GetAxisRaw("Vertical") > 0 ||Input.GetKeyUp(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick4Button1) ) && NoChao)
        {
            NoChao = false;
            Pulou = true;
            playerAnim.Jump(true);
             _rigid.velocity = new Vector2(_speed, _jumpForce);
        }
    }
    #region (Parar)
    bool DeuOTempo = true;
    bool Parar = false;
    IEnumerator PararDeAndar()
    {
        DeuOTempo = false;
        Parar = true;
        yield return new WaitForSeconds(3);
        
        Parar = false;
        yield return new WaitForSeconds(60);
        DeuOTempo = true;
    }
    #endregion(Parar)

    
  
    IEnumerator DiminuirVida()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            BarraVIda.value += 0.2f;
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1 - (BarraVIda.value / BarraVIda.maxValue), 1 - (BarraVIda.value / BarraVIda.maxValue));
            BracoDireito.color = gameObject.GetComponentInChildren<SpriteRenderer>().color;
            if (BarraVIda.value >= BarraVIda.maxValue)
            {
                DiminuirCoracao();
            }
        }
    }
    public void DeixarLento(float tempo)
    {
        if(!lento)
        StartCoroutine(EnuDeixarLento(tempo));
    }
    IEnumerator EnuDeixarLento(float tempo)
    {
        _speed = _speed / 2;
        lento = true;
        yield return new WaitForSeconds(tempo);
        lento = false;
        VoltarPadrao();
    }
    public void ReiniciarJogo()
    {

        StartCoroutine(DelayDaReinicializacao());
       
    }
    IEnumerator DelayDaReinicializacao()//Nessesario para o frame avancar. Pois o jogador vai para olonge para o colizor destruir os gameobjects
    {

        yield return new WaitForSeconds(0.2f);
        Filho.transform.position = new Vector3(0, 2, 0);
        GameOver = false;
        VoltarPadrao();
        _rigid.bodyType = RigidbodyType2D.Dynamic;
        BarraVIda.value = 0;
        playerAnim.Despausa();
    }
    public GameObject TocadorDeMusica;
    public void PararMusica()
    {
        StartCoroutine(PararMusicaGradualmente());
    }
    IEnumerator PararMusicaGradualmente()
    {
        for (int i = 0; i < 10; i++)
        {
            TocadorDeMusica.GetComponent<AudioSource>().volume = TocadorDeMusica.GetComponent<AudioSource>().volume - (TocadorDeMusica.GetComponent<AudioSource>().volume / 10);
            yield return new WaitForSeconds(0.1f);
            
        }
        TocadorDeMusica.GetComponent<AudioSource>().volume = 0;
    }
    private bool parar1x = false;
    private int QtdVidas = -1;
    public void DiminuirCoracao()
    {
        if (QtdVidas >= 0) {
            BarraVIda.value = 0;
            ConstruirAreaDeSeguranca();
            Limpador.SetActive(false);
            if (Filho.transform.position.y <= -2)
            {
               
            }
            QtdVidas--;
            Filho.transform.position = new Vector3(Filho.transform.position.x - 19, 2);
            StartCoroutine(AtivarLimpador());
        }
        else
        {
            FinalizarJogo();
        }
    }
    public GameObject ZonaSegura;
    public GameObject Limpador;
    IEnumerator AtivarLimpador()
    {
        yield return new WaitForSeconds(0.5f);
        Limpador.SetActive(true);
    }
  public void ConstruirAreaDeSeguranca()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 v2 = new Vector3((int)Filho.transform.position.x - 18, -i);
            Instantiate(ZonaSegura, v2, Quaternion.identity, GameObject.FindGameObjectWithTag("ConjuntoDeComponentes").transform);
            Vector3 v3 = new Vector3((int)Filho.transform.position.x - 19, -i);
            Instantiate(ZonaSegura, v3, Quaternion.identity, GameObject.FindGameObjectWithTag("ConjuntoDeComponentes").transform);
            Vector3 v4= new Vector3((int)Filho.transform.position.x - 20, -i);
            Instantiate(ZonaSegura, v4, Quaternion.identity, GameObject.FindGameObjectWithTag("ConjuntoDeComponentes").transform);
        }
    }
    public void FinalizarJogo()
    {
     
        if (!parar1x)
        {
           
            parar1x = true;
            PararMusica();
            _speed = 0;
            _rigid.bodyType = RigidbodyType2D.Static;
            CausarDano(30);
            GameOver = true;

            playerAnim.Pausa();
        }
    }
}
