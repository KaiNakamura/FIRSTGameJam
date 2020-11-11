using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTower : Tower
{
    public Vector3 velocity = new Vector3(5, 0, 0);
    public float lifespan;

    public override void Update()
    {
        base.Update();
    }

    public override Bullet Shoot()
    {
        Bullet currentBullet = base.Shoot();

        // Set fields for the bullet
        currentBullet.velocity = velocity;
        currentBullet.lifespan = lifespan;
        return currentBullet;
    }
}
