using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertTower : Tower
{
    public GameObject[] bullets = new GameObject[2];
    void Update()
    {
        runTime += Time.deltaTime;
        if (runTime >= fireRate)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                bullet = bullets[i];
                Bullet currentBullet = Shoot();
                runTime = 0f;
            }
        }
    }
}
