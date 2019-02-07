using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDano : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerInterno")
        {
            collision.gameObject.GetComponentInParent<PlayerController>().FinalizarJogo();
        }
    }
}
