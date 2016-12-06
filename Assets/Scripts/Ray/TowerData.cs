using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class TowerLevel
{
	public int cost;
	public GameObject visualization;
}

public enum Platform
{
	NONE = 0,
	PLATFORM_01,
	PLATFORM_02,
	PLATFORM_03,
	PLATFORM_04,
	PLATFORM_05
}

public class TowerData : MonoBehaviour 
{
	public Platform platform = Platform.NONE;

	public List<TowerLevel> levels;
	private TowerLevel currentLevel;

	public TowerLevel CurrentLevel
	{
		get{
			return currentLevel;
		}
		set{
			currentLevel = value;
			int currentLevelIndex = levels.IndexOf(currentLevel);

			GameObject levelVisualization = levels [currentLevelIndex].visualization;
				for(int i = 0; i<levels.Count; i++){
					if(levelVisualization != null){
						if(i == currentLevelIndex){
							levels[i].visualization.SetActive(true);
						}
						else{
							levels[i].visualization.SetActive(false);
						}
					}
				}
		}
	}

	void OnEnable(){
		CurrentLevel = levels [0];
	}

	public TowerLevel GetNextLevel(){
		int currentLevelIndex = levels.IndexOf (currentLevel);
		int maxLevelIndex = levels.Count - 1;
		if (currentLevelIndex < maxLevelIndex) {
			return levels [currentLevelIndex + 1];
		} else {
			return null;
		}
	}

	public void IncreaseLevel(){
		int currentLevelIndex = levels.IndexOf (currentLevel);
		if (currentLevelIndex < levels.Count - 1) {
			CurrentLevel = levels [currentLevelIndex + 1];
		}
	}

	[HideInInspector]public float damageDeal;
	[HideInInspector]public float attackSpeed;
	[HideInInspector]public float slowSpeed;
	[HideInInspector]public float burnDamage;
	[HideInInspector]public float coinRate;
	[HideInInspector]public float range;

	void Start ()
	{
		
	}
}
