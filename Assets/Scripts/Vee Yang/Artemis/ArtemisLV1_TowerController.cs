using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArtemisLV1_TowerController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public float range = 0.0f;
	public float attackSpeed = 1f;

	float distance;

	[HideInInspector]public GameObject target;
	public float damage;

	public AudioClip arrowShotSound;
	AudioSource source;
	Animator animator;
	SpriteRenderer spriteRenderer;

	void Awake()
	{
		source = GetComponent<AudioSource>();
		GetComponentInParent<TowerData>().damageDeal = damage;
		GetComponentInParent<TowerData>().attackSpeed = this.attackSpeed;
		GetComponentInParent<TowerData>().range = this.range;
		animator = GetComponent<Animator>();
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

			if (target != null && target.tag == "Enemy") 
			{
				distance = Vector3.Distance (target.transform.position, this.transform.position);

				if (distance <= range)
				{					
					animator.Play ("ArtemisLV1");	
				} 
				else 
				{
					animator.Play ("ArtemisIdle");
				}

				if(target.transform.position.x < this.transform.position.x)
				{
					spriteRenderer.flipX = true;
				}
				else
				{
					spriteRenderer.flipX = false;
				}
			} 
			else 
			{
				animator.Play("ArtemisIdle");
			}
		}
		else 
		{
			animator.Play("ArtemisIdle");
		}
	}

	public void Shooting()
	{
		GameObject go = (GameObject)Instantiate (bulletPrefab, this.transform.position, bulletPrefab.transform.rotation);
		go.GetComponent<ArtemisShooting> ().target = this.target;
		go.GetComponent<ArtemisShooting> ().damage = this.damage;
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_TowerArtemis);
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

	void ArrowShootSound()
	{
		source.PlayOneShot(arrowShotSound);
	}
}
