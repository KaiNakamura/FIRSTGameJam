using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TileSpawner : NetworkBehaviour
{
    public int rows = 6;
    public int cols = 8;

    public float tileHeight = 1f;
    public float tileWidth = 1f;

    public GameObject tileGameObject;

    public float[] spawnLocations;

    public override void OnStartServer()
    {
        spawnLocations = new float[rows];

        for (int i = 0; i < rows; i++)
        {
            float offsetY = (tileHeight * (rows - 1)) / 2f;
            float y = i * tileHeight - offsetY;

            spawnLocations[i] = y;
            for (int j = 0; j < cols; j++)
            {
                float offsetX = (tileWidth * (cols - 1)) / 2f;
                float x = j * tileWidth - offsetX;

                Tile tile = Instantiate(
                    tileGameObject,
                    new Vector3(
                        x,
                        y,
                        0
                    ),
                    Quaternion.identity
                ).GetComponent<Tile>();

                NetworkServer.Spawn(tile.gameObject);
            }
        }
    }
}
