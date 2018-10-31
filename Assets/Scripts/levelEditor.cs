using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEditor : MonoBehaviour {

    public Texture2D map;
    public colorToPrefab[] colorMappings;

    void Start () {
        GenerateLevel();
	}
	
    void GenerateLevel()
    {
        for(int x = 0;x < map.width; x++)
        {
            for(int y = 0;y < map.height; y++)
            {
                GenerateTile(x,y);
            }
        }
    }

    void GenerateTile(int x,int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        if(pixelColor.a == 0)
        {
            return;
        }

        foreach (colorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.myPrefab, position, Quaternion.identity,transform);
            }
        }
    }
}
