using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolaDoPeScript : MonoBehaviour {
    bool voltouParaOchao = false;
    float tempoEspera = 0.1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.layer != 8 || collision.tag!="Chao")
        {
            return;
        }
        voltouParaOchao = true;
        if (collision.name == "Nuvem")
        {
            tempoEspera = 0.2f;
        }
        else
        {
            tempoEspera = 0.1f;
        }

        gameObject.GetComponentInParent<PlayerController>().NoChao = true;
        gameObject.GetComponentInParent<PlayerController>().playerAnim.Jump(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4 || collision.tag == "Food" || collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.tag == "ObjetoImaterial")
        {
            gameObject.GetComponentInParent<PlayerController>().NoChao = false;
            return;
        }
        StartCoroutine(SaiuDoChao());
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       if( collision.tag == "Chao")
        {
            gameObject.GetComponentInParent<PlayerController>().NoChao = true;
        }
    }
    IEnumerator SaiuDoChao()
    {
        voltouParaOchao = false;
        yield return new WaitForSeconds(tempoEspera);
        if (!voltouParaOchao)
            gameObject.GetComponentInParent<PlayerController>().NoChao = false;
        else
        {
            //Debug.Log("<color=Yellow>Corrigido</color>");
        }
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
