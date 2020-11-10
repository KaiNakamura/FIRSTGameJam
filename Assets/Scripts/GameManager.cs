using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tiles tiles;
    public EnemySpawner enemySpawner;

    public GameObject tower;

    public float minX = -7.5f;

    void Start()
    {
        
    }

    void Update()
    {
        // Place towers
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < tiles.rows; i++)
            {
                for (int j = 0; j < tiles.cols; j++)
                {
                    Tile currentTile = tiles.GetTiles()[i, j];
                    if (currentTile.isMouseOver() && currentTile.GetTower() == null)
                    {
                        Tower currentTower = Instantiate(
                            tower,
                            new Vector3(
                                currentTile.transform.position.x,
                                currentTile.transform.position.y,
                                -1
                            ),
                            Quaternion.identity
                        ).GetComponent<Tower>();
                        currentTower.transform.SetParent(currentTile.transform);
                        currentTile.SetTower(currentTower);
                    }
                }
            }
        }

        // Remove towers
        for (int i = 0; i < tiles.rows; i++)
        {
            for (int j = 0; j < tiles.cols; j++)
            {
                Tile currentTile = tiles.GetTiles()[i, j];
                Tower currentTower = currentTile.GetTower();
                if (currentTower != null)
                {
                    for (int k = 0; k < enemySpawner.transform.childCount; k++)
                    {
                        Enemy currentEnemy = enemySpawner.transform.GetChild(k).gameObject.GetComponent<Enemy>();
                        Collider2D enemyCollider = currentEnemy.GetComponent<Collider2D>();
                        Collider2D towerCollider = currentTower.GetComponent<Collider2D>();
                        if (enemyCollider.bounds.Intersects(towerCollider.bounds))
                        {
                            Destroy(currentEnemy.gameObject);
                            Destroy(currentTower.gameObject);
                        }
                    }
                }
            }
        }

        // End game
        for (int i = 0; i < enemySpawner.transform.childCount; i++)
        {
            Enemy currentEnemy = enemySpawner.transform.GetChild(i).gameObject.GetComponent<Enemy>();
            if (currentEnemy.transform.position.x < minX)
            {
                // TODO: remove health/end game
                Destroy(currentEnemy.gameObject);
            }
        }
    }
}
