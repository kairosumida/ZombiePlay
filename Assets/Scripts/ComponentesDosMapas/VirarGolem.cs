using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirarGolem : MonoBehaviour {
    public GameObject Golem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerInterno")
        {

            if(Golem.transform.position.x > collision.gameObject.transform.position.x)//A posicao do golem é maior que a do player
            {
                Golem.transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
               
            }
            else if(Golem.transform.position.x<= collision.gameObject.transform.position.x)
            {
                Golem.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
    }
}
