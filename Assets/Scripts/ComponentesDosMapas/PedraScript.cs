using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedraScript : MonoBehaviour {
    private int Nivel = 1;
    int dano = 2;
    public float VelocidadeX;
    public float VelocidadeY;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-90,-120), Random.Range(30,60), 0));
	}
    public void SetarPropriedades(int nivel)
    {
    
        if (nivel > 50)
        {
            dano = 4;
        }
        else if(nivel > 100)
        {
            dano = 7;
        }
        else if(nivel > 200)
        {
            dano = 10;
        }
    }
    private void Update()
    {
        VelocidadeX = gameObject.GetComponent<Rigidbody2D>().velocity.x;
        VelocidadeY = gameObject.GetComponent<Rigidbody2D>().velocity.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerInterno")
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.x < -3)
            {
                Debug.Log("DANO");
                collision.gameObject.GetComponentInParent<PlayerController>().CausarDano(dano);
            }
        }
    }
  
}
