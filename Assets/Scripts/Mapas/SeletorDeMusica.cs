using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeletorDeMusica : MonoBehaviour {
    public List<AudioClip> Musicas;
    int i = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if((int)GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetPlayerPosicao().position.x == 400*i)
        {
            i++;
            if (i >= Musicas.Count)
            {
                i = 1;
            }
            

            gameObject.GetComponent<AudioSource>().clip = Musicas[i-1];
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<AudioSource>().loop = true;
            
        }
	}
}
