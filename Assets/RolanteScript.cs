using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolanteScript : MonoBehaviour {
    public float torque;
    public Rigidbody2D rb;
    public int velocidade = -5;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velocidade, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerInterno")
        {
            if (velocidade < 0)
            {
                collision.gameObject.GetComponentInParent<PlayerController>().CausarDano(-velocidade);
            }
        }
    }
    private void Update()
    {
        if(rb.velocity.x != velocidade){
            velocidade = (int)rb.velocity.x;
            rb.angularVelocity = 0;
            rb.AddTorque(-velocidade*60);
        }
    }
}
