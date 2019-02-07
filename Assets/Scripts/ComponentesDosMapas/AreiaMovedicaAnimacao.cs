using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AreiaMovedicaAnimacao : MonoBehaviour {
    public List<Sprite> ImgsAreiaMovedica;
    int i =0;
    // Use this for initialization

    private void Start()
    {
        StartCoroutine(MudarImg());
    }

    IEnumerator MudarImg()
    {
        while (true) {
            i++;
            if (i >= ImgsAreiaMovedica.Count)
            {
                i = 0;
            }
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<SpriteRenderer>().sprite = ImgsAreiaMovedica[i];
            
        }
    }
}
