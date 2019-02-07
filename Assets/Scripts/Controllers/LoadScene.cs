using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {
    
    public Slider Slider;
	void Start () {
        StartCoroutine(LoadAsynchronously());
	}
	IEnumerator LoadAsynchronously()
    {
        yield return new WaitForSeconds(0.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Jogo");
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Slider.value = progress;
            yield return null;
        }
    }
	
}
