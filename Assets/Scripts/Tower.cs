using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Tower : NetworkBehaviour
{
    public float fireRate = 0.25f;
    private float counter = 0f;

    public GameObject bullet;

    void Update()
    {
        if (counter >= fireRate)
        {
            Bullet currentBullet = Instantiate(
                bullet,
                transform.position,
                Quaternion.identity
            ).GetComponent<Bullet>();
            // currentBullet.transform.SetParent(this.transform);

            counter = 0f;
        }

        counter += Time.deltaTime;
    }
}
