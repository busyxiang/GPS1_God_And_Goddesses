using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickAndMove : MonoBehaviour
{
	GameObject self;
	[HideInInspector]public int rowIndex;
	[HideInInspector]public int colIndex;
	[HideInInspector]public int targetRowIndex;
	[HideInInspector]public int targetColIndex;

	[HideInInspector]public int moveGridIndex = 0;
	[HideInInspector]public List<Vector3> moveGridList = new List<Vector3>();

	Vector3 currentGridPos;
	float moveGridTimer = 0.0f;
	public float moveGridDuration;
	public bool canMove = false;
	public bool showChecking = false;
	[HideInInspector]public GameObject currentTile;

	LayerMask tileLayerMask;
	LayerMask towerLayerMask;
	LayerMask UILayerMask;
	[HideInInspector]public bool canShoot;

	GUIManagerScript guiManager;

	public GameObject movingIndicator;
	GameObject indicator;

	bool isMoving = false;
	[HideInInspector]public SpriteRenderer spriteRenderer;
	bool deselectTower = false;

	// Use this for initialization
	void Awake()
	{
		canShoot = true;

		guiManager = GameObject.Find("GUIManagerPrefab").GetComponent<GUIManagerScript>();
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	void Start () 
	{
		self = this.gameObject;

		tileLayerMask = LayerMask.NameToLayer("Tile");
		tileLayerMask.value = (1 << tileLayerMask.value);
		towerLayerMask = LayerMask.NameToLayer("Tower");
		towerLayerMask.value = (1 << towerLayerMask.value);
	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileLayerMask);
		RaycastHit2D towerHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, towerLayerMask);

		if(towerHit)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(towerHit.transform.gameObject == this.gameObject)
				{
					guiManager.selectedGO = this.gameObject;
					GUIManagerScript.Instance.UpdateSelectedInfo();
					deselectTower = false;

					if(!isMoving)
					{
						canMove = true;
						showChecking = true;
					}
				}
				else
				{
					Deactivate();
					guiManager.selectedGO = towerHit.transform.gameObject;
					GUIManagerScript.Instance.UpdateSelectedInfo();
					deselectTower = true;
				}
			}
			else if(Input.GetMouseButtonDown(1))
			{
				if(towerHit.transform.gameObject != this.gameObject)
				{
					Deactivate();
					deselectTower = true;
				}
			}
		}

		if(moveGridIndex < moveGridList.Count)
		{
			moveGridTimer += Time.deltaTime;
			transform.position = Vector3.Lerp(currentGridPos,moveGridList[moveGridIndex], moveGridTimer/moveGridDuration);

			if(moveGridTimer >= moveGridDuration)
			{
				currentGridPos = transform.position;
				moveGridTimer = 0.0f;
				moveGridIndex++;
			}
			if(moveGridIndex >= moveGridList.Count)
			{
				moveGridIndex = 0;
				moveGridList.Clear();
				rowIndex = targetRowIndex;
				colIndex = targetColIndex;
			}

			if(moveGridList.Count == 0)
			{
				Destroy(indicator);
				canShoot = true;
				isMoving = false;

				if(!deselectTower)
				{
					showChecking = true;
					canMove = true;
				}
			}
		}

		if(canMove)
		{
			if(hit)
			{
				if(Input.GetMouseButtonDown(1))
				{
					SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_Click);

					if(hit.transform.gameObject.CompareTag("Tile"))
					{
						if(hit.transform.gameObject.GetComponent<TileScript>().type == TileScript.Type.PLATFORM)
						{
							if(hit.transform.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM01)
							{
								if(this.gameObject.GetComponent<TowerData>().platform == Platform.PLATFORM_01)
								{
									if(hit.transform.gameObject != currentTile && hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
									{
										hit.transform.gameObject.GetComponent<PlaceTower>().tower = self;
										currentGridPos = transform.position;
										targetRowIndex = hit.transform.gameObject.GetComponent<TileScript>().rowIndex;
										targetColIndex = hit.transform.gameObject.GetComponent<TileScript>().colIndex;
										TileManagerScript.Instance.GeneratePath(rowIndex, colIndex, targetRowIndex, targetColIndex, ref moveGridList);
										canMove = false;
										showChecking = false;
										currentTile.GetComponent<PlaceTower>().tower = null;
										currentTile = hit.transform.gameObject;
										canShoot = false;
										isMoving = true;

										indicator = (GameObject)Instantiate(movingIndicator, hit.transform.gameObject.transform.position, Quaternion.identity);
									}
								}
							}

							else if(hit.transform.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM02)
							{
								if(this.gameObject.GetComponent<TowerData>().platform == Platform.PLATFORM_02)
								{
									if(hit.transform.gameObject != currentTile && hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
									{
										hit.transform.gameObject.GetComponent<PlaceTower>().tower = self;
										currentGridPos = transform.position;
										targetRowIndex = hit.transform.gameObject.GetComponent<TileScript>().rowIndex;
										targetColIndex = hit.transform.gameObject.GetComponent<TileScript>().colIndex;
										TileManagerScript.Instance.GeneratePath(rowIndex, colIndex, targetRowIndex, targetColIndex, ref moveGridList);
										canMove = false;
										showChecking = false;
										currentTile.GetComponent<PlaceTower>().tower = null;
										currentTile = hit.transform.gameObject;
										canShoot = false;
										isMoving = true;
										 
										indicator = (GameObject)Instantiate(movingIndicator, currentTile.transform.gameObject.transform.position, Quaternion.identity);
									}
								}
							}

							else if(hit.transform.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM03)
							{
								if(this.gameObject.GetComponent<TowerData>().platform == Platform.PLATFORM_03)
								{
									if(hit.transform.gameObject != currentTile && hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
									{
										hit.transform.gameObject.GetComponent<PlaceTower>().tower = self;
										currentGridPos = transform.position;
										targetRowIndex = hit.transform.gameObject.GetComponent<TileScript>().rowIndex;
										targetColIndex = hit.transform.gameObject.GetComponent<TileScript>().colIndex;
										TileManagerScript.Instance.GeneratePath(rowIndex, colIndex, targetRowIndex, targetColIndex, ref moveGridList);
										canMove = false;
										showChecking = false;
										currentTile.GetComponent<PlaceTower>().tower = null;
										currentTile = hit.transform.gameObject;
										canShoot = false;
										isMoving = true;

										indicator = (GameObject)Instantiate(movingIndicator, currentTile.transform.gameObject.transform.position, Quaternion.identity);
									}
								}
							}

							else if(hit.transform.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM04)
							{
								if(this.gameObject.GetComponent<TowerData>().platform == Platform.PLATFORM_04)
								{
									if(hit.transform.gameObject != currentTile && hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
									{
										hit.transform.gameObject.GetComponent<PlaceTower>().tower = self;
										currentGridPos = transform.position;
										targetRowIndex = hit.transform.gameObject.GetComponent<TileScript>().rowIndex;
										targetColIndex = hit.transform.gameObject.GetComponent<TileScript>().colIndex;
										TileManagerScript.Instance.GeneratePath(rowIndex, colIndex, targetRowIndex, targetColIndex, ref moveGridList);
										canMove = false;
										showChecking = false;
										currentTile.GetComponent<PlaceTower>().tower = null;
										currentTile = hit.transform.gameObject;
										canShoot = false;
										isMoving = true;

										indicator = (GameObject)Instantiate(movingIndicator, currentTile.transform.gameObject.transform.position, Quaternion.identity);
									}
								}
							}

							else if(hit.transform.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM05)
							{
								if(this.gameObject.GetComponent<TowerData>().platform == Platform.PLATFORM_05)
								{
									if(hit.transform.gameObject != currentTile && hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
									{
										hit.transform.gameObject.GetComponent<PlaceTower>().tower = self;
										currentGridPos = transform.position;
										targetRowIndex = hit.transform.gameObject.GetComponent<TileScript>().rowIndex;
										targetColIndex = hit.transform.gameObject.GetComponent<TileScript>().colIndex;
										TileManagerScript.Instance.GeneratePath(rowIndex, colIndex, targetRowIndex, targetColIndex, ref moveGridList);
										canMove = false;
										showChecking = false;
										currentTile.GetComponent<PlaceTower>().tower = null;
										currentTile = hit.transform.gameObject;
										canShoot = false;
										isMoving = true;

										indicator = (GameObject)Instantiate(movingIndicator, currentTile.transform.gameObject.transform.position, Quaternion.identity);
									}
								}
							}
						}
					}
				}
			}
		}

		if(hit)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(hit.transform.gameObject.CompareTag("Tile"))
				{
					if(hit.transform.gameObject.GetComponent<TileScript>().type == TileScript.Type.PLATFORM && hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
					{
						Deactivate();
						deselectTower = true;
					}
				}
				else if(hit.transform.gameObject.CompareTag("Core"))
				{
					if(hit.transform.gameObject.GetComponent<TileScript>().type == TileScript.Type.PLATFORM && hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
					{
						Deactivate();
						deselectTower = true;
					}
				}
			}
		}

		if(showChecking)
		{
			if(hit)
			{
				if(hit.transform.gameObject.CompareTag("Tile"))
				{
					if(this.gameObject.GetComponent<TowerData>().platform == Platform.PLATFORM_01)
					{
						if(hit.transform.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM01)
						{
							if(hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
							{
								hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
							}
							else
							{
								hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
							}
						}
						else if(hit.transform.gameObject.GetComponent<TileScript>().type != TileScript.Type.PATH)
						{
							hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
						}
					}

					else if(this.gameObject.GetComponent<TowerData>().platform == Platform.PLATFORM_02)
					{
						if(hit.transform.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM02)
						{
							if(hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
							{
								hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
							}
							else
							{
								hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
							}
						}
						else if(hit.transform.gameObject.GetComponent<TileScript>().type != TileScript.Type.PATH)
						{
							hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
						}
					}

					else if(this.gameObject.GetComponent<TowerData>().platform == Platform.PLATFORM_03)
					{
						if(hit.transform.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM03)
						{
							if(hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
							{
								hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
							}
							else
							{
								hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
							}
						}
						else if(hit.transform.gameObject.GetComponent<TileScript>().type != TileScript.Type.PATH)
						{
							hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
						}
					}

					else if(this.gameObject.GetComponent<TowerData>().platform == Platform.PLATFORM_04)
					{
						if(hit.transform.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM04)
						{
							if(hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
							{
								hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
							}
							else
							{
								hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
							}
						}
						else if(hit.transform.gameObject.GetComponent<TileScript>().type != TileScript.Type.PATH)
						{
							hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
						}
					}

					else if(this.gameObject.GetComponent<TowerData>().platform == Platform.PLATFORM_05)
					{
						if(hit.transform.gameObject.GetComponent<TileScript>().platform == TileScript.Platform.PLATOFORM05)
						{
							if(hit.transform.gameObject.GetComponent<PlaceTower>().tower == null)
							{
								hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
							}
							else
							{
								hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
							}
						}
						else if(hit.transform.gameObject.GetComponent<TileScript>().type != TileScript.Type.PATH)
						{
							hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
						}
					}

					if(hit.transform.gameObject.GetComponent<PlaceTower>().tower == this.gameObject)
					{							
						hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
					}
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Deactivate();
			deselectTower = true;
			guiManager.UnselectEverything();
		}
	}

	public void Deactivate()
	{
		showChecking = false;
		canMove = false;
	}

	public void Activate()
	{
		guiManager.selectedGO = this.gameObject;
		GUIManagerScript.Instance.UpdateSelectedInfo();
		deselectTower = false;
		canMove = true;
		showChecking = true;
	}
}
