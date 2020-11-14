using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalTower : Tower
{
    // Fields specific to this tower
    public Vector3[] velocities = new Vector3[] {
        new Vector3(0, 5, 0),
        new Vector3(0, -5, 0)
    };
    public float lifespan = 0.2f;

    public override void Update()
    {
        base.Update();
    }

    public override Bullet Shoot()
    {
        // Shoot multiple bullets
        Bullet currentBullet = null;

        for (int i = 0; i < velocities.Length; i++)
        {
            currentBullet = base.Shoot();
            
            // Change the current bullet's fields
            currentBullet.velocity = velocities[i];
            currentBullet.lifespan = lifespan;
        }
        return currentBullet;
    }
}
