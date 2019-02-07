using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConjuntoComponentsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        foreach(Transform f in transform)
        {
            if(f.position.x+25<= GameObject.FindGameObjectWithTag("PlayerInterno").transform.position.x)
            {
                Destroy(f.gameObject);
            }
        }
	}
}
