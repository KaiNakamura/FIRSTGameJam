using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertBullet : Bullet
{
    public Vector3 velocity;

    void Update()
    {
        base.BaseUpdate();
        float y = transform.position.y + velocity.y * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, y, transform.position.z); // TODO: Figure out what Kai did
    }
}
