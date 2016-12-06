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

	public GameObject[] tutorialCard;
	public List<GameObject> cards;
	int currentCardValue;
	int nextCardValue;
	public Canvas UI;
	public Canvas tutorialCanvas;
	public GameObject startGame;
	public GameObject summonThis;
	public GameObject placeHere;

	void Awake()
	{
		currentCardValue = 0;

		for(int i=0; i<tutorialCard.Length; i++)
		{
			GameObject card = GameObject.Instantiate(tutorialCard[i],Vector3.zero,Quaternion.identity) as GameObject;

			cards.Add(card);

			card.SetActive(false);

			GameObject.DontDestroyOnLoad(card);
		}

		cards[currentCardValue].SetActive(true);
	}

	void Start()
	{
		UI.enabled = false;
		Time.timeScale = 0.0f;
		TileManagerScript.Instance.DeactivaBoxCollider2D();
	}

	void Update()
	{

	}

	public void Next()
	{
		if(currentCardValue <tutorialCard.Length - 1)
		{
			nextCardValue = currentCardValue + 1;
			cards[currentCardValue].SetActive(false);
			cards[nextCardValue].SetActive(true);
			currentCardValue = nextCardValue;
		}
	}

	public void Previous()
	{
		if(currentCardValue >= 1)
		{
			nextCardValue = currentCardValue - 1;
			cards[currentCardValue].SetActive(false);
			cards[nextCardValue].SetActive(true);
			currentCardValue = nextCardValue;
		}
	}

	public void Close()
	{
		UI.enabled = true;
		Time.timeScale = 1.0f;
		TileManagerScript.Instance.ActivateBoxCollider2D();
		tutorialCanvas.enabled = false;
		cards[currentCardValue].SetActive(false);
		cards[nextCardValue].SetActive(false);
	}

	public void Open()
	{
		tutorialCanvas.enabled = true;
		currentCardValue = 0;
		cards[currentCardValue].SetActive(true);
		UI.enabled = false;
		Time.timeScale = 0.0f;
		TileManagerScript.Instance.DeactivaBoxCollider2D();
	}
}
