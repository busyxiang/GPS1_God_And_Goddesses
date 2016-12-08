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
	public GraphicRaycaster UIRaycast;
	public Canvas tutorialCanvas;
	public GameObject startGame;
	public GameObject summonThis;
	public GameObject placeHere;

	public GameObject next;
	public GameObject previous;
	public GameObject close;
	public GameObject close2;

	[HideInInspector]public bool placedTower = false;
	[HideInInspector]public bool minionSpawned = false;
	[HideInInspector]public bool showedUpgrade = false;

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
		TileManagerScript.Instance.ActivateBoxCollider2D();
	}

	public void Open()
	{
		tutorialCanvas.enabled = true;
		UI.enabled = false;

		currentCardValue = 0;
		updateTutorialCard();
		TileManagerScript.Instance.DeactivaBoxCollider2D();

		next.SetActive(true);
		previous.SetActive(true);
		close.SetActive(true);
		close2.SetActive(false);

		if(Time.timeScale != 0)
		{
			Time.timeScale = 0;
		}
	}

	public void OpenUpHint(int cardValue)
	{
		tutorialCanvas.enabled = true;
		UIRaycast.enabled = false;

		currentCardValue = cardValue;
		updateTutorialCard();
		TileManagerScript.Instance.DeactivaBoxCollider2D();

		next.SetActive(false);
		previous.SetActive(false);
		close.SetActive(false);
		close2.SetActive(true);

		if(Time.timeScale != 0)
		{
			Time.timeScale = 0;
		}
	}

	public void CloseHint()
	{
		if(Time.timeScale != 1)
		{
			Time.timeScale = 1.0f;
		}

		if(currentCardValue == 0)
		{
			GUIManagerScript.Instance.progressIndicatorImage.gameObject.SetActive(true);
			GUIManagerScript.Instance.UpdateProgressIndicator(0);
		}

		UIRaycast.enabled = true;
		tutorialCanvas.enabled = false;
		TileManagerScript.Instance.ActivateBoxCollider2D();

		if(currentCardValue == 1)
		{
			OpenUpHint(2);
		}
		else if(currentCardValue == 4)
		{
			GUIManagerScript.Instance.progressIndicatorImage.gameObject.SetActive(true);
			GUIManagerScript.Instance.UpdateProgressIndicator(2);
		}
	}
}
