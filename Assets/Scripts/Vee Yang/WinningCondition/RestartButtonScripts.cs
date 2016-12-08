using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartButtonScripts : MonoBehaviour 
{
	//public GameObject Choose;

	public void NextLevel()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		//SceneManager.LoadScene("Level_2");
	}
	public void MainMenu()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene("MainMenu");
	}

	public void Restart()
	{
		if(Time.timeScale != 1.0f)
		{
			Time.timeScale = 1.0f;
		}

		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
