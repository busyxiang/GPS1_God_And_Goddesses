using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public float maxHealth = 100;
	public float currentHealth;
	[HideInInspector]public float artemisArrowDamage;
	[HideInInspector]public float zuesAoeDamage;
	public GameObject coin;
	public int enemyValue;
	[HideInInspector]public bool enemyOnFire = false;
	public float heliosFireDamage;
	[HideInInspector]public bool gotArrowShot = false;
	float flickerTimer = 0.0f;
	float flickerInterval = 0.1f;
	float flickerStartTimer = 0.0f;
	float flickerDuration = 1.0f;
	SpriteRenderer spriteRenderer;

	void Awake()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentHealth <= 0 && gameObject.activeSelf == true) 
		{
			GameObject go = (GameObject)Instantiate(coin, transform.position, Quaternion.identity);
			go.GetComponent<GoldCoinScript>().CoinValue = enemyValue;
			Invoke("Destroy",0);
			this.gameObject.SetActive(false);
		}

		if(gotArrowShot)
		{
			flickerTimer += Time.deltaTime;
			flickerStartTimer += Time.deltaTime;

			if(flickerTimer >= flickerInterval)
			{
				if(spriteRenderer.color == Color.white)
				{
					spriteRenderer.color = new Color32(249,249,249,132);
					flickerTimer = 0;
				}
				else
				{
					spriteRenderer.color = Color.white;
					flickerTimer = 0;
				}
			}

			if(flickerStartTimer >= flickerDuration)
			{
				gotArrowShot = false;
				spriteRenderer.color = Color.white;
				flickerStartTimer = 0;
			}
		}

		if(SceneManager.GetActiveScene().name == "MainMenu")
		{
			this.gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("ZeusAoe"))
		{
			spriteRenderer.color = new Color32(255,248,0,170);
			this.gameObject.GetComponent<EnemyMovement>().TurnBack = true ; 
			this.currentHealth -= zuesAoeDamage;
		}
		if(other.gameObject.CompareTag("FireBullet"))
		{
			spriteRenderer.color = new Color32(255,94,94,255);
			this.currentHealth -= heliosFireDamage;
			enemyOnFire = true;
		}
	}

	void Destroy()
	{
		this.gameObject.transform.position = new Vector3(6.6f,2f,-4f);
		GetComponent<EnemyMovement>().Invoke("Destroy", 0f);
	}
}
