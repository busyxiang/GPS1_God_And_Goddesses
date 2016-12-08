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
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene ("TutorialLevel");
	}

    public void Level1Press()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene("Level_1");
    }

	public void Level2Press()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene ("Level_2");
	}

	public void MenuPress()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene ("MainMenu");
	}
}
