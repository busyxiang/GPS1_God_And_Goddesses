﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIManagerScript : MonoBehaviour 
{
	private static GUIManagerScript mInstance;

	public static GUIManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("GUIManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_GUIManager");
					mInstance = obj.AddComponent<GUIManagerScript>();
					obj.tag = "GUIManager";
				}
				else
				{
					mInstance = tempObject.GetComponent<GUIManagerScript >();
				}
			}
			return mInstance;
		}
	}

	public List<GameObject> tileList;
	public GameObject selectedGO;
	GameManagerBehaviour gameManager;
	TileManagerScript tileManager;
	SpawnEnemy1 enemySpawner;
	public int sellTowerValue;
	public GameObject textInfo;
	public GameObject healthInfo;
	public Text waveCount;
	public GameObject upgradeTowerButton;
	public GameObject sellTowerButton;
	public GameObject upgradePlatformButton;
	public Image progressBar;
	public GameObject coreInfo;
	public Image coreHealthBar;
	CoreHealth coreHealth;
	public GameObject rangeDetection;
	public Text coreHealthText;
	TutorialManager tutorialManager;
	public GameObject BattleBegin ;
	public GameObject PrepareForBattle;

	//!timer 
	public float timer=2.0f;
	public float Delaytimer ;

	int totalEnemy;
	GameObject[] enemy;

	public int PlatformCost;

	private bool canUpgradeTower()
	{
		if (selectedGO != null) 
		{
			TowerData towerData = selectedGO.GetComponent<TowerData> ();
			TowerLevel nextLevel = towerData.GetNextLevel();

			if (nextLevel != null)
			{
				return gameManager.Gold >= nextLevel.cost;
			}
		}
		return false;
	}

	// Use this for initialization
	void Start ()
	{
		tileList = TileManagerScript.Instance.goTileList;
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
		enemySpawner = GameObject.Find("Lv1Spawner").GetComponent<SpawnEnemy1>();
		tileManager = GameObject.Find("TileManagerPrefab").GetComponent<TileManagerScript>();
		coreHealth = GameObject.Find("Core").GetComponent<CoreHealth>();


		if(SceneManager.GetActiveScene().name == "TutorialLevel")
		{
			tutorialManager = GameObject.Find("TutorialManager").GetComponent<TutorialManager>();
		}
	}

	// Update is called once per frame
	void Update () 
	{
		totalEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
		waveCount.text = "Wave: " + enemySpawner.currentWave + "/" + enemySpawner.totalWave;
		progressBar.fillAmount = 1 - (enemySpawner.currentRemainingEnemy*1f/enemySpawner.currentTotalEnemy*1f);
		coreHealthBar.fillAmount = coreHealth.healthMin * 1.0f / coreHealth.healthMax;
		coreHealthText.text = coreHealth.healthMin + " / " + coreHealth.healthMax;

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			GUIManagerScript.Instance.selectedGO = null;
			GUIManagerScript.Instance.UnselectPlatform();
			GUIManagerScript.Instance.UpdateSelectedInfo();
		}

		if(BattleBegin.activeSelf == true)
		{

			Delaytimer += Time.deltaTime ; 
			if(Delaytimer >= timer)
			{
				BattleBegin.SetActive(false);
				Delaytimer = 0 ;
			}
		}
	}

	public void UpdateSelectedInfo()
	{
		if(selectedGO != null)
		{
			if(selectedGO.CompareTag("Tower"))
			{
				UnselectPlatform();
				HideCoreInfo();
				HidePlatformInfo();
				ShowTowerInfo();
				upgradeTowerButton.transform.position = new Vector3(selectedGO.transform.position.x - 0.3f, selectedGO.transform.position.y - 0.3f, selectedGO.transform.position.z);
				sellTowerButton.transform.position = new Vector3(selectedGO.transform.position.x + 0.3f, selectedGO.transform.position.y - 0.3f, selectedGO.transform.position.z);

				float range = selectedGO.GetComponent<TowerData>().range;
				rangeDetection.SetActive(true);
				rangeDetection.transform.position = selectedGO.transform.position;
				rangeDetection.transform.localScale = new Vector3(range, range, 0);
			}
			else if(selectedGO.CompareTag("Tile"))
			{
				HideCoreInfo();
				HideTowerInfo();
				ShowPlatformInfo();
				SwitchHighLightPlatform();
				HighLightPlatform();
				rangeDetection.SetActive(false);
			}
			else if(selectedGO.CompareTag("Core"))
			{
				UnselectPlatform();
				HideTowerInfo();
				HidePlatformInfo();
				ShowCoreInfo();
				rangeDetection.SetActive(false);
			}
		}
		else
		{
			HideCoreInfo();
			HideTowerInfo();
			HidePlatformInfo();
			rangeDetection.SetActive(false);
		}



		if(PrepareForBattle.activeSelf == true)
		{
			Delaytimer +=Time.deltaTime;
			if(Delaytimer >= timer)
			{
				PrepareForBattle.SetActive(false);
				Delaytimer = 0 ;
			}
		}
	}

	public void UnselectEverything()
	{
		HideCoreInfo();
		HideTowerInfo();
		HidePlatformInfo();
		UnselectPlatform();
	}

	public void BuildArtemisTower()
	{
		for(int i=0; i<tileList.Count; i++)
		{
			tileList[i].GetComponent<PlaceTower>().enabled = true;
			tileList[i].GetComponent<PlaceTower>().towerPrefab = tileList[i].GetComponent<PlaceTower>().towerPrefabs[0];

			if(selectedGO != null && selectedGO.CompareTag("Tower"))
			{
				selectedGO.GetComponent<ClickAndMove>().Deactivate();
			}
		}

		if(tutorialManager != null)
		{
			tutorialManager.summonThis.SetActive(false);
		}

		selectedGO = null;
		UpdateSelectedInfo();
		UnselectEverything();
	}

	public void BuildZuesTower()
	{
		for(int i=0; i<tileList.Count; i++)
		{
			tileList[i].GetComponent<PlaceTower>().enabled = true;
			tileList[i].GetComponent<PlaceTower>().towerPrefab = tileList[i].GetComponent<PlaceTower>().towerPrefabs[1];

			if(selectedGO != null && selectedGO.CompareTag("Tower"))
			{
				selectedGO.GetComponent<ClickAndMove>().Deactivate();
			}
		}

		if(tutorialManager != null)
		{
			tutorialManager.summonThis.SetActive(false);
		}

		selectedGO = null;
		UpdateSelectedInfo();
		UnselectEverything();
	}

	public void BuildChioneTower()
	{
		for(int i=0; i<tileList.Count; i++)
		{
			tileList[i].GetComponent<PlaceTower>().enabled = true;
			tileList[i].GetComponent<PlaceTower>().towerPrefab = tileList[i].GetComponent<PlaceTower>().towerPrefabs[2];

			if(selectedGO != null && selectedGO.CompareTag("Tower"))
			{
				selectedGO.GetComponent<ClickAndMove>().Deactivate();
			}
		}

		if(tutorialManager != null)
		{
			tutorialManager.summonThis.SetActive(false);
		}

		selectedGO = null;
		UpdateSelectedInfo();
		UnselectEverything();
	}

	public void BuildHeliosTower()
	{
		for(int i=0; i<tileList.Count; i++)
		{
			tileList[i].GetComponent<PlaceTower>().enabled = true;
			tileList[i].GetComponent<PlaceTower>().towerPrefab = tileList[i].GetComponent<PlaceTower>().towerPrefabs[3];

			if(selectedGO != null && selectedGO.CompareTag("Tower"))
			{
				selectedGO.GetComponent<ClickAndMove>().Deactivate();
			}
		}

		if(tutorialManager != null)
		{
			tutorialManager.summonThis.SetActive(false);
		}

		selectedGO = null;
		UpdateSelectedInfo();
		UnselectEverything();
	}

	public void BuildPlutosTower()
	{
		for(int i=0; i<tileList.Count; i++)
		{
			tileList[i].GetComponent<PlaceTower>().enabled = true;
			tileList[i].GetComponent<PlaceTower>().towerPrefab = tileList[i].GetComponent<PlaceTower>().towerPrefabs[4];

			if(selectedGO != null && selectedGO.CompareTag("Tower"))
			{
				selectedGO.GetComponent<ClickAndMove>().Deactivate();
			}
		}

		if(tutorialManager != null)
		{
			tutorialManager.summonThis.SetActive(false);
		}

		selectedGO = null;
		UpdateSelectedInfo();
		UnselectEverything();
	}

	public void TowerLevelUp()
	{
		if(canUpgradeTower())
		{
			selectedGO.GetComponent<TowerData> ().IncreaseLevel ();
			gameManager.Gold -= selectedGO.GetComponent<TowerData>().CurrentLevel.cost;
			selectedGO.GetComponent<ClickAndMove>().spriteRenderer = selectedGO.GetComponentInChildren<SpriteRenderer>();

			TowerInfoList();
		}
	}

	public void SellTower()
	{
		if(selectedGO != null)
		{
			selectedGO.GetComponent<ClickAndMove>().currentTile.GetComponent<PlaceTower>().tower = null;
			Destroy(selectedGO);
			gameManager.Gold += sellTowerValue;
		}
	}

	public void ShowTowerInfo()
	{
		upgradeTowerButton.SetActive(true);
		sellTowerButton.SetActive(true);
		textInfo.SetActive(true);

		TowerInfoList();
	}

	public void HideTowerInfo()
	{
		upgradeTowerButton.SetActive(false);
		sellTowerButton.SetActive(false);
		textInfo.SetActive(false);
	}

	public void OnClickRestart()
	{
		totalEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
		enemy = GameObject.FindGameObjectsWithTag("Enemy");

		for(int i=0; i<totalEnemy; i++)
		{
			enemy[i].GetComponent<EnemyMovement>().Invoke("Destroy",0f);
		}

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void TowerInfoList()
	{
		string towerName = selectedGO.gameObject.name;
		TowerData towerData = selectedGO.GetComponent<TowerData> ();
		TowerLevel nextLevel = towerData.GetNextLevel();

		switch(towerName)
		{
		case "ArtemisTower(Clone)":
			textInfo.GetComponent<Text>().text = selectedGO.gameObject.GetComponent<TowerData>().CurrentLevel.visualization.gameObject.name
				+ "\nDamage: " + selectedGO.GetComponent<TowerData>().damageDeal + "\nAttack Speed: " + selectedGO.GetComponent<TowerData>().attackSpeed*100
				+ "\nSPD Reduce: " + selectedGO.GetComponent<TowerData>().slowSpeed + "\nBurn: " + selectedGO.GetComponent<TowerData>().burnDamage
				+ "\nUpgrade Cost: " + nextLevel.cost;
			break;

		case "ZuesTower(Clone)":
			textInfo.GetComponent<Text>().text = selectedGO.gameObject.GetComponent<TowerData>().CurrentLevel.visualization.gameObject.name
				+ "\nDamage: " + selectedGO.GetComponent<TowerData>().damageDeal + "\nAttack Speed: " + selectedGO.GetComponent<TowerData>().attackSpeed*100
				+ "\nSPD Reduce: " + selectedGO.GetComponent<TowerData>().slowSpeed + "\nBurn: " + selectedGO.GetComponent<TowerData>().burnDamage
				+ "\nUpgrade Cost: " + nextLevel.cost;
			break;

		case "ChioneTower(Clone)":
			textInfo.GetComponent<Text>().text = selectedGO.gameObject.GetComponent<TowerData>().CurrentLevel.visualization.gameObject.name
				+ "\nDamage: " + selectedGO.GetComponent<TowerData>().damageDeal + "\nAttack Speed: " + selectedGO.GetComponent<TowerData>().attackSpeed*100
				+ "\nSPD Reduce: " + selectedGO.GetComponent<TowerData>().slowSpeed*100 + "%\nBurn: " + selectedGO.GetComponent<TowerData>().burnDamage
				+ "\nUpgrade Cost: " + nextLevel.cost;
			break;

		case "HeliosTower(Clone)":
			textInfo.GetComponent<Text>().text = selectedGO.gameObject.GetComponent<TowerData>().CurrentLevel.visualization.gameObject.name
				+ "\nDamage: " + selectedGO.GetComponent<TowerData>().damageDeal + "\nAttack Speed: " + selectedGO.GetComponent<TowerData>().attackSpeed*100
				+ "\nSPD Reduce: " + selectedGO.GetComponent<TowerData>().slowSpeed + "\nBurn: " + selectedGO.GetComponent<TowerData>().burnDamage + "/Second"
				+ "\nUpgrade Cost: " + nextLevel.cost;
			break;

		case "PlutusTower(Clone)":
			textInfo.GetComponent<Text>().text = selectedGO.gameObject.GetComponent<TowerData>().CurrentLevel.visualization.gameObject.name
				+ "\nCoin Rate: " + selectedGO.gameObject.GetComponent<TowerData>().coinRate;
			break;
		}
	}

	public void UpgradePlatform()
	{
		if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM01)
		{
			if(gameManager.Gold - PlatformCost >= 0 && tileManager.towerPlatform1 + 1 <= tileManager.maxTower)
			{
				tileManager.towerPlatform1 += 1;
				gameManager.Gold -= PlatformCost;
			}
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM02)
		{
			if(gameManager.Gold - PlatformCost >= 0 && tileManager.towerPlatform2 + 1 <= tileManager.maxTower)
			{
				tileManager.towerPlatform2 += 1;
				gameManager.Gold -= PlatformCost;
			}
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM03)
		{
			if(gameManager.Gold - PlatformCost >= 0 && tileManager.towerPlatform3 + 1 <= tileManager.maxTower)
			{
				tileManager.towerPlatform3 += 1;
				gameManager.Gold -= PlatformCost;
			}
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM04)
		{
			if(gameManager.Gold - PlatformCost >= 0 && tileManager.towerPlatform4 + 1 <= tileManager.maxTower)
			{
				tileManager.towerPlatform4 += 1;
				gameManager.Gold -= PlatformCost;
			}
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM05)
		{
			if(gameManager.Gold - PlatformCost >= 0 && tileManager.towerPlatform5 + 1 <= tileManager.maxTower)
			{
				tileManager.towerPlatform5 += 1;
				gameManager.Gold -= PlatformCost;
			}
		}
	}

	public void ShowPlatformInfo()
	{
		textInfo.SetActive(true);
		upgradePlatformButton.SetActive(true);

		if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM01)
		{
			textInfo.GetComponent<Text>().text = "Platform 1" + "\nMax Tower: " + tileManager.towerPlatform1 + "\nUpgrade Cost: " + PlatformCost;
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM02)
		{
			textInfo.GetComponent<Text>().text = "Platform 2" + "\nMax Tower: " + tileManager.towerPlatform2 + "\nUpgrade Cost: " + PlatformCost;
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM03)
		{
			textInfo.GetComponent<Text>().text = "Platform 3" + "\nMax Tower: " + tileManager.towerPlatform3 + "\nUpgrade Cost: " + PlatformCost;
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM04)
		{
			textInfo.GetComponent<Text>().text = "Platform 4" + "\nMax Tower: " + tileManager.towerPlatform4 + "\nUpgrade Cost: " + PlatformCost;
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM05)
		{
			textInfo.GetComponent<Text>().text = "Platform 5" + "\nMax Tower: " + tileManager.towerPlatform5 + "\nUpgrade Cost: " + PlatformCost;
		}
	}

	public void HidePlatformInfo()
	{
		textInfo.SetActive(false);
		upgradePlatformButton.SetActive(false);
	}

	public void ShowCoreInfo()
	{
		coreInfo.SetActive(true);
	}

	public void HideCoreInfo()
	{
		coreInfo.SetActive(false);
	}

	public void HighLightPlatform()
	{
		if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM01)
		{
			TileManagerScript.Instance.SelectPlatform01();
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM02)
		{
			TileManagerScript.Instance.SelectPlatform02();
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM03)
		{
			TileManagerScript.Instance.SelectPlatform03();
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM04)
		{
			TileManagerScript.Instance.SelectPlatform04();
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM05)
		{
			TileManagerScript.Instance.SelectPlatform05();
		}
	}

	public void SwitchHighLightPlatform()
	{
		if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM01)
		{
			TileManagerScript.Instance.UnSelectPlatform02();
			TileManagerScript.Instance.UnSelectPlatform03();
			TileManagerScript.Instance.UnSelectPlatform04();
			TileManagerScript.Instance.UnSelectPlatform05();
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM02)
		{
			TileManagerScript.Instance.UnSelectPlatform01();
			TileManagerScript.Instance.UnSelectPlatform03();
			TileManagerScript.Instance.UnSelectPlatform04();
			TileManagerScript.Instance.UnSelectPlatform05();
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM03)
		{
			TileManagerScript.Instance.UnSelectPlatform01();
			TileManagerScript.Instance.UnSelectPlatform02();
			TileManagerScript.Instance.UnSelectPlatform04();
			TileManagerScript.Instance.UnSelectPlatform05();
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM04)
		{
			TileManagerScript.Instance.UnSelectPlatform01();
			TileManagerScript.Instance.UnSelectPlatform02();
			TileManagerScript.Instance.UnSelectPlatform03();
			TileManagerScript.Instance.UnSelectPlatform05();
		}
		else if(selectedGO.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM05)
		{
			TileManagerScript.Instance.UnSelectPlatform01();
			TileManagerScript.Instance.UnSelectPlatform02();
			TileManagerScript.Instance.UnSelectPlatform03();
			TileManagerScript.Instance.UnSelectPlatform04();
		}
	}

	public void UnselectPlatform()
	{
		TileManagerScript.Instance.UnSelectPlatform01();
		TileManagerScript.Instance.UnSelectPlatform02();
		TileManagerScript.Instance.UnSelectPlatform03();
		TileManagerScript.Instance.UnSelectPlatform04();
		TileManagerScript.Instance.UnSelectPlatform05();
	}
}
