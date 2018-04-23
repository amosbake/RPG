using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField]
	private Texture2D[] mapData;
	[SerializeField]
	private MapElement[] mapElements;
	[SerializeField]
	private Sprite defaultTile;
	[SerializeField]
	private Transform map;

	private Vector3 WorldStartPos
	{
		get { return Camera.main.ScreenToWorldPoint(new Vector3(0, 0)); }
	}

	// Use this for initialization
	void Start ()
	{
		GerenrateMap();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GerenrateMap()
	{
		for (int i = 0; i < mapData.Length; i++)
		{
			for (int x = 0; x < mapData[i].width; x++)
			{
				for (int y = 0; y < mapData[i].height; y++)
				{
					float xPos = WorldStartPos.x + (defaultTile.bounds.size.x * x);
					float yPos = WorldStartPos.x + (defaultTile.bounds.size.y * y);
					
					Color c = mapData[i].GetPixel(x, y);
					Debug.Log(c);
					MapElement mapElement = Array.Find(mapElements, e => e.Color == c);
					if (mapElement != null)
					{
						GameObject go = Instantiate(mapElement.ElementPrefab, new Vector2(xPos,yPos),Quaternion.identity);
						go.transform.parent = map;
						
					}
				}
			}
		}
	}
	
	
}

[System.Serializable]
public class MapElement
{
	[SerializeField]
	private string tileTag;
	[SerializeField]
	private Color color;
	[SerializeField]
	private GameObject elementPrefab;

	public GameObject ElementPrefab
	{
		get { return elementPrefab; }
	}

	public Color Color
	{
		get { return color; }
	}

	public string TileTag
	{
		get { return tileTag; }
	}
}