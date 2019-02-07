using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasaScript : MonoBehaviour {
    private int Nivel;
    
	// Use this for initialization
	void Start () {
        
    }
	public void SetarAtributos(int Exp)
    {
        if (Exp < 50) {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }
        }
        else if (Exp < 120)
        {
                Destroy(gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount)).gameObject);
            Destroy(gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount)).gameObject);
        }
        else if(Exp > 240)
        {
            Destroy(gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount)).gameObject);
        }

    }
	// Update is called once per frame
	void Update () {
		
	}
}
