using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public int rows = 6;
    public int cols = 8;

    public GameObject[,] tiles;
    public GameObject tile;

    void Start()
    {
        tiles = new GameObject[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                float tileWidth = tile.transform.localScale.x;
                float tileHeight = tile.transform.localScale.y;

                float offsetX = (tileWidth * (cols - 1)) / 2f;
                float offsetY = (tileHeight * (rows - 1)) / 2f;

                Instantiate(
                    tile,
                    new Vector3(
                        j * tileWidth - offsetX,
                        i * tileHeight - offsetY,
                        0
                    ),
                    Quaternion.identity
                ).transform.SetParent(this.transform);
            }
        }
    }

    void Update()
    {
        
    }
}
