using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_Nuvem : MonoBehaviour {
    private bool jaAcessado = false;
    private bool jaDesceu = false;
    private int Nivel =1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerInterno")
        {
            
            if (!jaAcessado)
            {
                
                jaAcessado = true;
                StartCoroutine(Cair());
                Destroy(gameObject, 3f);
            }
        }
    }
    public void SetarAtributos(int nivel)
    {
        Nivel = nivel;
       
    }
    IEnumerator Cair()
    {
       

        if (Nivel < 200)
        {
            float valor = 0.05f + (1 / Mathf.Pow(Nivel, 0.3f));
            yield return new WaitForSeconds(valor);
            
        }
        else if (Nivel < 400)
        {
            float valor = 0.05f + (1 / Mathf.Pow(Nivel, 0.6f));
            yield return new WaitForSeconds(valor);
        }
        else
        {
            float valor = 0.01f + (1 / Mathf.Pow(Nivel, 0.9f));
              yield return new WaitForSeconds(valor);
        }
        gameObject.AddComponent<Rigidbody2D>().gravityScale =1f;
        
    }
    private void Update()
    {
        
       
            
        if ((int)GameObject.FindGameObjectWithTag("PlayerInterno").transform.position.x == (int)gameObject.transform.position.x)
        {
            if (Nivel > 150 && !jaDesceu)
            {
                jaDesceu = true;
                if (Random.Range(0, 12) == 0)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f);
                    
                }
            }
        }
    }
}
