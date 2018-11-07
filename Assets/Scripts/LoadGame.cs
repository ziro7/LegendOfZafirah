using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

	public float autoLoadNextlevelAfter;

	void Start()
	{
		Invoke("LoadNextLevel", autoLoadNextlevelAfter);
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(1);
		Debug.Log("do i get here?");
	}

}

