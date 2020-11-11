using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    public Vector3 velocity;

    void Update()
    {
        base.BaseUpdate();
        float x = transform.position.x + velocity.x * Time.deltaTime;
        transform.position = new Vector3 (x, transform.position.y, transform.position.z); // TODO: Figure out that thing Kai did
    }
}
