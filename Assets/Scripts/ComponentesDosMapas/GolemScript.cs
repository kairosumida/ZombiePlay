using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemScript : MonoBehaviour {
    Rigidbody2D _rigid;
    float _speed = 2;
    public GameObject Inteligencia;
	// Use this for initialization
	void Start () {
        _rigid = GetComponent<Rigidbody2D>();
	}
	public void SetarAtributos(int nivel)
    {
        if(nivel < 100)
        {
            
            Destroy(Inteligencia);
        }
        if(nivel < 200)
        {
            if (Random.Range(0, 2) == 1)
            {
                Destroy(Inteligencia);
            }
        }
    }
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.localScale.x < 0)//LocalScale quando negativo rotaciona o personagem
        {
            _rigid.velocity = new Vector2(_speed *-1, _rigid.velocity.y);
        }
        else
        {
            _rigid.velocity = new Vector2(_speed, _rigid.velocity.y);
        }

    }
}
