using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {


	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
		Debug.Log("do i get here?");
	}

	public void QuitLevel()
	{
		SceneManager.LoadScene(1);
	}

	public void Quit()
	{
		Application.Quit();
	}


}
