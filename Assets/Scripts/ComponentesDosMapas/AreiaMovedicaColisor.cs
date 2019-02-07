using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreiaMovedicaColisor : MonoBehaviour {
    private bool  descendo = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerInterno")
        {
            if (collision.gameObject.transform.position.y > -0.9f)
            {
                descendo = true;
                StartCoroutine(Descer());
                collision.gameObject.GetComponentInParent<PlayerController>().CausarDano(0.5f);
            }
            else
            {
                collision.gameObject.GetComponentInParent<PlayerController>().DiminuirCoracao();
            }
        }
    }
    IEnumerator Descer()
    {
        yield return new WaitForSeconds(0.2f);
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.1f, 0);
    }
}
