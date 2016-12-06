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
		Sound.isOn = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P))
        {
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
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        AudioListener.volume = 1.0f;
    }
    
    public void ResumePress()
    {
		isPaused = false;
        PausePanel.enabled = false;
        Time.timeScale = 1.0f;
		UI.enabled = true;
        //AudioListener.volume = 1.0f;
    }

	public void SoundToggle()
	{
		if (isMute == false) 
		{
			isMute = true;
			AudioListener.volume = 0;
			Sound.isOn = true;
		}
		else if (isMute == true)
		{
			isMute = false;
			AudioListener.volume = 1;
			Sound.isOn = false;
		}
	}
}
