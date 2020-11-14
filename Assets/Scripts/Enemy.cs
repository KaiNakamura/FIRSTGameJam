using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Enemy : NetworkBehaviour
{
    public float speed = 1f;
    public int damage = 1;

    void Update()
    {
        transform.position = new Vector3(-speed * Time.deltaTime + transform.position.x, transform.position.y, transform.position.z);
    }
}
