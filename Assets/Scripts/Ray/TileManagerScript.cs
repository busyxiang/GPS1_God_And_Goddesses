using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TileManagerScript : MonoBehaviour 
{
	private static TileManagerScript mInstance;

	public static TileManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("TileManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_TileManager");
					mInstance = obj.AddComponent<TileManagerScript>();
					obj.tag = "TileManager";
				}
				else
				{
					mInstance = tempObject.GetComponent<TileManagerScript>();
				}
			}
			return mInstance;
		}
	}

	int[,] map;
	public const int ROW_COUNT = 9;
	public const int COL_COUNT = 20;

	public int rowCount;
	public int colCount;

	public GameObject tilePrefab;
	public List<GameObject> platform01;
	public List<GameObject> platform02;
	public List<GameObject> platform03;
	public List<GameObject> platform04;
	public List<GameObject> platform05;
	public List<GameObject> goTileList;

	public List<TileScript> tileList = new List<TileScript>();

	public int towerPlatform1 = 1;
	public int towerPlatform2 = 1;
	public int towerPlatform3 = 1;
	public int towerPlatform4 = 1;
	public int towerPlatform5 = 1;
	public int maxTower = 3;

	public bool platform01Checking()
	{
		int count = 0;

		for(int i = 0; i<platform01.Count; i++)
		{
			if(platform01[i].GetComponent<PlaceTower>().tower != null)
			{
				if(count + 1 >= towerPlatform1)
				{
					return false;					
				}
				count += 1;
			}
		}
		return true;
	}

	public bool platform02Checking()
	{
		int count = 0;

		for(int i = 0; i<platform02.Count; i++)
		{
			if(platform02[i].GetComponent<PlaceTower>().tower != null)
			{
				if(count + 1 >= towerPlatform2)
				{
					return false;			
				}

				count += 1;
			}
		}
		return true;
	}

	public bool platform03Checking()
	{
		int count = 0;

		for(int i = 0; i<platform03.Count; i++)
		{
			if(platform03	[i].GetComponent<PlaceTower>().tower != null)
			{
				if(count + 1 >= towerPlatform3)
				{
					return false;			
				}

				count += 1;
			}
		}
		return true;
	}

	public bool platform04Checking()
	{
		int count = 0;

		for(int i = 0; i<platform04.Count; i++)
		{
			if(platform04[i].GetComponent<PlaceTower>().tower != null)
			{
				if(count + 1 >= towerPlatform4)
				{
					return false;			
				}

				count += 1;
			}
		}
		return true;
	}

	public bool platform05Checking()
	{
		int count = 0;

		for(int i = 0; i<platform05.Count; i++)
		{
			if(platform05[i].GetComponent<PlaceTower>().tower != null)
			{
				if(count + 1 >= towerPlatform5)
				{
					return false;			
				}

				count += 1;
			}
		}
		return true;
	}

	// Use this for initialization
	void Start ()
	{
		//RandomizeMap();
		InitializeMap();

		for (int i = 0; i < rowCount; i++) 
		{
			for ( int j = 0; j < colCount; j++)
			{
				TileScript tempTileScript = ((GameObject)Instantiate(tilePrefab, new Vector3(j*0.64f+3.92f - colCount/2, rowCount/2 - i*0.64f - 0.72f, 0.0f), Quaternion.identity)).GetComponent<TileScript>();
				tempTileScript.transform.parent = transform;

				if(map[i,j] == 0)
				{
					tempTileScript.type = TileScript.Type.NONE;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[0];
				}
				else if(map[i,j] == 1)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[1];
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 2)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[2];
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 3)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[3];
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 4)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[4];
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 5)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[5];
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 6)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[6];
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 7)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[7];
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 8)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[8];
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 9)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[9];
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 10)
				{
					tempTileScript.type = TileScript.Type.PATH;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[10];
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 21)
				{
					tempTileScript.type = TileScript.Type.PLATFORM;
					tempTileScript.platform = TileScript.Platform.PLATOFORM01;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[11];
					platform01.Add(tempTileScript.gameObject);
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 22)
				{
					tempTileScript.type = TileScript.Type.PLATFORM;
					tempTileScript.platform = TileScript.Platform.PLATOFORM01;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[12];
					platform01.Add(tempTileScript.gameObject);
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 31)
				{
					tempTileScript.type = TileScript.Type.PLATFORM;
					tempTileScript.platform = TileScript.Platform.PLATOFORM02;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[11];
					platform02.Add(tempTileScript.gameObject);
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 32)
				{
					tempTileScript.type = TileScript.Type.PLATFORM;
					tempTileScript.platform = TileScript.Platform.PLATOFORM02;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[12];
					platform02.Add(tempTileScript.gameObject);
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 41)
				{
					tempTileScript.type = TileScript.Type.PLATFORM;
					tempTileScript.platform = TileScript.Platform.PLATOFORM03;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[11];
					platform03.Add(tempTileScript.gameObject);
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 42)
				{
					tempTileScript.type = TileScript.Type.PLATFORM;
					tempTileScript.platform = TileScript.Platform.PLATOFORM03;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[12];
					platform03.Add(tempTileScript.gameObject);
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 51)
				{
					tempTileScript.type = TileScript.Type.PLATFORM;
					tempTileScript.platform = TileScript.Platform.PLATOFORM04;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[11];
					platform04.Add(tempTileScript.gameObject);
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 52)
				{
					tempTileScript.type = TileScript.Type.PLATFORM;
					tempTileScript.platform = TileScript.Platform.PLATOFORM04;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[12];
					platform04.Add(tempTileScript.gameObject);
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 61)
				{
					tempTileScript.type = TileScript.Type.PLATFORM;
					tempTileScript.platform = TileScript.Platform.PLATOFORM05;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[11];
					platform05.Add(tempTileScript.gameObject);
					goTileList.Add(tempTileScript.gameObject);
				}
				else if(map[i,j] == 62)
				{
					tempTileScript.type = TileScript.Type.PLATFORM;
					tempTileScript.platform = TileScript.Platform.PLATOFORM05;
					tempTileScript.spriteRenderer.sprite = tempTileScript.spriteList[12];
					platform05.Add(tempTileScript.gameObject);
					goTileList.Add(tempTileScript.gameObject);
				}

				tempTileScript.rowIndex = i;
				tempTileScript.colIndex = j;

				tileList.Add(tempTileScript);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	

	void RandomizeMap()
	{
		map = new int[rowCount, colCount];

		for (int i = 0; i < rowCount; i++) 
		{
			for ( int j = 0; j < colCount; j++)
			{
				map[i,j] = Random.Range(0,2);
			}
		}
	}

	void InitializeMap()
	{
		string levelName = SceneManager.GetActiveScene().name;

		switch(levelName)
		{
		case "TutorialLevel":
			map = new int[ROW_COUNT,COL_COUNT]
			{
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,0,61,61,61,	0,0,0,32,32,	32,32,32,32,32},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,32,31,	31,31,31,31,31},
				{0,0,0,31,31,	31,31,31,31,31,	32,0,0,32,5,	1,1,1,1,1},
				{0,0,0,1,1,	1,1,1,1,6,	32,0,0,32,2,	22,22,22,22,22},
				{0,0,0,22,22,	22,22,22,22,2,	31,31,31,31,2,	22,22,22,22,22},
				{0,0,0,21,21,	21,21,21,22,3,	1,1,1,1,4,	22,21,21,21,21},
				{0,0,0,0,0,	0,0,0,21,21,	21,21,21,21,21,	21,0,0,0,0},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0}
			};
			break;
		case "Level_1":
			map = new int[ROW_COUNT,COL_COUNT]
			{
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,32,32,	32,32,32,32,32,	32,32,0,0,0,	32,5,1,1,1},
				{0,0,0,6,32,	32,5,1,1,1,	6,32,0,0,0,	32,2,22,22,22},
				{0,52,52,2,32,	32,2,42,42,42,	2,32,0,0,0,	32,2,22,22,22},
				{0,52,52,2,32,	32,2,42,42,42,	2,31,31,31,31,	31,2,22,22,22},
				{0,52,52,2,32,	32,2,42,42,42,	3,1,1,1,1,	1,4,21,21,21},
				{0,52,52,2,31,	31,2,42,42,42,	42,42,0,0,0,	0,0,0,0,0},
				{0,51,51,3,1,	1,4,41,41,41,	41,41,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
			};
			break;
		case "Level_2":
			map = new int[ROW_COUNT,COL_COUNT]
			{
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,5,1,1,1,	1,6,0,0,0,	0,0,0,0,0},
				{0,0,0,1,1,	9,4,32,32,32,	32,2,0,0,5,	1,1,1,1,1},
				{0,2,42,42,42,	2,32,32,32,32,	32,3,1,1,8,	22,22,22,22,22},
				{0,2,42,42,42,	2,32,32,32,32,	32,32,32,32,2,	22,22,22,22,22},
				{0,2,42,42,42,	2,32,32,32,31,	31,31,31,31,2,	22,22,22,22,22},
				{0,2,42,42,42,	2,32,32,32,5,	1,1,1,1,8,	21,21,21,21,21},
				{0,2,41,41,41,	2,31,31,31,2,	0,0,0,0,3,	1,1,1,1,1},
				{0,3,1,1,1,	10,1,1,1,4,	0,0,0,0,0,	0,0,0,0,0}
			};
			break;
		case "Level_3":
			map = new int[ROW_COUNT,COL_COUNT]
			{
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0},
				{0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0,	0,0,0,0,0}
			};
			break;
		}

		rowCount = map.GetLength(0);
		colCount = map.GetLength(1);
	}

	public void DeactiavtePlaceTower()
	{
		for(int i=0; i<goTileList.Count; i++)
		{
			goTileList[i].GetComponent<PlaceTower>().enabled = false;
		}
	}

	public void SelectPlatform01()
	{
		for(int i=0; i<platform01.Count; i++)
		{
			platform01[i].GetComponent<SpriteRenderer>().color = new Color32(70,190,249,255);
			platform01[i].GetComponent<PlaceTower>().returnNormal = false;
		}
	}

	public void SelectPlatform02()
	{
		for(int i=0; i<platform02.Count; i++)
		{
			platform02[i].GetComponent<SpriteRenderer>().color = new Color32(70,190,249,255);
			platform02[i].GetComponent<PlaceTower>().returnNormal = false;
		}
	}

	public void SelectPlatform03()
	{
		for(int i=0; i<platform03.Count; i++)
		{
			platform03[i].GetComponent<SpriteRenderer>().color = new Color32(70,190,249,255);
			platform03[i].GetComponent<PlaceTower>().returnNormal = false;
		}
	}

	public void SelectPlatform04()
	{
		for(int i=0; i<platform04.Count; i++)
		{
			platform04[i].GetComponent<SpriteRenderer>().color = new Color32(70,190,249,255);
			platform04[i].GetComponent<PlaceTower>().returnNormal = false;
		}
	}

	public void SelectPlatform05()
	{
		for(int i=0; i<platform05.Count; i++)
		{
			platform05[i].GetComponent<SpriteRenderer>().color = new Color32(70,190,249,255);
			platform05[i].GetComponent<PlaceTower>().returnNormal = false;
		}
	}

	public void UnSelectPlatform01()
	{
		for(int i=0; i<platform01.Count; i++)
		{
			platform01[i].GetComponent<SpriteRenderer>().color = Color.white;
			platform01[i].GetComponent<PlaceTower>().returnNormal = true;
		}
	}

	public void UnSelectPlatform02()
	{
		for(int i=0; i<platform02.Count; i++)
		{
			platform02[i].GetComponent<SpriteRenderer>().color = Color.white;
			platform02[i].GetComponent<PlaceTower>().returnNormal = true;
		}
	}

	public void UnSelectPlatform03()
	{
		for(int i=0; i<platform03.Count; i++)
		{
			platform03[i].GetComponent<SpriteRenderer>().color = Color.white;
			platform03[i].GetComponent<PlaceTower>().returnNormal = true;
		}
	}

	public void UnSelectPlatform04()
	{
		for(int i=0; i<platform04.Count; i++)
		{
			platform04[i].GetComponent<SpriteRenderer>().color = Color.white;
			platform04[i].GetComponent<PlaceTower>().returnNormal = true;
		}
	}

	public void UnSelectPlatform05()
	{
		for(int i=0; i<platform05.Count; i++)
		{
			platform05[i].GetComponent<SpriteRenderer>().color = Color.white;
			platform05[i].GetComponent<PlaceTower>().returnNormal = true;
		}
	}

	public void ActivateBoxCollider2D()
	{
		for(int i=0; i<goTileList.Count; i++)
		{
			goTileList[i].GetComponent<BoxCollider2D>().enabled = true;

			if(goTileList[i].GetComponent<PlaceTower>().tower != null)
			{
				goTileList[i].GetComponent<PlaceTower>().tower.GetComponent<BoxCollider2D>().enabled = true;
			}
		}
	}

	public void DeactivaBoxCollider2D()
	{
		for(int i=0; i<goTileList.Count; i++)
		{
			goTileList[i].GetComponent<BoxCollider2D>().enabled = false;

			if(goTileList[i].GetComponent<PlaceTower>().tower != null)
			{
				goTileList[i].GetComponent<PlaceTower>().tower.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}

	public void GeneratePath(int startRowIndex, int startColIndex, int endRowIndex, int endColIndex, ref List<Vector3> moveGridList)
	{
		if(AStarPathScript.gridMap != null)
		{
			AStarPathScript.gridMap.Clear();
		}
		else
		{
			AStarPathScript.gridMap = new List<List<bool>>();
		}

		for(int i = 0; i < rowCount; i++)
		{
			List<bool> boolList = new List<bool>();

			for(int j = 0; j < colCount; j++)
			{
				boolList.Insert(j, false);
			}
			AStarPathScript.gridMap.Insert(i, boolList);
		}

		for(int i = 0; i < tileList.Count; i++)
		{
			if(tileList[i].type == TileScript.Type.PLATFORM)
			{
				AStarPathScript.gridMap[tileList[i].rowIndex][tileList[i].colIndex] = true;
			}
		}

		if(AStarPathScript.startIndex == null)
		{
			AStarPathScript.startIndex = new NodeIndex();
		}
		AStarPathScript.startIndex.i = startRowIndex;
		AStarPathScript.startIndex.j = startColIndex;

		if(AStarPathScript.endIndex == null)
		{
			AStarPathScript.endIndex = new NodeIndex();
		}
		AStarPathScript.endIndex.i = endRowIndex;
		AStarPathScript.endIndex.j = endColIndex;

		/*for(int i = 0; i < rowCount; i++)
		{
			List<bool> boolList = new List<bool>();

			for(int j = 0; j < colCount; j++)
			{
				if(map[i,j] == 1)
				{
					boolList.Insert(j, true);
				}
				else if(map[i,j] == 88)
				{
					if(AStarPathScript.startIndex == null)
					{
						AStarPathScript.startIndex = new NodeIndex();
					}
					AStarPathScript.startIndex.i = i;
					AStarPathScript.startIndex.j = j;
					boolList.Insert(j, true);
				}
				else if(map[i,j] == 99)
				{
					if(AStarPathScript.endIndex == null)
					{
						AStarPathScript.endIndex = new NodeIndex();
					}
					AStarPathScript.endIndex.i = i;
					AStarPathScript.endIndex.j = j;
					boolList.Insert(j, true);
				}
				else
				{
					boolList.Insert(j, false);
				}
			}
			AStarPathScript.gridMap.Insert(i, boolList);
		}*/

		AStarPathScript.heuristicType = AStarPathScript.HEURISTIC_METHODS.MANHATTAN;
		AStarPathScript.FindPath();

		if(AStarPathScript.isPathFound)
		{
			for(int i=0; i<AStarPathScript.pathNodes.Count; i++)
			{
				Vector3 nodePos = new Vector3(AStarPathScript.pathNodes[i].nodeIndex.j*0.64f+3.92f - colCount/2, rowCount/2 - AStarPathScript.pathNodes[i].nodeIndex.i*0.64f - 0.72f, 0.0f);
				//Instantiate(pathPrefab, new Vector3(1.0f * AStarPathScript.pathNodes[i].nodeIndex.j, 2.0f, -1.0f * AStarPathScript.pathNodes[i].nodeIndex.i) - new Vector3(1.0f * mapColCount / 2 - 0.5f, 0.0f, -1.0f * mapRowCount / 2 + 0.5f), Quaternion.identity);

				moveGridList.Add(nodePos);
			}
		}
	}
}
