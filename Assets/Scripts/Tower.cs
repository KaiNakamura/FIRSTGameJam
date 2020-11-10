using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fireRate = 0.25f;
    private float counter = 0f;

    public GameObject bullet;

    void Start()
    {
        
    }

    void Update()
    {
        if (counter >= fireRate)
        {
            Bullet currentBullet = Instantiate(
                bullet,
                transform.position,
                Quaternion.identity
            ).GetComponent<Bullet>();
            currentBullet.transform.SetParent(this.transform);

            counter = 0f;
        }

        counter += Time.deltaTime;
    }
}
