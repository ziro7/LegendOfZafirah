using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	[SerializeField]GameObject player;
	[SerializeField]GameObject[] spawnPoints;
	[SerializeField]GameObject[] powerUpSpawns;
	[SerializeField]GameObject ranger;
	[SerializeField]GameObject soldier;
	[SerializeField]GameObject tanker;
	[SerializeField]GameObject ghoul;
	[SerializeField]Text levelText;
	[SerializeField]GameObject arrow;
	[SerializeField]GameObject healthPowerUp;
	[SerializeField]GameObject speedPowerUp;
	[SerializeField]Text endGameText;
	[SerializeField]Text startGameText;
	[SerializeField]int finalLevel = 10;

	private bool gameOver = false;
	private int currentLevel;
	private float generatedSpawnTime = 1;
	private float currentSpawnTime = 0;
	private float powerUpSpawnTime = 6f;
	private float currentPowerUpSpawnTime = 0;
	private GameObject newEnemy;
	private int maxPowerUps = 10;
	private int powerups = 0;
	private GameObject newPowerup;

	private List<EnemyHealth> enemies = new List<EnemyHealth>();
	private List<EnemyHealth> killedEnemies = new List<EnemyHealth>();

	public void RegisterEnemy (EnemyHealth enemy)
	{
		enemies.Add(enemy);
	}

	public void KilledEnemy (EnemyHealth enemy)
	{
		killedEnemies.Add(enemy);
	}

	public void RegisterPowerUp()
	{
		powerups++;
	}


	public bool GameOver {
		get { return gameOver; }
	}

	public GameObject Player {
		get { return player; }
	}

	public GameObject Arrow
	{
		get { return arrow; }
	}

	void Awake()	{

		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this) {
			Destroy(gameObject);
		}

	}


	// Use this for initialization
	void Start () {

		endGameText.GetComponent<Text>().enabled = false;
		startGameText.GetComponent<Text>().enabled = false;
		currentLevel = 1;
		StartCoroutine(spawn());
		StartCoroutine(powerUpSpawn());
		StartCoroutine(startGame("Survive " + finalLevel + " levels"));
	}
	
	// Update is called once per frame
	void Update () {

		currentSpawnTime += Time.deltaTime;
		currentPowerUpSpawnTime += Time.deltaTime;
	}

	public void PlayerHit(int currentHP) {
		if (currentHP > 0)
		{
			gameOver = false;
		}
		else {
			gameOver = true;
			StartCoroutine(endGame("Defeat"));
		}
	}

	IEnumerator spawn()
	{
		if (currentSpawnTime > generatedSpawnTime){
			currentSpawnTime = 0;

			if (enemies.Count < currentLevel) {
				int randomNumber = Random.Range(0, spawnPoints.Length - 1);
				GameObject spawnLocation = spawnPoints[randomNumber];
				int randomEnemy = Random.Range(0, 4);
				if (randomEnemy == 0) {
					newEnemy = Instantiate(soldier) as GameObject;
				} else if (randomEnemy == 1) {
					newEnemy = Instantiate(ranger) as GameObject;
				} else if (randomEnemy == 2) {
					newEnemy = Instantiate(ghoul) as GameObject;
				} else if (randomEnemy ==3)  {
					newEnemy = Instantiate(tanker) as GameObject;
				} else
				{
					Debug.Log("There are not a fifth type of enemy");
				}
				
				newEnemy.transform.position = spawnLocation.transform.position;
			}

			if (killedEnemies.Count == currentLevel && currentLevel !=finalLevel) {
				enemies.Clear();
				killedEnemies.Clear();

				yield return new WaitForSeconds(2f);
				currentLevel++;
				levelText.text = "Level " + currentLevel;
			}

			if (killedEnemies.Count == finalLevel)
			{
				StartCoroutine(endGame("Victory!"));
			}
		}

		yield return null;
		StartCoroutine(spawn());
		
	}


	IEnumerator powerUpSpawn()
	{
		if (currentPowerUpSpawnTime > powerUpSpawnTime)
		{
			currentPowerUpSpawnTime = 0;
			if (powerups < maxPowerUps)
			{
				int randomNumber = Random.Range(0, powerUpSpawns.Length - 1);
				GameObject spawnLocation = powerUpSpawns[randomNumber];
				int randomPowerUp = Random.Range(0, 2);

				if(randomPowerUp == 0)
				{
					newPowerup = Instantiate(healthPowerUp) as GameObject;
				} else if (randomPowerUp == 1)
				{
					newPowerup = Instantiate(speedPowerUp) as GameObject;
				}

				newPowerup.transform.position = spawnLocation.transform.position;
			}
		}

		yield return null;
		StartCoroutine(powerUpSpawn());
	}

	IEnumerator startGame(string info)
	{
		startGameText.text = info;
		startGameText.GetComponent<Text>().enabled = true;
		yield return new WaitForSeconds(2f);
		startGameText.GetComponent<Text>().enabled = false;

	}

	IEnumerator endGame(string outCome)
	{
		endGameText.text = outCome;
		endGameText.GetComponent<Text>().enabled = true;
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene("GameMenu");
	}

	public void GoToGameMenu()
	{
		SceneManager.LoadScene("GameMenu");
		Debug.Log("do i get here?");
	}

}
