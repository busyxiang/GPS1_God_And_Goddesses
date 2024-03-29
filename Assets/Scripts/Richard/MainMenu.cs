﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public Canvas quitMenu;
	public Button startGame;
	public Button Level;
	public Button Settings;
	public Button Credits;
	public Button QuitGame;
	int totalEnemy;
	GameObject[] enemy;


	// Use this for initialization
	void Start ()
    {
		startGame = startGame.GetComponent<Button>();
		Level = Level.GetComponent<Button> ();
		Settings = Settings.GetComponent<Button>();
		Credits = Credits.GetComponent<Button> ();
		quitMenu = quitMenu.GetComponent<Canvas>();
        QuitGame = QuitGame.GetComponent<Button>();
        quitMenu.enabled = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startGame.interactable = false;
		Level.interactable = false;
		Settings.interactable = false;
		Credits.interactable = false;
        QuitGame.interactable = false;
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startGame.interactable = true;
		Level.interactable = true;
		Settings.interactable = true;
		Credits.interactable = true;
		QuitGame.interactable = true;
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
    }

    public void LevelPress()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene("LevelSelection");
    }

	public void StartGame()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene("TutorialLevel");
	}

	public void SettingsPress()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene("Settings");
	}

	public void CreditPress()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene ("Credits");
	}

    public void ExitGame()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
        Application.Quit();
    }
}
