using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{
	//public GameObject Bullet;
	private float originalScale ;

	// Use this for initialization
	void Start ()
	{
		originalScale = gameObject.transform.localScale.x;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 tmpScale = gameObject.transform.localScale;
		tmpScale.x = GetComponentInParent<EnemyHealth>().currentHealth/GetComponentInParent<EnemyHealth>().maxHealth * originalScale;
		gameObject.transform.localScale = tmpScale;
	}
}

