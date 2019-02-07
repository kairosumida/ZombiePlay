using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public List<int> Experiencias;
    public int Posicao;
    public bool GameOver = false;
    public Canvas TelaDeFinalizacao;
    public Text TextoContagemRegressiva;
    public GameObject Pocao;
    
  
    public int TamanhoDoBolo = 1; //Variavel usada apenas pelo mapa MundoDoce Deve ser 1 pois é a escala do bolo
	// Use this for initialization
	void Start () {
        ZerarExp();
	}
    private void ZerarExp()
    {
        Experiencias = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            Experiencias.Add(1);
        }
    }
	public int GetPosicao()
    {
       return (int)GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetPlayerPosicao().position.x;
    }
    public int GetExperiencias(int CodigoDoMapa)//Deve ser acessado pela classe MapaGenerator. Quando ela cria o mapa. ela acessa o nivel armazenado no gamecontroller e passa para o mapa.
    {
        return Experiencias[CodigoDoMapa];
    }
    public void AcrescentarExperiencias(int codigoDoMapa, int exp)
    {
        Experiencias[codigoDoMapa]+=exp;
    }
    private void Reiniciar()
    {
        ZerarExp();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Filho.transform.position = new Vector3(0, 100, 0);
        GameOver = false;
        GameObject.FindGameObjectWithTag("MapaController").GetComponent<MapaGenerator>().PosicaoDoConstrutor = new Vector3(0, 0, 0);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ReiniciarJogo();
    }
    public void InstanciarPocao(Vector3 posicao)//O mapController irá pedir para instanciar
    {
        Instantiate(Pocao, posicao, Quaternion.identity, GameObject.FindGameObjectWithTag("ConjuntoDeComponentes").transform);
    }
    // Update is called once per frame
    private bool finalizouJa = false;
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GameOver)
        {
            GameOver = true;
        }
        if (GameOver &&!finalizouJa)
        {
            finalizouJa = true;
            TelaDeFinalizacao.enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().FinalizarJogo();
            StartCoroutine(Finalizacao());
            
        }
        if (GameOver)
        {
            if ((Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Q) ||
                Input.GetKeyDown(KeyCode.Joystick1Button1) ||
                Input.GetKeyDown(KeyCode.Joystick1Button2) ||
                Input.GetKeyDown(KeyCode.Joystick1Button3) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button4) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button5) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button6) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button7) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button8) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button9) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button10) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button11) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button12) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button13) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button14) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button15) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button16) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button17) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button18) ||
                    Input.GetKeyDown(KeyCode.Joystick1Button19) ||
                    Input.anyKeyDown
                ))
            {
                //Reiniciar();

                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }

	}
    IEnumerator Finalizacao()
    {
        for(int i = 0; i<11; i++)
        {
            TelaDeFinalizacao.GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0.1f*i);
               yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3f);

    }
}
