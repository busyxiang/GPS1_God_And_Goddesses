using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Settings : MonoBehaviour 
{
	public Button SoundOn;
	public Button SoundOff;
	public bool isMute;
	public Button MainMenu;

	// Use this for initialization
	void Start () 
	{
		MainMenu = MainMenu.GetComponent<Button>();
		SoundOn = SoundOn.GetComponent<Button>();
		SoundOff = SoundOff.GetComponent<Button>();
		SoundOff.interactable = true;
		SoundOn.interactable = false;
		isMute = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SoundPress()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);

		if(!isMute)
		{
			isMute = true;
			AudioListener.volume = 0;
			SoundOff.interactable = false;
			SoundOn.interactable = true;
		}
		else
		{
			isMute = false;
			AudioListener.volume = 1;
			SoundOff.interactable = true;
			SoundOn.interactable = false;
		}
	}

	public void MenuPress()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);
		SceneManager.LoadScene("MainMenu");
	}
}
