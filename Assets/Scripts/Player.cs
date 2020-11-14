using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public GameObject towerGameObject;

    void Update()
    {
        Tile[] tiles = FindObjectsOfType<Tile>();

        if (isLocalPlayer)
        {
            // Create towers on click
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < tiles.Length; i++)
                {
                    Tile tile = tiles[i];
                    if (tile.mouseOver && tile.tower == null)
                    {
                        CreateTower(tile.gameObject);
                    }
                }
            }
        }
    }

    [Command]
    void CreateTower(GameObject tileGameObject)
    {
        Tower tower = Instantiate(
            towerGameObject,
            new Vector3(
                tileGameObject.transform.position.x,
                tileGameObject.transform.position.y,
                -1
            ),
            Quaternion.identity
        ).GetComponent<Tower>();
        tileGameObject.GetComponent<Tile>().tower = tower;

        NetworkServer.Spawn(tower.gameObject);
    }
}
