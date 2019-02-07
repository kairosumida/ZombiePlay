using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArameFarpadoScript : MonoBehaviour {
    bool ativar = true;
    float dano = 1f;
	// Use this for initialization
	void Start () {
		
	}
    public void SetarAtributos(int Exp)
    {
        dano = FucaoMatematica.ValorCrescente(5, Exp);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerInterno")
        {
            if (ativar)
            {
                ativar = false;
               
                collision.gameObject.GetComponentInParent<PlayerController>().CausarDano(dano);
                collision.gameObject.GetComponentInParent<PlayerController>().DeixarLento(0.3f);
                StartCoroutine(Esperar());

            }
        }
    }
 IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1f);
        ativar = true;
    }
}
