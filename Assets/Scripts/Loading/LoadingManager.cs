using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class LoadingManager : MonoBehaviour
{
	private string sceneToLoad = "MainMenu";

	public static LoadingManager Instance;
	
	public string SceneToLoad
	{
		get { return sceneToLoad; }
	}

    void Awake()
    {
		if(Instance == null)
		{
			Instance = this;
			
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
    }

	void LoadTo(string sceneName)
	{
		Time.timeScale = 1;
		sceneToLoad = sceneName;
		SceneManager.LoadScene("Loading", LoadSceneMode.Single);
	}

	public static void LoadMainMenu()
	{
		if(Instance == null)
		{
			Debug.LogError("There is not a Loading Manager Instance in game.");
			return;
		}
		
		LoadingManager.Instance.LoadTo("MainMenu");
	}

	public static void LoadScene(string sceneName)
	{
		if(Instance == null)
		{
			Debug.LogError("There is not a Loading Manager Instance in game.");
			return;
		}
		
		LoadingManager.Instance.LoadTo(sceneName);
	}

	public static void ReloadScene()
	{
		if(Instance == null)
		{
			Debug.LogError("There is not a Loading Manager Instance in game.");
			return;
		}

		LoadingManager.Instance.LoadTo(SceneManager.GetActiveScene().name);
	}
}