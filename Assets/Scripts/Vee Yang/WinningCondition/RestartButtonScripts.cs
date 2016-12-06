using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartButtonScripts : MonoBehaviour 
{
	//public GameObject Choose;

	public void OnClick()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		//SceneManager.LoadScene("Level_2");
	}
	public void OnClick1()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
