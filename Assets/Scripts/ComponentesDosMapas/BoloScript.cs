using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoloScript : MonoBehaviour {
    int tamanhoBolo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tamanhoBolo = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TamanhoDoBolo;
        gameObject.transform.localScale = new Vector3(tamanhoBolo*0.1f, tamanhoBolo*0.1f);
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetPlayerPosicao().position.x >= gameObject.transform.position.x+3)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TamanhoDoBolo = 1;
            Destroy(gameObject, 0.5f);
        }
    }
}
