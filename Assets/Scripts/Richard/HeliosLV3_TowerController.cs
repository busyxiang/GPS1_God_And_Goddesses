using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeliosLV3_TowerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float range = 0.0f;
    public float attackSpeed = 1f;

    float distance;

    public GameObject target;
	public float damage;
	public float burnDamage;
	public float burnTime;

	Animator animator;
	SpriteRenderer spriteRenderer;

    void Awake()
    {
		GetComponentInParent<TowerData>().attackSpeed = this.attackSpeed;
		GetComponentInParent<TowerData>().range = this.range;
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		GetComponentInParent<TowerData>().damageDeal = damage;
		GetComponentInParent<TowerData>().burnDamage = this.burnDamage;
    }

    void Start()
    {
        animator.speed = attackSpeed;
    }

    void Update()
    {
        if (this.gameObject.GetComponentInParent<ClickAndMove>().canShoot == true)
        {
            target = FindClosetEnemy();

            if (target != null)
            {
                distance = Vector3.Distance(target.transform.position, this.transform.position);

                if (distance <= range)
                {
					target.GetComponent<HeliosFireTest>().damageAmount = burnDamage;
					target.GetComponent<HeliosFireTest>().damageTimer = burnTime;
					animator.Play ("HeliosTowerLV3");
                }
				else 
				{
					animator.Play ("HeliosTowerLV3_Idle");	
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
				animator.Play("HeliosTowerLV3_Idle");
            }
        }
		else 
		{
			animator.Play ("HeliosTowerLV3_Idle");	
		}
    }

    public void Shooting()
    {
		GameObject go = (GameObject)Instantiate(bulletPrefab, this.transform.position, bulletPrefab.transform.rotation);
		go.GetComponent<HeliosBullet>().target = this.target;
		go.GetComponent<HeliosBullet>().damage = this.damage;
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_TowerHelios) ;
    }

    GameObject FindClosetEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closetEnemy = null;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - this.gameObject.transform.position;
            float currentDistance = diff.sqrMagnitude;

            if (currentDistance < range)
            {
				closetEnemy = go;
				break;
            }
        }
        return closetEnemy;
    }
}
