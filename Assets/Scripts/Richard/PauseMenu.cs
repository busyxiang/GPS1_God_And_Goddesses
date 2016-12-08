using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour 
{
	public Canvas UI;
    public Canvas PausePanel;
    public Button ResumeGame;
    public Button MainMenu;
    bool isPaused;
	public Toggle Sound;
	Settings settingsScript;
	bool isMute;

	// Use this for initialization
	void Start () 
	{
		UI = UI.GetComponent<Canvas> ();
        PausePanel = PausePanel.GetComponent<Canvas>();
        ResumeGame = ResumeGame.GetComponent<Button>();
        MainMenu = MainMenu.GetComponent<Button>();
        PausePanel.enabled = false;
        isPaused = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
		{
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);

            if(isPaused == false)
            {
				isPaused = true;
                PausePanel.enabled = true;
                Time.timeScale = 0.0f;
				UI.enabled = false;
				TileManagerScript.Instance.DeactivaBoxCollider2D();
                //AudioListener.volume = 0.0f;
            }
            else if(isPaused == true)
            {
				isPaused = false;
                PausePanel.enabled = false;
                Time.timeScale = 1.0f;
				UI.enabled = true;
				TileManagerScript.Instance.ActivateBoxCollider2D();
                //AudioListener.volume = 1.0f;
            }
        }
	}

    public void MenuPress()
    {
		if(Time.timeScale != 1.0f)
		{
			Time.timeScale = 1.0f;
		}

		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		AudioListener.volume = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ResumePress()
    {
		isPaused = false;
        PausePanel.enabled = false;
		Time.timeScale = 1.0f;
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		UI.enabled = true;
		TileManagerScript.Instance.ActivateBoxCollider2D();
        //AudioListener.volume = 1.0f;
    }

	public void SoundToggle(bool isOn)
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);

		if (!isOn) 
		{
			AudioListener.volume = 0;
		}
		else
		{
			AudioListener.volume = 1;
		}
	}
}
