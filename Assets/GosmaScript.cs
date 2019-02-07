using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosmaScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerInterno")
        {
            collision.gameObject.GetComponentInParent<PlayerController>().DeixarLento(1);


        }
    }
}
