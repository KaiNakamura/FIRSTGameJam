using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public int damage = 1;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(-speed * Time.deltaTime + transform.position.x, transform.position.y, transform.position.z);
    }
}
