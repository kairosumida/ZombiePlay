using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoInvScript : MonoBehaviour {
    float tempoVerde;
    float tempoVermelho;
    public int Nivel = 1;
    public Sprite Cuidado;
    public Sprite Pule;
    // Use this for initialization
  
	public void Comecar()
    {
        SetarTempo();
        StartCoroutine(Inv());
    }
	
    private void SetarTempo()
    {
        if (Nivel == 0)
            Nivel = 1;
        double valorDecrescemte = (System.Math.Pow(Nivel, 0.4));
        double valorCrescente = (System.Math.Log(Nivel) / 2);
        tempoVerde = Random.Range(2, (float)(2 + (10 / valorDecrescemte)));
        tempoVermelho = Random.Range(1, (float)(1 + valorCrescente));
        if(tempoVerde == 0)
        {
            tempoVerde = 1;
            tempoVermelho = 1;
        }
    }
    IEnumerator Inv()
    {
        while (true)
        {
           
            yield return new WaitForSeconds(tempoVerde);
            gameObject.GetComponent<SpriteRenderer>().sprite = Cuidado;
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(tempoVermelho);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = Pule;



        }
    }
}
