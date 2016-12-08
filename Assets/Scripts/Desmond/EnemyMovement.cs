using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	Animator animator;
	[HideInInspector]public GameObject[] wayPoints;

	[HideInInspector]public int currentWayPoint = 0;
	public float speed;
	[HideInInspector]public float slowSpeed;
	[HideInInspector]public float normalSpeed;

	[HideInInspector]public float slowDelayDuration;
	float slowDelayTimer = 0.0f;
	[HideInInspector]public bool IsSlow = false;

	[HideInInspector]public Vector3 targetPosition;
	[HideInInspector]public Vector3 moveDirection;

	public float attackDelayDuration;
	float attackDelayTimer = 0.0f;
	[HideInInspector]public bool TurnBack = false;
	float Delay = 0.0f ;
	public float Duration = 1f ;

	GameObject Level1;
	[HideInInspector]public bool slowDamageChecking = false;
	public float slowDamage;

	// Use this for initialization
	void Awake() 
	{
		normalSpeed = speed;
		animator = GetComponent<Animator>();
	}

	void Start()
	{
		Level1 = GameObject.Find("Lv1Spawner");
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

		if(Vector3.Distance(transform.position, targetPosition) < speed * Time.deltaTime)
		{
			if(currentWayPoint < wayPoints.Length - 1)
			{
				currentWayPoint += 1;
				targetPosition = wayPoints [currentWayPoint].transform.position;
				moveDirection = (targetPosition - transform.position).normalized;
			}
			else
			{
				//Invoke("Destroy",0);
				speed=0;
			}
		}

		if (IsSlow)
		{
			speed = normalSpeed*(1-slowSpeed);
			slowDelayTimer += Time.deltaTime;
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color32(41,167,255, 255);

			if (slowDelayTimer >= slowDelayDuration && IsSlow == true)
			{
				speed = normalSpeed;
				slowDelayTimer = 0;
				this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
				IsSlow = false;
			}

			if(currentWayPoint == wayPoints.Length - 1)
			{
				speed = 0;
			}
		}

		if(slowDamageChecking)
		{
			GetComponent<EnemyHealth>().currentHealth -= slowDamage;
			slowDamageChecking = false;
		}

		if(TurnBack)
		{
			Delay+=Time.deltaTime; 

			if(Delay>=Duration)
			{
				this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
				TurnBack = false; 
			}
		}

		if(currentWayPoint == wayPoints.Length - 1)
		{
			animator.Play("EnemyAttack");
		}
		else
		{
			animator.Play("EnemyWalking");
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Core"))
		{
			attackDelayTimer += Time.deltaTime;

			if(attackDelayTimer>=attackDelayDuration)
			{
				other.gameObject.GetComponent<CoreHealth>().healthMin -= 1;
				attackDelayTimer = 0;
			}
		}
	}
		
	void Destroy()
	{
		this.GetComponent<EnemyHealth>().enemyOnFire = false;
		this.GetComponent<EnemyHealth>().gotArrowShot = false;
		IsSlow = false;
		speed = normalSpeed;
		slowDelayTimer = 0;
		attackDelayTimer = 0;
		this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		Level1.GetComponent<SpawnEnemy1>().currentRemainingEnemy--;
	}
}
