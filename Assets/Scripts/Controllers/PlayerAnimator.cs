using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
	}
	public void Jump(bool jump)
    {
        anim.SetBool("Jumping", jump);
    }
    public void Abaixar(bool abaixar)
    {
        anim.SetBool("Abaixar", abaixar);
    }
    public void Pausa()
    {
        anim.speed = 0;
    }
    public void Despausa()
    {
        anim.speed = 1;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
