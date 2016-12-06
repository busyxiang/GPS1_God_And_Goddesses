using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Credits : MonoBehaviour 
{
	public Button MainMenu;

	// Use this for initialization
	void Start () {
		MainMenu = MainMenu.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MenuPress()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
