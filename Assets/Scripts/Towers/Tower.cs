using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public float fireRate;
    public GameObject bullet;
    public float runTime = 0;
    
    public void BaseUpdate()
    {
        runTime += Time.deltaTime;
        if (runTime >= fireRate)
        {
            Bullet currentBullet = Shoot();
            runTime = 0f;
        }
    }

    public virtual Bullet Shoot()
    {
        Bullet currentBullet = Instantiate(
            bullet,
            transform.position,
            Quaternion.identity
        ).GetComponent<Bullet>();
        currentBullet.transform.SetParent(this.transform);
        return currentBullet;
    }
}
