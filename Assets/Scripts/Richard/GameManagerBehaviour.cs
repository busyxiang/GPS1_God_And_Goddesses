using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour 
{
	public Text goldLabel;
	public int initialGold;
	int gold;

	public int Gold 
	{
		get { return gold; }
		set 
		{
			gold = value;
			goldLabel.GetComponent<Text>().text = gold.ToString();
		}
	}

	// Use this for initialization
	void Start () 
	{
		Gold = initialGold;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
