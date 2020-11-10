using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Fields unique to 'Tower'
    public Color color = Constants.NORMAL_COLOR; //TODO: Colors
    public float fireRate = Constants.NORMAL_FIRE_RATE;

    //Fields neccessary for 'Bullet' 
    public float speed = Constants.NORMAL_SPEED;
    public int damage = Constants.NORMAL_DAMAGE;
    public int distance = Constants.NORMAL_DISTANCE; //Measured in tiles
    public Constants.Direction[] directions = Constants.NORMAL_DIRECTIONS;
    public Constants.BulletBehavhior bulletBehavhior = Constants.BulletBehavhior.NORMAL;


    private float counter = 0f;

    public GameObject bullet;

    void Start()
    {
        
    }

    void Update()
    {
        if (counter >= fireRate)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                Bullet currentBullet = Instantiate(
                    bullet,
                    transform.position,
                    Quaternion.identity
                ).GetComponent<Bullet>();
                currentBullet.transform.SetParent(this.transform);
                currentBullet.SetSpeed(speed);
                currentBullet.SetDamage(damage);
                currentBullet.SetDistance(distance);
                currentBullet.SetDirection(directions[i]);
                currentBullet.SetBulletBehavhior(bulletBehavhior);
            }

            counter = 0f;
        }

        counter += Time.deltaTime;
    }

    public void SetFireRate(float fireRate)
    {
        this.fireRate = fireRate;
    }

    public void SetDirections(Constants.Direction[] directions)
    {
        this.directions = directions;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetBulletBehavhior(Constants.BulletBehavhior bulletBehavhior)
    {
        this.bulletBehavhior = bulletBehavhior;
    }

    public void SetDistance(int distance)
    {
        this.distance = distance;
    }
}
