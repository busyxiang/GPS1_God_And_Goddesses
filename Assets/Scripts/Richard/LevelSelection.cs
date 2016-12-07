using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelection : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void TutorialPress()
	{
		SceneManager.LoadScene ("TutorialLevel");
	}

    public void Level1Press()
    {
		SceneManager.LoadScene("Level_1");
    }

	public void Level2Press()
	{
		SceneManager.LoadScene ("Level_2");
	}

	public void MenuPress()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
