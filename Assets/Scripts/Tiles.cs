﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public int rows = 6;
    public int cols = 8;
    
    private float[] spawnLocations; 

    public GameObject[,] tiles;
    public GameObject tile;

    void Start()
    {
        tiles = new GameObject[rows, cols];
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

                Instantiate(
                    tile,
                    new Vector3(
                        x,
                        y,
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
    
    public float[] getSpawnLocations()
    {
        return spawnLocations; 
    }
}