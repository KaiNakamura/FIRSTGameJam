using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Universal script for every bullet
public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public float lifespan;
    [HideInInspector]
    public Vector3 velocity;
    [HideInInspector]
    public float runTime = 0;

    public virtual void Update()
    {
        // Destroy bullet at end of lifetime
        runTime += Time.deltaTime;

        if (runTime >= lifespan)
        {
            Destroy(this.gameObject);
        }

        // Add velocity to the position
        transform.position = transform.position + velocity * Time.deltaTime;
    }
}
