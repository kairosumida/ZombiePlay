using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPorta : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "PlayerInterno")
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.W))){
                Destroy(gameObject);
            }
        }
    }
}
