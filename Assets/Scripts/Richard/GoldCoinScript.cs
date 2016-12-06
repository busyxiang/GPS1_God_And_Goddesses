using UnityEngine;
using System.Collections;

public class GoldCoinScript : MonoBehaviour 
{
	GameManagerBehaviour gameManagerCoin;
	[HideInInspector]public int CoinValue;
	public float stayDuration;
	public AudioClip pickCoinSound;
	[HideInInspector]public LayerMask layerMask;

	// Use this for initialization
	void Start () 
	{
		gameManagerCoin = GameObject.Find ("GameManager").GetComponent<GameManagerBehaviour>();
		Invoke("PickUp", stayDuration);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void PickUp()
	{
		gameManagerCoin.Gold += CoinValue;
		AudioSource.PlayClipAtPoint(pickCoinSound, transform.position, 1.0f);
		Destroy(this.gameObject);
	}
}
