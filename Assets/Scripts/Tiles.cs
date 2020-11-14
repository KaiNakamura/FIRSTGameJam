using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public int rows = 6;
    public int cols = 8;

    private float[] spawnLocations;

    public Tile[,] tiles;
    public GameObject tile;

    void Start()
    {
        tiles = new Tile[rows, cols];
        spawnLocations = new float[rows];

        for (int i = 0; i < rows; i++)
        {
            float tileHeight = tile.transform.localScale.y;
            float offsetY = (tileHeight * (rows - 1)) / 2f;
            float y = i * tileHeight - offsetY;

            spawnLocations[i] = y;
            for (int j = 0; j < cols; j++)
            {
                float tileWidth = tile.transform.localScale.x;
                float offsetX = (tileWidth * (cols - 1)) / 2f;
                float x = j * tileWidth - offsetX;

                Tile currentTile = Instantiate(
                    tile,
                    new Vector3(
                        x,
                        y,
                        0
                    ),
                    Quaternion.identity
                ).GetComponent<Tile>();
                currentTile.transform.SetParent(this.transform);

                tiles[i, j] = currentTile;
            }
        }
    }

    void Update()
    {

    }

    public Tile[,] GetTiles()
    {
        return tiles;
    }

    static public int getCols()
    {
        return 8;
    }

    public float[] GetSpawnLocations()
    {
        return spawnLocations;
    }
}
