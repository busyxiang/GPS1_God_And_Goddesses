	using UnityEngine;
using System.Collections;

public class PlutosTowerDropCoin : MonoBehaviour 
{
	public GameObject coin;
	float delayTimer = 0f ;
	public float delayDuration;
	bool DropCoin = false;
	int activeEnemy;
	public int goldValue;

	// Use this for initialization
	void Start () 
	{
		GetComponentInParent<TowerData>().coinRate = goldValue;
	}

	// Update is called once per frame
	void Update ()
	{
		activeEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;

		if(activeEnemy == 0)
		{
			DropCoin = false;
			delayTimer = 0;
		}
		else
		{
			DropCoin = true;
		}				

		if(DropCoin)
		{
			delayTimer += Time.deltaTime;

			if (delayTimer > delayDuration) 
			{
				delayTimer = 0;

				GameObject go;
				go = (GameObject)Instantiate (coin, transform.position, Quaternion.identity);
				go.GetComponent<GoldCoinScript>().CoinValue = goldValue;
			}
		}
	}
}
