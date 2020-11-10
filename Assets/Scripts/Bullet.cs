using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(speed * Time.deltaTime + transform.position.x, transform.position.y, transform.position.z);
    }
}
