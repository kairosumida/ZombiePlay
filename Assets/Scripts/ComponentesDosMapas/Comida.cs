using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour {
    private bool jaContou = false;
    public AudioClip Falhou;
    public AudioClip Comeu;
    public void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetPlayerPosicao().position.x > gameObject.transform.position.x && !jaContou)
        {
            jaContou = true;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TamanhoDoBolo++;
            StartCoroutine(Subir());
            
            Destroy(gameObject, 1.5f);

        }
    }
    IEnumerator Subir()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.1f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = Falhou;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerInterno")
        {

            Destroy(gameObject); GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = Comeu;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
            
        }
    }
}
