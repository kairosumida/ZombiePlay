using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComerBolo : MonoBehaviour {
    bool podeComer = true;
    bool sofreDano = true;
    public AudioClip Comer;
    public GameObject BoloPai;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerInterno")
        {
            if (sofreDano)
            {
                sofreDano = false;
                collision.gameObject.GetComponentInParent<PlayerController>().CausarDanoSemSom(0.3f);
                StartCoroutine(CausarDano());
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxisRaw("Vertical") < 0 || (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Alpha1)))
            {
                if (podeComer)
                {
                    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TamanhoDoBolo > 0)
                    {
                        gameObject.GetComponent<AudioSource>().clip = Comer;
                        gameObject.GetComponent<AudioSource>().Play();
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TamanhoDoBolo--;
                        podeComer = false;
                    }
                  if(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TamanhoDoBolo <= 0)
                    {
                        Destroy(BoloPai);
                    }
                }
            }
        }
    }
    IEnumerator CausarDano()
    {
        yield return new WaitForSeconds(0.1f);
        sofreDano = true;
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Vertical") == 0 || Input.GetKeyUp(KeyCode.DownArrow))
        {
            podeComer = true;
        }
    }
  
}
