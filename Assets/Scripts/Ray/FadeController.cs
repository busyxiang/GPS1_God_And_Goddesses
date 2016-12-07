using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeController : MonoBehaviour 
{
	//public GameObject firstScene;
	//public FadeInFadeOut objectFaderScript;

	private float timer = 0.0f, duration = 3f;

	// Use this for initialization
	void Awake()
	{
		
	}

	void Start () 
	{
		//objectFaderScript = firstScene.GetComponent<FadeInFadeOut>();
		//firstScene.SetActive(true);
		//objectFaderScript.FadeIn();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timer > duration)
		{
			SceneManager.LoadScene("MainMenu");
		}
		else 
		{
			timer += Time.deltaTime;
		}
	}
}
