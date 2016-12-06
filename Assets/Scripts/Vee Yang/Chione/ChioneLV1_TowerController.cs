using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChioneLV1_TowerController : MonoBehaviour 
{
	public float range;
	public GameObject[] targetPrefabs;

	float distance;
	Animator animator;
	SpriteRenderer spriteRenderer;
	public GameObject closestEnemy;
	public float slowPrecent;

	void Awake()
	{
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		GetComponentInParent<TowerData>().slowSpeed = this.slowPrecent;
		GetComponentInParent<TowerData>().range = this.range;
	}

	void Start()
	{

	}

	void Update()
	{
		targetPrefabs = GameObject.FindGameObjectsWithTag("Enemy");

		if(this.gameObject.GetComponentInParent<ClickAndMove>().canShoot == true)
		{
			if(targetPrefabs.Length > 0)
			{
				closestEnemy = FindClosetEnemy();

				for(int i=0; i<targetPrefabs.Length; i++)
				{
					if(Vector3.Distance(targetPrefabs[i].transform.position, this.transform.position) <= range)
					{
						animator.Play("ChioneTowerLV1");
						targetPrefabs[i].GetComponent<EnemyMovement>().IsSlow = true;
						targetPrefabs[i].GetComponent<EnemyMovement>().slowSpeed = this.slowPrecent;
					}
				}

				if(closestEnemy == null)
				{
					animator.Play("ChioneTowerLV1_Idle");
					SoundManagerScript.Instance.StopLoopingSFX(AudioClipID.SFX_TowerChione);
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
			else
			{
				animator.Play("ChioneTowerLV1_Idle");
				SoundManagerScript.Instance.StopLoopingSFX(AudioClipID.SFX_TowerChione);
			}
		}
		else
		{
			animator.Play("ChioneTowerLV1_Idle");
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
			Vector3 diff = go.transform.position - this.gameObject.transform.position;
			float currentDistance = diff.sqrMagnitude;

			if(currentDistance < range)
			{
				closetEnemy = go;
				break;
			}
		}
		return closetEnemy;
	}
}
