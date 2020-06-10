using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

public sealed class LoadingController : MonoBehaviour 
{
	private string loadTo = "MainMenu";
	AsyncOperation async;
	public float minimunLoadTime = 0.4f;
	public Image progressBar;

	void Start() 
	{
		loadTo = LoadingManager.Instance.SceneToLoad;
		StartCoroutine(load());
	}

	void Update() 
	{
		if (async != null)
		{
			progressBar.fillAmount += async.progress * Time.deltaTime;
		}

		if (minimunLoadTime > 0)
		{
			minimunLoadTime -= Time.deltaTime;
		} else {
			minimunLoadTime = 0;
		}
		
		if (minimunLoadTime == 0 || async.isDone)
		{
			ActivateScene();
		}
	}

    IEnumerator load() 
	{
        async = SceneManager.LoadSceneAsync(loadTo);
		async.allowSceneActivation = false;
        yield return null;
    }
 
    void ActivateScene() 
	{
        async.allowSceneActivation = true;
    }
}