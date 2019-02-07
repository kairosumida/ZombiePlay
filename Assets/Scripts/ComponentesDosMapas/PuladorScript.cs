using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuladorScript : MonoBehaviour {
    private int Nivel = 1;
    float distanciaEmX = 200;
    float distanciaEmY = 4;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerInterno")
        {
            collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector3(distanciaEmX, distanciaEmY, 0);
            Debug.Log(distanciaEmY);
        }
    }
    public void SetarPropriedades(int nivel)
    {
        Nivel = nivel;
        if(Nivel < 140)
        {
            Debug.Log("easy");
            distanciaEmX = 120;
            distanciaEmY = 4;
        }
        else if(Nivel < 200)
        {
            Debug.Log("medio");
            distanciaEmY = 7;
            distanciaEmX = 130;
        }
        else if(Nivel < 300)
        {
            Debug.Log("Hard");
            distanciaEmY = Random.Range(180, 250);
            distanciaEmX = Random.Range(6, 10);
        }
    }
}
