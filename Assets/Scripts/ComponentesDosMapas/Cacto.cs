using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacto : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerInterno")
        {
            collision.gameObject.GetComponentInParent<PlayerController>().CausarDano(1f);
        }
    }
}
