using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CoreHealth : MonoBehaviour 
{
	public float healthMax = 100;
	public float healthMin;

	public GameObject lose ;

	int totalEnemy;
	GameObject[] enemy;

	// Use this for initialization
	void Start ()
	{
		healthMin = healthMax ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		totalEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;

		if (healthMin <= 0)
		{
			SoundManagerScript.Instance.StopBGM();
			SoundManagerScript.Instance.PlayBGM(AudioClipID.BGM_LoseMusic);
			lose.SetActive(true);
			Time.timeScale = 0.0f;
		}
	}

	void GameOver()
	{
		totalEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
		enemy = GameObject.FindGameObjectsWithTag("Enemy");

		for(int i=0; i<totalEnemy; i++)
		{
			enemy[i].SetActive(false);
		}

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void OnMouseDown()
	{
		GUIManagerScript.Instance.selectedGO = this.gameObject;
		GUIManagerScript.Instance.UpdateSelectedInfo();
	}

	public void Onclick1()
	{
		GUIManagerScript.Instance.OnClickRestart();
		healthMin = healthMax;	
	}

	public void Onclick2()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
