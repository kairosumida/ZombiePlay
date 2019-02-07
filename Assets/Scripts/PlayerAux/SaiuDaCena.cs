using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaiuDaCena : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
