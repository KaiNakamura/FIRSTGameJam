using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fireRate = 0.2f;
    public int numBullets = 1;
    public Enums.Direction[] directions;
    public Enums.BulletBehavhior bulletBehavhior = Enums.BulletBehavhior.NORMAL;
    public int distance= 1;
    private float counter = 0f;

    public GameObject bullet;

    void Start()
    {

    }

    void Update()
    {
        if (counter >= fireRate)
        {
            for (int i = 0; i < numBullets; i++)
            {
                Bullet currentBullet = Instantiate(
                    bullet,
                    transform.position,
                    Quaternion.identity
                ).GetComponent<Bullet>();
                currentBullet.transform.SetParent(this.transform);
                currentBullet.SetDirection(directions[i]);
                currentBullet.SetDistance(distance);
                currentBullet.SetBulletBehavhior(bulletBehavhior);
            }

            counter = 0f;
        }

        counter += Time.deltaTime;
    }
}
