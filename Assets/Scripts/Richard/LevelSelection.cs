using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelection : MonoBehaviour 
{
	public Button Tutorial;
    public Button Level1;
	public Button Level2;
	public Button MainMenu;

	// Use this for initialization
	void Start () 
	{
		Tutorial = Tutorial.GetComponent<Button>();
        Level1 = Level1.GetComponent<Button>();
		Level2 = Level2.GetComponent<Button>();
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
