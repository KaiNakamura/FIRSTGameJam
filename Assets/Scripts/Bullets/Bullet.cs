using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public int damage;
    public float lifespan;
    public float runTime = 0;

    public void BaseUpdate()
    {
        runTime += Time.deltaTime;

        if (runTime >= lifespan)
        {
            Destroy(this.gameObject);
        }
    }
}
