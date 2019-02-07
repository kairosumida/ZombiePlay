using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoTransparentScript : MonoBehaviour {
    private bool emCima = false;
    private int intensidade = 0;
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Limpador")
        {
            emCima = false;
            StartCoroutine(ObjSaiu());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Limpador")
        {
            emCima = true;
            StartCoroutine(ObjEmcima());
        }
    }
    IEnumerator ObjEmcima()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (emCima)
            {
                
                gameObject.GetComponentInParent<SpriteRenderer>().color = new Color(0, 0.6510448f, 1, 0.04f*intensidade);
                if (intensidade >= 15)
                {
                    break;
                }
                intensidade++;
            }
            else
            {
                break;
            }
        }
    }
    IEnumerator ObjSaiu()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (!emCima)
            {
               
                gameObject.GetComponentInParent<SpriteRenderer>().color = new Color(0, 0.6510448f, 1, 0.04f * intensidade);
                if (intensidade <= 0)
                {

                    break;
                }
                intensidade--;
            }
            else
            {
                break;
            }
        }
    }
}
