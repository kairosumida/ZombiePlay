using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempestadeAreiaScript : MonoBehaviour {
    private float posicao;
    private int Nivel;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-2,0);
        posicao = gameObject.transform.position.x;
	}
    public void SetarAtributos(int Nivel)
    {
        this.Nivel = Nivel;
       
         if (Nivel < 300)
        {
            if (Random.Range(0, 2) == 1)
            {
                Destroy(gameObject);
            }
        }
        else if (Nivel < 400)
        {
            if (Random.Range(0, 3) == 1)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerInterno")
        {
            StartCoroutine(DescerHP(collision));
            collision.gameObject.GetComponentInParent<PlayerController>()._speed = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerInterno")
        {
            
            collision.GetComponentInParent<PlayerController>().VoltarPadrao();
        }

    }
    private void Update()
    {
        if (gameObject.transform.position.x < posicao - 40)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator DescerHP(Collider2D collision)
    {
        yield return new WaitForSeconds(0.2f);
        collision.gameObject.GetComponentInParent<PlayerController>().CausarDano(0.5f);
    }
}
