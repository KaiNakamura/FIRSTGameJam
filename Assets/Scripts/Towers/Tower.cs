using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public int cost;
    public float fireRate;
    public GameObject bullet;
    public float runTime = 0;

    private bool mouseOver;
    
    public virtual void Update()
    {
        runTime += Time.deltaTime;
        
        // Fire a bullet
        if (runTime >= 1 / fireRate)
        {
            Bullet currentBullet = Shoot();
            runTime = 0f;
        }
    }

    // Create 'Bullet' Game Object
    public virtual Bullet Shoot()
    {
        // Create bullet Game Object
        Bullet currentBullet = Instantiate(
            bullet,
            transform.position,
            Quaternion.identity
        ).GetComponent<Bullet>();
        currentBullet.transform.SetParent(this.transform);
        return currentBullet;
    }

    public void OnMouseEnter()
    {
        Debug.Log("YEKJ");
        mouseOver = true;
    }

    public void OnMouseExit()
    {
        mouseOver = false;
    }

    public bool isMouseOver()
    {
        return mouseOver;
    }
}
