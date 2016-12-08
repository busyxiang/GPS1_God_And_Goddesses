using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlaceTower : MonoBehaviour 
{
	[HideInInspector]public GameObject tower;
	public GameObject[] towerPrefabs;
	[HideInInspector]public GameObject towerPrefab;

	GameManagerBehaviour gameManager;
	[HideInInspector]public bool returnNormal = true;
	TutorialManager tutorialManager;

	void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();

		if(SceneManager.GetActiveScene().name == "TutorialLevel")
		{
			tutorialManager = GameObject.Find("TutorialManager").GetComponent<TutorialManager>();
		}
	}

	void Update()
	{
		if(gameManager.Gold <=0)
		{
			this.gameObject.GetComponent<PlaceTower>().enabled = false;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			TileManagerScript.Instance.DeactiavtePlaceTower();
		}
	}

	private bool canPlaceTower()
	{
		int cost = towerPrefab.GetComponent<TowerData>().levels[0].cost;
		return tower == null && gameManager.Gold >= cost;
	}

	private bool IsPlatform()
	{
		if(gameObject.GetComponent<TileScript>().type == TileScript.Type.PLATFORM)
		{
			return true;
		}
		return false;
	}
		
	void OnMouseUp()
	{
		if (!enabled)
			return;
		if (canPlaceTower ()) 
		{
			if(IsPlatform())
			{
				if(this.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM01)
				{
					if(TileManagerScript.Instance.platform01Checking())
					{
						tower = (GameObject)Instantiate (towerPrefab, transform.position, Quaternion.identity);
						gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
						tower.GetComponent<TowerData>().platform = Platform.PLATFORM_01;
						tower.GetComponent<ClickAndMove>().rowIndex = GetComponent<TileScript>().rowIndex;
						tower.GetComponent<ClickAndMove>().colIndex = GetComponent<TileScript>().colIndex;
						tower.GetComponent<ClickAndMove>().currentTile = this.gameObject;
						GUIManagerScript.Instance.selectedGO = tower;
						GUIManagerScript.Instance.UpdateSelectedInfo();
						tower.GetComponent<ClickAndMove>().Activate();
					}
				}
				else if(this.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM02)
				{
					if(TileManagerScript.Instance.platform02Checking())
					{
						tower = (GameObject)Instantiate (towerPrefab, transform.position, Quaternion.identity);
						gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
						tower.GetComponent<TowerData>().platform = Platform.PLATFORM_02;
						tower.GetComponent<ClickAndMove>().rowIndex = GetComponent<TileScript>().rowIndex;
						tower.GetComponent<ClickAndMove>().colIndex = GetComponent<TileScript>().colIndex;
						tower.GetComponent<ClickAndMove>().currentTile = this.gameObject;
						GUIManagerScript.Instance.selectedGO = tower;
						GUIManagerScript.Instance.UpdateSelectedInfo();
						tower.GetComponent<ClickAndMove>().Activate();
					}
				}
				else if(this.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM03)
				{
					if(TileManagerScript.Instance.platform03Checking())
					{
						tower = (GameObject)Instantiate (towerPrefab, transform.position, Quaternion.identity);
						gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
						tower.GetComponent<TowerData>().platform = Platform.PLATFORM_03;
						tower.GetComponent<ClickAndMove>().rowIndex = GetComponent<TileScript>().rowIndex;
						tower.GetComponent<ClickAndMove>().colIndex = GetComponent<TileScript>().colIndex;
						tower.GetComponent<ClickAndMove>().currentTile = this.gameObject;
						GUIManagerScript.Instance.selectedGO = tower;
						GUIManagerScript.Instance.UpdateSelectedInfo();
						tower.GetComponent<ClickAndMove>().Activate();
					}
				}
				else if(this.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM04)
				{
					if(TileManagerScript.Instance.platform04Checking())
					{
						tower = (GameObject)Instantiate (towerPrefab, transform.position, Quaternion.identity);
						gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
						tower.GetComponent<TowerData>().platform = Platform.PLATFORM_04;
						tower.GetComponent<ClickAndMove>().rowIndex = GetComponent<TileScript>().rowIndex;
						tower.GetComponent<ClickAndMove>().colIndex = GetComponent<TileScript>().colIndex;
						tower.GetComponent<ClickAndMove>().currentTile = this.gameObject;
						GUIManagerScript.Instance.selectedGO = tower;
						GUIManagerScript.Instance.UpdateSelectedInfo();
						tower.GetComponent<ClickAndMove>().Activate();
					}
				}
				else if(this.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM05)
				{
					if(TileManagerScript.Instance.platform05Checking())
					{
						tower = (GameObject)Instantiate (towerPrefab, transform.position, Quaternion.identity);
						gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
						tower.GetComponent<TowerData>().platform = Platform.PLATFORM_05;
						tower.GetComponent<ClickAndMove>().rowIndex = GetComponent<TileScript>().rowIndex;
						tower.GetComponent<ClickAndMove>().colIndex = GetComponent<TileScript>().colIndex;
						tower.GetComponent<ClickAndMove>().currentTile = this.gameObject;
						GUIManagerScript.Instance.selectedGO = tower;
						GUIManagerScript.Instance.UpdateSelectedInfo();
						tower.GetComponent<ClickAndMove>().Activate();
					}
				}

				if(tutorialManager != null && tutorialManager.placedTower == false)
				{
					tutorialManager.placeHere.SetActive(false);
					tutorialManager.placedTower = true;
					tutorialManager.OpenUpHint(1);
				}

				SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
				TileManagerScript.Instance.DeactiavtePlaceTower();
			}
		}
	}

	void OnMouseOver()
	{
		if(!enabled)
			return;
		if (canPlaceTower ()) 
		{			
			if(IsPlatform())
			{
				gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
				if(this.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM01)
				{
					if(!TileManagerScript.Instance.platform01Checking())
					{
						gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
					}
				}
				else if(this.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM02)
				{
					if(!TileManagerScript.Instance.platform02Checking())
					{
						gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
					}
				}
				else if(this.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM03)
				{
					if(!TileManagerScript.Instance.platform03Checking())
					{
						gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
					}
				}
				else if(this.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM04)
				{
					if(!TileManagerScript.Instance.platform04Checking())
					{
						gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
					}
				}
				else if(this.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM05)
				{
					if(!TileManagerScript.Instance.platform05Checking())
					{
						gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
					}
				}
			} 
			else
			{
				gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			}

		}
		else
		{
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
		}
	}

	void OnMouseExit()
	{
		if(returnNormal == true)
		{
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}
}
