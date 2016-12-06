using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArtemisLV2_TowerController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public float range;
	float distance1;
	float distance2;

	[HideInInspector]public GameObject target1;
	[HideInInspector]public GameObject target2;
	[HideInInspector]public GameObject[] myTargets;
	public float damage;
	public float attackSpeed = 1f;
	Animator animator;
	SpriteRenderer spriteRenderer;

	void Awake()
	{
		GetComponentInParent<TowerData>().damageDeal = damage;
		GetComponentInParent<TowerData>().attackSpeed = this.attackSpeed;
		GetComponentInParent<TowerData>().range = this.range;
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start()
	{
		GetComponentInParent<TowerData>().damageDeal = damage;
		animator.speed = attackSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		myTargets = GameObject.FindGameObjectsWithTag("Enemy");

		if(this.gameObject.GetComponentInParent<ClickAndMove>().canShoot == true)
		{
			if (myTargets.Length > 0)
			{
				target1 = FindClosestEnemy();
				target2 = FindClosestEnemyExceptTheOtherOne();

				if(target1 != null || target2 != null)
				{
					if(target1 != null)
					{
						distance1 = Vector3.Distance(target1.transform.position, this.transform.position);

						if(target1.transform.position.x < this.transform.position.x)
						{
							spriteRenderer.flipX = true;
						}
						else
						{
							spriteRenderer.flipX = false;
						}
					}

					if(target2 != null)
					{
						distance2 = Vector3.Distance(target2.transform.position, this.transform.position);
					}

					if(distance1 <= range || distance2 <= range)
					{
						animator.Play("ArtemisLV2");
					}
					else
					{
						animator.Play("ArtemisLV2_Idle");
					}
				}
				else
				{
					animator.Play("ArtemisLV2_Idle");
				}
			}
			else
			{
				animator.Play("ArtemisLV2_Idle");
			}
		}
		else
		{
			animator.Play("ArtemisLV2_Idle");
		}
	}

	public void Shooting()
	{
		if(distance1 <= range)
		{
			GameObject go = (GameObject)Instantiate(bulletPrefab, this.transform.position, bulletPrefab.transform.rotation);
			go.GetComponent<ArtemisShooting>().target = this.target1;
			go.GetComponent<ArtemisShooting>().damage = this.damage;
		}

		if(distance2 <= range)
		{
			GameObject go = (GameObject)Instantiate(bulletPrefab, this.transform.position, bulletPrefab.transform.rotation);
			go.GetComponent<ArtemisShooting>().target = this.target2;
			go.GetComponent<ArtemisShooting>().damage = this.damage;
		}

		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_TowerArtemis);
	}

	GameObject FindClosestEnemy()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closestEnemy = null;

		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - this.gameObject.transform.position;
			float currentDistance = diff.sqrMagnitude;

			if (currentDistance < range)
			{
				closestEnemy = go;
				break;
			}
		}
		return closestEnemy;
	}

	GameObject FindClosestEnemyExceptTheOtherOne()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject secondClosestEnemy = null;

		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - this.gameObject.transform.position;
			float currentDistance = diff.sqrMagnitude;

			if (currentDistance < range && go != target1)
			{
				secondClosestEnemy = go;
				break;
			}
		}
		return secondClosestEnemy;
	}
}