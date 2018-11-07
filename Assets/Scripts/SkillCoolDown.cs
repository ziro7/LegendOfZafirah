using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillCoolDown : MonoBehaviour
{

	public List<Skill> skills;
	private Animator anim;
	private GameObject player;

	void Start()
	{
		player = GameManager.instance.Player;
		anim = player.GetComponent<Animator>();
		foreach (var Skill in skills)
		{
			Skill.currentCoolDown = Skill.cooldown;
		}
	}

	void Update()
	{

		foreach (Skill s in skills)
		{
			if (s.currentCoolDown < s.cooldown)
			{
				s.currentCoolDown += Time.deltaTime;
				s.skillIcon.fillAmount = s.currentCoolDown / s.cooldown;

			}
		}
	}

	void FixedUpdate()
	{

		//Skulle nok laves med noget løkke værk)
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (skills[0].currentCoolDown >= skills[0].cooldown)
			{
				Debug.Log("Knap Q");
				anim.Play("Spin Attack");
				skills[0].currentCoolDown = 0;
			}
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			if (skills[1].currentCoolDown >= skills[1].cooldown)
			{
				Debug.Log("Knap E");
				anim.Play("1 Handed Block");
				skills[1].currentCoolDown = 0;
			}
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			if (skills[2].currentCoolDown >= skills[2].cooldown)
			{
				Debug.Log("Knap R");
				anim.Play("Uppercut");
				skills[2].currentCoolDown = 0;
			}

		}
		else if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if (skills[3].currentCoolDown >= skills[3].cooldown)
			{
				Debug.Log("Knap 1");
				anim.Play("Stab");
				skills[3].currentCoolDown = 0;
			}

		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			if (skills[4].currentCoolDown >= skills[4].cooldown)
			{
				Debug.Log("Knap 2");
				anim.Play("Chop");
				skills[4].currentCoolDown = 0;
			}

		}
		else if (Input.GetMouseButton(0))
		{
			if (skills[5].currentCoolDown >= skills[5].cooldown)
			{
				Debug.Log("Mousebuttondown");
				anim.Play("Double Chop");
				skills[5].currentCoolDown = 0;
			}

		}

		else if (Input.GetKeyDown(KeyCode.Escape))
		{
			Debug.Log("Mousebuttondown");
			SceneManager.LoadScene("GameMenu");
		}

	}








	[System.Serializable]
	public class Skill
	{

		public float cooldown;
		public Image skillIcon;
		[HideInInspector]
		public float currentCoolDown;

	}

}

