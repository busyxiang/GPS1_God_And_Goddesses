using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
	private static TutorialManager mInstance;

	public static TutorialManager Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("TutorialManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_TutorialManager");
					mInstance = obj.AddComponent<TutorialManager>();
					obj.tag = "TutorialManager";
					//DontDestroyOnLoad(obj);
				}
				else
				{
					mInstance = tempObject.GetComponent<TutorialManager>();
				}
			}
			return mInstance;
		}
	}

	public Sprite[] tutorialCard;
	public Image tutorialImage;
	int currentCardValue;
	public Canvas UI;
	public Canvas tutorialCanvas;
	public GameObject startGame;
	public GameObject summonThis;
	public GameObject placeHere;

	void Start()
	{
		currentCardValue = 0;
		updateTutorialCard();
	}

	void Update()
	{

	}

	void updateTutorialCard()
	{
		tutorialImage.sprite = tutorialCard[currentCardValue];
	}

	public void Next()
	{
		if(currentCardValue + 1 < tutorialCard.Length)
		{
			currentCardValue ++;
			updateTutorialCard();
		}
		else
		{
			if(SceneManager.GetActiveScene().name == "TutorialScene")
			{
				SceneManager.LoadScene ("TutorialLevel");
			}
		}
	}

	public void Previous()
	{
		if(currentCardValue - 1 >= 0)
		{
			currentCardValue --;
			updateTutorialCard();
		}
	}

	public void Close()
	{
		if(Time.timeScale != 1)
		{
			Time.timeScale = 1.0f;
		}

		UI.enabled = true;
		tutorialCanvas.enabled = false;

		if(SceneManager.GetActiveScene().name != "TutorialScene")
		{
			TileManagerScript.Instance.ActivateBoxCollider2D();			
		}
	}

	public void Open()
	{
		tutorialCanvas.enabled = true;
		UI.enabled = false;

		currentCardValue = 0;
		updateTutorialCard();

		if(SceneManager.GetActiveScene().name != "TutorialScene")
		{
			TileManagerScript.Instance.DeactivaBoxCollider2D();
		}

		if(Time.timeScale != 0)
		{
			Time.timeScale = 0.0f;
		}
	}
}
