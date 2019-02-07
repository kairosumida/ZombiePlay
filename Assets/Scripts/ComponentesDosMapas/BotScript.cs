using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour {
    public float velocidade = -2;
    public int Nivel;
    bool ok = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bote" || collision.gameObject.tag == "Chao")
           
                Retornar();
    }
    public void SaltarDeVoltaNotempo()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y);
        Retornar();
    }
    public void Retornar()
    {
        if(gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            if (Nivel >30) { velocidade = Random.Range(-1, -2); }
            else if(Nivel > 15) { velocidade = Random.Range(-1, -2); }
            else
            {
                velocidade = -1.3f;
            }
        }
        else if(gameObject.GetComponent<Rigidbody2D>().velocity.x <0)
        {
            if (Nivel >30) { velocidade = Random.Range(1, 3); }
            else if (Nivel > 15) { velocidade = Random.Range(2, 3); }
            else
            {
                velocidade = 1.3f;
            }
        }
        else
        {
            velocidade = 1.3f;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
       gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidade, 0);

    }
}
