using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urubu : MonoBehaviour {
    private float velocidade;
    public AudioClip SomBatida;
    public int Nivel =1;
    // Use this for initialization

    public void SetarTributos(int Nivel)
    {
        velocidade = Random.Range(0.5f,FucaoMatematica.ValorCrescenteAlterado(8, Nivel, 0.3f));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidade, 0);
        this.Nivel = Nivel;
        Debug.Log("Corvo com " + FucaoMatematica.ValorCrescente(10, Nivel));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerInterno")
        {
            collision.gameObject.GetComponentInParent<PlayerController>().CausarDano(Random.Range(FucaoMatematica.ValorCrescente(10, Nivel)/2, FucaoMatematica.ValorCrescente(10,Nivel)));
            
            //gameObject.GetComponent<AudioSource>().clip = SomBatida;
            //gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);

        }
    }
}
