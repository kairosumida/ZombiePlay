using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour {
    public List<Sprite> BackgroundDeserto;
    public List<Sprite> BackgroundCidade;
    public List<Sprite> BackgroundMundoCeu;
    public List<Sprite> BackgroundMundoDoce;
    public List<Sprite> BackgroundFloresta;
    public List<Sprite> BackgroundMundoVerde;
    public List<Sprite> BackgroundInvisivel;
    public List<Sprite> BackgroundMundoGelo;
    public GameObject Background1;
    public GameObject Background2;
    public GameObject BackgroundEmEspera;
    public GameObject Filho;
    private List<Sprite> BackGroundSelected;
    public bool iniciar = false;
    public void SetarBackGround(int codigo)
    {
        iniciar = true;
        if(codigo == 0)
        {
            BackGroundSelected = BackgroundDeserto;
        }
        else if(codigo == 1)
        {
            BackGroundSelected = BackgroundCidade;
        }
        
        else if(codigo == 2)
        {
            BackGroundSelected = BackgroundMundoDoce;
        }
        else if(codigo == 3)
        {
            BackGroundSelected = BackgroundFloresta;
        }
        else if(codigo == 4)
        {
            BackGroundSelected = BackgroundMundoVerde;
        }
        else if (codigo == 5)
        {
            BackGroundSelected = BackgroundMundoCeu;
        }
        else if(codigo == 6)
        {
            BackGroundSelected = BackgroundInvisivel;
        }
        else if(codigo == 7)
        {
            BackGroundSelected = BackgroundMundoGelo;
        }
        BackgroundEmEspera.GetComponent<SpriteRenderer>().sprite = BackGroundSelected[Random.Range(0, BackGroundSelected.Count)];
    }
    private void Update()
    {
        if (iniciar)
        {
            if (Filho.transform.position.x >= Background2.transform.position.x)
            {
                float tamanhoSprite = Background2.transform.position.x - Background1.transform.position.x;
                Background1.GetComponent<SpriteRenderer>().sprite = Background2.GetComponent<SpriteRenderer>().sprite;
                Background1.transform.position = Background2.transform.position;

                Background2.transform.position = new Vector3(tamanhoSprite + Background1.transform.position.x, Background1.transform.position.y);
                BackgroundEmEspera.GetComponent<SpriteRenderer>().sprite = BackGroundSelected[Random.Range(0, BackGroundSelected.Count)];
                Background2.GetComponent<SpriteRenderer>().sprite = BackgroundEmEspera.GetComponent<SpriteRenderer>().sprite;
            }
            else if ((int)Filho.transform.position.x == 0)
            {
                Background1.GetComponent<SpriteRenderer>().sprite = BackGroundSelected[Random.Range(0, BackGroundSelected.Count)];
                Background2.GetComponent<SpriteRenderer>().sprite = BackGroundSelected[Random.Range(0, BackGroundSelected.Count)];
            }
        }
    }
}
