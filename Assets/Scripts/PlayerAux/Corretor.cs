using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corretor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Chao")
        {

            gameObject.GetComponentInParent<PlayerController>().Filho.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.7f);
        }
    }
}
