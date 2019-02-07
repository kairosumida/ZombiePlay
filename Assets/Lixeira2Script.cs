using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixeira2Script : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerInterno")
        {
            collision.gameObject.GetComponentInParent<PlayerController>().PodeAbaixar = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerInterno")
        {
            collision.gameObject.GetComponentInParent<PlayerController>().PodeAbaixar = true;
        }
    }
}
