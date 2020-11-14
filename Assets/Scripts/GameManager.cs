using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Net;

public class GameManager : NetworkBehaviour
{
    public float minX = -7.5f;

    void Update()
    {
        Tile[] tiles = FindObjectsOfType<Tile>();
        Tower[] towers = FindObjectsOfType<Tower>();
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        // Remove enemies
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i];

            // Loop through bullets
            for (int j = 0; j < bullets.Length; j++)
            {
                Bullet bullet = bullets[j];

                // If enemy collides bullet, remove bullet and enemy
                if (enemy.GetComponent<Collider2D>().bounds.Intersects(bullet.GetComponent<Collider2D>().bounds))
                {
                    Destroy(enemy.gameObject);
                    Destroy(bullet.gameObject);
                }
            }

            // Loop through towers
            for (int j = 0; j < towers.Length; j++)
            {
                Tower tower = towers[j];

                // If enemy collides tower, remove tower
                if (enemy.GetComponent<Collider2D>().bounds.Intersects(tower.GetComponent<Collider2D>().bounds))
                {
                    Destroy(tower.gameObject);
                }
            }
        }

        // End game
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i];
            if (enemy.transform.position.x < minX)
            {
                // TODO: remove health/end game
                Destroy(enemy.gameObject);
            }
        }
    }
}
