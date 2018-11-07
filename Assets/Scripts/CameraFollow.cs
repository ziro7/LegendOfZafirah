using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraFollow : MonoBehaviour {

	[SerializeField] Transform target;
	[SerializeField]
	float smoothing = 5f;

	Vector3 offset;

	void Awake() {
		Assert.IsNotNull(target);
	}

	//GameObject player;
	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag("Player");
		offset = transform.position - target.position;

	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = player.transform.position;

		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}

}
