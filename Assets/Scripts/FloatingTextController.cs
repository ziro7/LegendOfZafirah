using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

	private static FloatingText popUpText;
	private static GameObject hud;

		public static void Initialize()
	{
		hud = GameObject.Find("HUD");
		if (!popUpText)
			popUpText = Resources.Load<FloatingText>("Prefabs/PopUpTextParent");
		
	}

	public static void CreateFloatingText(int text, Transform location)
	{
		Initialize();
		FloatingText instance = Instantiate(popUpText);
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x, location.position.y));//location.position.x + Random.Range(-.5f,.5f), location.position.y + Random.Range(-.5f, .5f)
		Debug.Log("Pop-up er " + screenPosition.x + "pixels from the left");
		Debug.Log("Pop-up er " + screenPosition.y + "pixels from the top/bottom?");
		instance.transform.SetParent(hud.transform, true);
		instance.transform.position = screenPosition;
		instance.SetText(text.ToString());
	}

	public static void CreateFloatingTextToPlayer(int text, Transform location)
	{
		Initialize();
		FloatingText instance = Instantiate(popUpText);
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x, location.position.y));//location.position.x + Random.Range(-.5f,.5f), location.position.y + Random.Range(-.5f, .5f)
		Debug.Log("Pop-up er " + screenPosition.x + "pixels from the left");
		Debug.Log("Pop-up er " + screenPosition.y + "pixels from the top/bottom?");
		instance.transform.SetParent(hud.transform, true);
		instance.transform.position = screenPosition;
		instance.SetText(text.ToString());
	}

}
