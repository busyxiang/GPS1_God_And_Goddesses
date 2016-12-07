using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SpawnEnemy1 : MonoBehaviour
{
	//waypoints
	public GameObject[] wayPoints1;
	public GameObject[] wayPoints2;
	public GameObject[] wayPoints3;

	//waves
	public List<GameObject> waves;
	[HideInInspector]public int currentWave = 0;
	[HideInInspector]public int totalWave;

	//object pool variable
	//enemy1
	public GameObject enemy1;
	public int minEnemy1 = 10;
	public int maxEnemy1 = 10;
	//enemy2
	public GameObject enemy2;
	public int minEnemy2 = 10;
	public int maxEnemy2 = 10;
	//enemy3
	public GameObject enemy3;
	public int minEnemy3 = 10;
	public int maxEnemy3 = 10;
	//enemy4
	public GameObject enemy4;
	public int minEnemy4 = 10;
	public int maxEnemy4 = 10;

	int activeEnemy;

	public int currentTotalEnemy;
	public int currentRemainingEnemy;

	public GameObject Choose;
	TutorialManager tutorialManager;

	void Start ()
	{
		totalWave = waves.Count;
		CreateEnemyPool();

		if(SceneManager.GetActiveScene().name == "TutorialLevel")
		{
			tutorialManager = GameObject.Find("TutorialManager").GetComponent<TutorialManager>();
		}
	}

	void Update()
	{
		activeEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;

		if((currentWave >= totalWave) && currentRemainingEnemy == 0 )
		{
			Choose.SetActive(true);
			Time.timeScale = 0.0f;
		}
	}

	private void CreateEnemyPool()
	{
		ObjectPoolManagerScript.Instance.CreatePool(this.enemy1,minEnemy1,maxEnemy1);
		ObjectPoolManagerScript.Instance.CreatePool(this.enemy2,minEnemy2,maxEnemy2);
		ObjectPoolManagerScript.Instance.CreatePool(this.enemy3,minEnemy3,maxEnemy3);
		ObjectPoolManagerScript.Instance.CreatePool(this.enemy4,minEnemy4,maxEnemy4);
	}
		
	//wayPoint1
	void Enemy1_1()
	{
		this.enemy1 = ObjectPoolManagerScript.Instance.GetObject("Enemy1");
		this.enemy1.transform.position = new Vector3(wayPoints1[0].transform.position.x,wayPoints1[0].transform.position.y,wayPoints1[0].transform.position.z);
		this.enemy1.SetActive(true);
		this.enemy1.GetComponent<EnemyHealth>().currentHealth = this.enemy1.GetComponent<EnemyHealth>().maxHealth;
		this.enemy1.GetComponent<EnemyMovement>().currentWayPoint = 0;
		this.enemy1.GetComponent<EnemyMovement>().targetPosition = wayPoints1[1].transform.position;
		this.enemy1.GetComponent<EnemyMovement>().moveDirection = (this.enemy1.GetComponent<EnemyMovement>().targetPosition - this.enemy1.transform.position).normalized;
		this.enemy1.GetComponent<EnemyMovement>().wayPoints = wayPoints1;
	}
	void Enemy2_1()
	{
		this.enemy2 = ObjectPoolManagerScript.Instance.GetObject("Enemy2");
		this.enemy2.transform.position = new Vector3(wayPoints1[0].transform.position.x,wayPoints1[0].transform.position.y,wayPoints1[0].transform.position.z);
		this.enemy2.SetActive(true);
		this.enemy2.GetComponent<EnemyHealth>().currentHealth = this.enemy2.GetComponent<EnemyHealth>().maxHealth;
		this.enemy2.GetComponent<EnemyMovement>().currentWayPoint = 0;
		this.enemy2.GetComponent<EnemyMovement>().targetPosition = wayPoints1[1].transform.position;
		this.enemy2.GetComponent<EnemyMovement>().moveDirection = (this.enemy2.GetComponent<EnemyMovement>().targetPosition - this.enemy2.transform.position).normalized;
		this.enemy2.GetComponent<EnemyMovement>().wayPoints = wayPoints1;
	}
	void Enemy3_1()
	{
		this.enemy3 = ObjectPoolManagerScript.Instance.GetObject("Enemy3");
		this.enemy3.transform.position = new Vector3(wayPoints1[0].transform.position.x,wayPoints1[0].transform.position.y,wayPoints1[0].transform.position.z);
		this.enemy3.SetActive(true);
		this.enemy3.GetComponent<EnemyHealth>().currentHealth = this.enemy3.GetComponent<EnemyHealth>().maxHealth;
		this.enemy3.GetComponent<EnemyMovement>().currentWayPoint = 0;
		this.enemy3.GetComponent<EnemyMovement>().targetPosition = wayPoints1[1].transform.position;
		this.enemy3.GetComponent<EnemyMovement>().moveDirection = (this.enemy3.GetComponent<EnemyMovement>().targetPosition - this.enemy3.transform.position).normalized;
		this.enemy3.GetComponent<EnemyMovement>().wayPoints = wayPoints1;
	}
	void Enemy4_1()
	{
		this.enemy4 = ObjectPoolManagerScript.Instance.GetObject("Enemy4");
		this.enemy4.transform.position = new Vector3(wayPoints1[0].transform.position.x,wayPoints1[0].transform.position.y,wayPoints1[0].transform.position.z);
		this.enemy4.SetActive(true);
		this.enemy4.GetComponent<EnemyHealth>().currentHealth = this.enemy4.GetComponent<EnemyHealth>().maxHealth;
		this.enemy4.GetComponent<EnemyMovement>().currentWayPoint = 0;
		this.enemy4.GetComponent<EnemyMovement>().targetPosition = wayPoints1[1].transform.position;
		this.enemy4.GetComponent<EnemyMovement>().moveDirection = (this.enemy4.GetComponent<EnemyMovement>().targetPosition - this.enemy4.transform.position).normalized;
		this.enemy4.GetComponent<EnemyMovement>().wayPoints = wayPoints1;
	}

	//wayPoint2
	void Enemy1_2()
	{
		this.enemy1 = ObjectPoolManagerScript.Instance.GetObject("Enemy1");
		this.enemy1.transform.position = new Vector3(wayPoints2[0].transform.position.x,wayPoints2[0].transform.position.y,wayPoints2[0].transform.position.z);
		this.enemy1.SetActive(true);
		this.enemy1.GetComponent<EnemyHealth>().currentHealth = this.enemy1.GetComponent<EnemyHealth>().maxHealth;
		this.enemy1.GetComponent<EnemyMovement>().currentWayPoint = 0;
		this.enemy1.GetComponent<EnemyMovement>().targetPosition = wayPoints2[1].transform.position;
		this.enemy1.GetComponent<EnemyMovement>().moveDirection = (this.enemy1.GetComponent<EnemyMovement>().targetPosition - this.enemy1.transform.position).normalized;
		this.enemy1.GetComponent<EnemyMovement>().wayPoints = wayPoints2;
	}
	void Enemy2_2()
	{
		this.enemy2 = ObjectPoolManagerScript.Instance.GetObject("Enemy2");
		this.enemy2.transform.position = new Vector3(wayPoints2[0].transform.position.x,wayPoints2[0].transform.position.y,wayPoints2[0].transform.position.z);
		this.enemy2.SetActive(true);
		this.enemy2.GetComponent<EnemyHealth>().currentHealth = this.enemy2.GetComponent<EnemyHealth>().maxHealth;
		this.enemy2.GetComponent<EnemyMovement>().currentWayPoint = 0;
		this.enemy2.GetComponent<EnemyMovement>().targetPosition = wayPoints2[1].transform.position;
		this.enemy2.GetComponent<EnemyMovement>().moveDirection = (this.enemy2.GetComponent<EnemyMovement>().targetPosition - this.enemy2.transform.position).normalized;
		this.enemy2.GetComponent<EnemyMovement>().wayPoints = wayPoints2;
	}
	void Enemy3_2()
	{
		this.enemy3 = ObjectPoolManagerScript.Instance.GetObject("Enemy3");
		this.enemy3.transform.position = new Vector3(wayPoints2[0].transform.position.x,wayPoints2[0].transform.position.y,wayPoints2[0].transform.position.z);
		this.enemy3.SetActive(true);
		this.enemy3.GetComponent<EnemyHealth>().currentHealth = this.enemy3.GetComponent<EnemyHealth>().maxHealth;
		this.enemy3.GetComponent<EnemyMovement>().currentWayPoint = 0;
		this.enemy3.GetComponent<EnemyMovement>().targetPosition = wayPoints2[1].transform.position;
		this.enemy3.GetComponent<EnemyMovement>().moveDirection = (this.enemy3.GetComponent<EnemyMovement>().targetPosition - this.enemy3.transform.position).normalized;
		this.enemy3.GetComponent<EnemyMovement>().wayPoints = wayPoints2;
	}
	void Enemy4_2()
	{
		this.enemy4 = ObjectPoolManagerScript.Instance.GetObject("Enemy4");
		this.enemy4.transform.position = new Vector3(wayPoints2[0].transform.position.x,wayPoints2[0].transform.position.y,wayPoints2[0].transform.position.z);
		this.enemy4.SetActive(true);
		this.enemy4.GetComponent<EnemyHealth>().currentHealth = this.enemy4.GetComponent<EnemyHealth>().maxHealth;
		this.enemy4.GetComponent<EnemyMovement>().currentWayPoint = 0;
		this.enemy4.GetComponent<EnemyMovement>().targetPosition = wayPoints2[1].transform.position;
		this.enemy4.GetComponent<EnemyMovement>().moveDirection = (this.enemy4.GetComponent<EnemyMovement>().targetPosition - this.enemy4.transform.position).normalized;
		this.enemy4.GetComponent<EnemyMovement>().wayPoints = wayPoints2;
	}

	//wayPoint3
	void Enemy1_3()
	{
		this.enemy1 = ObjectPoolManagerScript.Instance.GetObject("Enemy1");
		this.enemy1.transform.position = new Vector3(wayPoints3[0].transform.position.x,wayPoints3[0].transform.position.y,wayPoints3[0].transform.position.z);
		this.enemy1.SetActive(true);
		this.enemy1.GetComponent<EnemyHealth>().currentHealth = this.enemy1.GetComponent<EnemyHealth>().maxHealth;
		this.enemy1.GetComponent<EnemyMovement> ().currentWayPoint = 0;
		this.enemy1.GetComponent<EnemyMovement>().targetPosition = wayPoints3[1].transform.position;
		this.enemy1.GetComponent<EnemyMovement>().moveDirection = (this.enemy1.GetComponent<EnemyMovement>().targetPosition - this.enemy1.transform.position).normalized;
		this.enemy1.GetComponent<EnemyMovement> ().wayPoints = wayPoints3;
	}
	void Enemy2_3()
	{
		this.enemy2 = ObjectPoolManagerScript.Instance.GetObject("Enemy2");
		this.enemy2.transform.position = new Vector3(wayPoints3[0].transform.position.x,wayPoints3[0].transform.position.y,wayPoints3[0].transform.position.z);
		this.enemy2.SetActive(true);
		this.enemy2.GetComponent<EnemyHealth>().currentHealth = this.enemy2.GetComponent<EnemyHealth>().maxHealth;
		this.enemy2.GetComponent<EnemyMovement>().currentWayPoint = 0;
		this.enemy2.GetComponent<EnemyMovement>().targetPosition = wayPoints3[1].transform.position;
		this.enemy2.GetComponent<EnemyMovement>().moveDirection = (this.enemy2.GetComponent<EnemyMovement>().targetPosition - this.enemy2.transform.position).normalized;
		this.enemy2.GetComponent<EnemyMovement>().wayPoints = wayPoints3;
	}
	void Enemy3_3()
	{
		this.enemy3 = ObjectPoolManagerScript.Instance.GetObject("Enemy3");
		this.enemy3.transform.position = new Vector3(wayPoints3[0].transform.position.x,wayPoints3[0].transform.position.y,wayPoints3[0].transform.position.z);
		this.enemy3.SetActive(true);
		this.enemy3.GetComponent<EnemyHealth>().currentHealth = this.enemy3.GetComponent<EnemyHealth>().maxHealth;
		this.enemy3.GetComponent<EnemyMovement> ().currentWayPoint = 0;
		this.enemy3.GetComponent<EnemyMovement>().targetPosition = wayPoints3[1].transform.position;
		this.enemy3.GetComponent<EnemyMovement>().moveDirection = (this.enemy3.GetComponent<EnemyMovement>().targetPosition - this.enemy3.transform.position).normalized;
		this.enemy3.GetComponent<EnemyMovement> ().wayPoints = wayPoints3;
	}
	void Enemy4_3()
	{
		this.enemy4 = ObjectPoolManagerScript.Instance.GetObject("Enemy4");
		this.enemy4.transform.position = new Vector3(wayPoints3[0].transform.position.x,wayPoints3[0].transform.position.y,wayPoints3[0].transform.position.z);
		this.enemy4.SetActive(true);
		this.enemy4.GetComponent<EnemyHealth>().currentHealth = this.enemy4.GetComponent<EnemyHealth>().maxHealth;
		this.enemy4.GetComponent<EnemyMovement> ().currentWayPoint = 0;
		this.enemy4.GetComponent<EnemyMovement>().targetPosition = wayPoints3[1].transform.position;
		this.enemy4.GetComponent<EnemyMovement>().moveDirection = (this.enemy4.GetComponent<EnemyMovement>().targetPosition - this.enemy4.transform.position).normalized;
		this.enemy4.GetComponent<EnemyMovement> ().wayPoints = wayPoints3;
	}

	public void SpawnWave ()
	{
		for(int i=0; i<totalWave;i++)
		{
			activeEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;

			if(currentRemainingEnemy == 0)
			{
				if(currentWave == i)
				{
					currentTotalEnemy = 0;
					for(int j = 0; j < waves[i].GetComponent<EnemyWaves> ().enemyList.Count; j++)
					{
						Invoke(waves[i].GetComponent<EnemyWaves> ().enemyList[j].enemy ,waves[i].GetComponent<EnemyWaves> ().enemyList[j].time);
						currentTotalEnemy++;
					}
					currentRemainingEnemy = currentTotalEnemy;
					currentWave++;
					GUIManagerScript.Instance.progressIndicatorImage.gameObject.SetActive(true);
					GUIManagerScript.Instance.UpdateProgressIndicator(1);
					break;

				}
				/*else if(currentWave >= totalWave)
				{
					Debug.Log("All Waves Spawned");
					Invoke("WinningCondition",2f);
					Choose.SetActive(true);
					break;
				}*/
			}
		}

		if(tutorialManager != null)
		{
			tutorialManager.startGame.SetActive(false);
		}

		if(GUIManagerScript.Instance.selectedGO != null)
		{
			GUIManagerScript.Instance.UnselectEverything();
		}
	}
}
