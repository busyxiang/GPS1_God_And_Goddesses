using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour
{
	public enum Type
	{
		NONE = 0,
		PATH,
		PLATFORM,
		TOTAL
	}

	public enum Platform
	{
		NONE = 0,
		PLATOFORM01,
		PLATOFORM02,
		PLATOFORM03,
		PLATOFORM04,
		PLATOFORM05,
		TOTAL
	}

	public Type type = Type.NONE;
	public Platform platform = Platform.NONE;

	public Sprite[] spriteList;
	[HideInInspector]public SpriteRenderer spriteRenderer;

	public int rowIndex;
	public int colIndex;

	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnMouseDown()
	{
		if(GetComponent<PlaceTower>().isActiveAndEnabled == false)
		{
			if(GetComponent<PlaceTower>().tower != null)
			{
				GUIManagerScript.Instance.selectedGO = GetComponent<PlaceTower>().tower;
				GUIManagerScript.Instance.UpdateSelectedInfo();
			}
			else
			{
				if(type == Type.PLATFORM)
				{
					GUIManagerScript.Instance.selectedGO = this.gameObject;
					GUIManagerScript.Instance.UpdateSelectedInfo();
				}
			}
		}

		if(type == Type.NONE)
		{
			GUIManagerScript.Instance.UnselectEverything();
		}
	}
}
