using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZuesLV2_TowerController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject floorEffect;
	public float range;
	public float stayDuration;

	public float attackSpeed = 1;
	public float aoeDamage;
	float distance;
	[HideInInspector]public GameObject target;

	Animator animator;
	SpriteRenderer spriteRenderer;

	void Awake()
	{
		animator = GetComponent<Animator>();
		GetComponentInParent<TowerData>().damageDeal = this.aoeDamage;
		GetComponentInParent<TowerData>().attackSpeed = this.attackSpeed;
		GetComponentInParent<TowerData>().range = this.range;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Start()
	{
		animator.speed = attackSpeed;
	}

	void Update()
	{
		if(this.gameObject.GetComponentInParent<ClickAndMove>().canShoot == true)
		{
			target = FindClosetEnemy();

			if(target != null)
			{
				distance = Vector3.Distance(target.transform.position, this.transform.position);
				target.GetComponent<EnemyHealth>().zuesAoeDamage = this.aoeDamage;

				if(distance <= range)
				{
					animator.Play("ZuesTowerLV2");
				}
				else
				{
					animator.Play("ZuesTowerLV2_Idle");
				}

				if(target.transform.position.x < this.transform.position.x)
				{
					spriteRenderer.flipX = false;
				}
				else
				{
					spriteRenderer.flipX = true;
				}
			}
			else
			{
				animator.Play("ZuesTowerLV2_Idle");
			}
		}
	}

	public void ShootEnemy()
	{
		GameObject go = (GameObject)Instantiate(bulletPrefab, target.transform.position, bulletPrefab.transform.rotation);
		GameObject go2 = (GameObject)Instantiate(floorEffect, target.transform.position, floorEffect.transform.rotation);
		Destroy(go, stayDuration);
		Destroy(go2, go2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_TowerZeus);
	}

	GameObject FindClosetEnemy()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closetEnemy = null;
		float distance = Mathf.Infinity;

		foreach(GameObject go in gos)
		{
			Vector3 diff = go.transform.position - this.gameObject.transform.position;
			float currentDistance = diff.sqrMagnitude;

			if(currentDistance < distance)
			{
				closetEnemy = go;
				distance = currentDistance;
			}
		}
		return closetEnemy;
	}
}
