using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhoScript : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerInterno")
            collision.gameObject.GetComponentInParent<PlayerController>().FinalizarJogo();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
