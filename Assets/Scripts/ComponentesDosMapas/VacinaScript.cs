using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacinaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void Update()
    {
        if (gameObject.transform.position.y < -4)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x+1, Random.Range(3,15), 0);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerInterno")
        {
            if (collision.gameObject.GetComponentInParent<PlayerController>().Cura == false)
            {
                collision.gameObject.GetComponentInParent<PlayerController>().Cura = true;
                Destroy(gameObject);
            }
            else { }
        }
        
    }
}
