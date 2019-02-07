using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPulo : MonoBehaviour {
    public  Rigidbody2D rb;
    private bool noChao = true;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Chao")
        {
            StartCoroutine(delay());
            if(!noChao)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 3);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chao")
        {
            noChao = true;
        }
    }
    IEnumerator delay()
    {
        
        yield return new WaitForSeconds(0.1f);
        noChao = false;
    }
}
