using UnityEngine;
using System.Collections;

public class ArtemisShooting : MonoBehaviour 
{
	public GameObject target;
	[HideInInspector]public float damage;
	public float bulletSpeed;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target != null && target.activeSelf == true)
		{
			Vector3 direction = target.transform.position - this.transform.position;
			float distance = bulletSpeed * Time.deltaTime;
			transform.Translate(direction.normalized * distance, Space.World);
			transform.LookAt(new Vector3(0,0,180), new Vector3(direction.y, -direction.x, 0f));

			if(target.activeSelf == false)
			{
				Destroy(this.gameObject);
			}
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == target)
		{
			target.GetComponent<EnemyHealth>().gotArrowShot = true;
			target.GetComponent<EnemyHealth>().currentHealth -= damage;
			Destroy(this.gameObject);
		}
	}
}