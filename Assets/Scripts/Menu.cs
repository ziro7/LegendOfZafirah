﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	[SerializeField] GameObject hero;
	[SerializeField] GameObject tanker;
	[SerializeField] GameObject ranger;
	[SerializeField] GameObject soldier;
	[SerializeField] GameObject ghoul;

	private Animator heroAnim;
	private Animator tankerAnim;
	private Animator soldierAnim;
	private Animator rangerAnim;
	private Animator ghoulAnim;

	void Awake()
	{
		Assert.IsNotNull(hero);
		Assert.IsNotNull(ranger);
		Assert.IsNotNull(tanker);
		Assert.IsNotNull(soldier);
		Assert.IsNotNull(ghoul);
	}

	// Use this for initialization
	void Start () {
		heroAnim = hero.GetComponent<Animator>();
		tankerAnim = tanker.GetComponent<Animator>();
		rangerAnim = ranger.GetComponent<Animator>();
		soldierAnim = soldier.GetComponent<Animator>();
		ghoulAnim = ghoul.GetComponent<Animator>();

		StartCoroutine(showcase());
	}
	
	// Update is called once per frame
	void Update () {
		


	}

	IEnumerator showcase()
	{
		yield return new WaitForSeconds(1f);
		heroAnim.Play("Spin Attack");
		yield return new WaitForSeconds(1f);
		tankerAnim.Play("Attack");
		yield return new WaitForSeconds(1f);
		rangerAnim.Play("Attack");
		soldierAnim.Play("Attack");
		ghoulAnim.Play("Attack");

		StartCoroutine(showcase());
	}

	public void Battle()
	{
		SceneManager.LoadScene("Level");
	}

	public void Quit()
	{
		Application.Quit();
	}
}

