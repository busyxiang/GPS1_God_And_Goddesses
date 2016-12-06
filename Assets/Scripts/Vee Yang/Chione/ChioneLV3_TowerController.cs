using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChioneLV3_TowerController : MonoBehaviour 
{
	public float range;
	[HideInInspector]public GameObject[] targetPrefabs;

	float distance;
	Animator animator;
	SpriteRenderer spriteRenderer;
	[HideInInspector]public GameObject closestEnemy;
	public float slowSpeed;
	public float damage;
	float timer ;
	float delayTimer= 1f  ;

	void Awake()
	{
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		GetComponentInParent<TowerData>().slowSpeed = this.slowSpeed;
		GetComponentInParent<TowerData>().damageDeal = this.damage;
		GetComponentInParent<TowerData>().range = this.range;
	}

	void Start()
	{
		
	}

	void Update()
	{
		targetPrefabs = GameObject.FindGameObjectsWithTag("Enemy");
		timer += Time.deltaTime;

		if(this.gameObject.GetComponentInParent<ClickAndMove>().canShoot == true)
		{
			if(targetPrefabs.Length > 0)
			{
				closestEnemy = FindClosetEnemy();

				for(int i=0; i<targetPrefabs.Length; i++)
				{
					if(Vector3.Distance(targetPrefabs[i].transform.position, this.transform.position) <= range)
					{
						animator.Play("ChioneTowerLV3");
						targetPrefabs[i].GetComponent<EnemyMovement>().IsSlow = true;
						targetPrefabs[i].GetComponent<EnemyMovement>().slowSpeed = this.slowSpeed;
					}
						
					if(closestEnemy == null)
					{
						animator.Play("ChioneTowerLV3_Idle");
					}
					else
					{
						if(closestEnemy.transform.position.x < this.transform.position.x)
						{
							spriteRenderer.flipX = false;
						}
						else
						{
							spriteRenderer.flipX = true;
						}
						SoundManagerScript.Instance.PlayLoopingSFX(AudioClipID.SFX_TowerChione); 
					}
				}

				if(timer>=delayTimer)
				{
					for(int i=0; i<targetPrefabs.Length; i++)
					{
						if(Vector3.Distance(targetPrefabs[i].transform.position, this.transform.position) <= range)
						{
							targetPrefabs[i].GetComponent<EnemyMovement>().slowDamage = this.damage; 
							targetPrefabs[i].GetComponent<EnemyMovement>().slowDamageChecking = true;
							timer = 0;
						}
					}
				}
			}
			else
			{
				animator.Play("ChioneTowerLV3_Idle");
				SoundManagerScript.Instance.StopLoopingSFX(AudioClipID.SFX_TowerChione);
			}
		}
		else
		{
			animator.Play("ChioneTowerLV3_Idle");
			SoundManagerScript.Instance.StopLoopingSFX(AudioClipID.SFX_TowerChione);
		}
	}

	GameObject FindClosetEnemy()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closetEnemy = null;

		foreach(GameObject go in gos)
		{
			float distance = Vector3.Distance(go.transform.position, this.transform.position);

			if(distance < range)
			{
				closetEnemy = go;
				break;
			}
		}
		return closetEnemy;
	}
		
}
