using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage;
    public int distance; //Measured in tiles
    public Constants.Direction direction;
    public Constants.BulletBehavhior bulletBehavhior;

    
    public Tile tile;
    
    private float longevity = 0.2f; //Time to move 1 square (roughly)

    private float duration;
    
    private float lobDistance; //Measured in whatever units the 3D Unity editor uses
    private Vector3 initPos;
    private Vector3 endPos;

    void Start()
    {
        lobDistance = tile.transform.localScale.x * distance;
        initPos = transform.position;
        endPos = new Vector3(initPos.x + lobDistance, initPos.y, initPos.z);
    }

    void Update()
    {
        duration += Time.deltaTime;
        
        if (duration >= longevity * distance)
        {
            Destroy(this.gameObject);
        }

        //Lobbed Shots
        if (bulletBehavhior == Constants.BulletBehavhior.LOB)
        {
            transform.position = MathParabola.Parabola(initPos, endPos, 2f * (distance / 8f), duration / (longevity * distance));
            return;
        }


        //Bullet Directionality
        if (direction == Constants.Direction.NORTH)
        {
            transform.position = new Vector3(transform.position.x, GetMoveUp(), transform.position.z);
        }
        else if (direction == Constants.Direction.NORTH_EAST)
        {
            transform.position = new Vector3(GetMoveRight(), GetMoveUp(), transform.position.z);
        }
        else if (direction == Constants.Direction.EAST)
        {
            transform.position = new Vector3(GetMoveRight(), transform.position.y, transform.position.z);
        }
        else if (direction == Constants.Direction.SOUTH_EAST)
        {
            transform.position = new Vector3(GetMoveRight(), GetMoveDown(), transform.position.z);
        }
        else if (direction == Constants.Direction.SOUTH)
        {
            transform.position = new Vector3(transform.position.x, GetMoveDown(), transform.position.z);
        }
        else if (direction == Constants. Direction.SOUTH_WEST)
        {
            transform.position = new Vector3(GetMoveLeft(), GetMoveDown(), transform.position.z);
        }
        else if (direction == Constants.Direction.WEST)
        {
            transform.position = new Vector3(GetMoveLeft(), transform.position.y, transform.position.z);
        }
        else if (direction == Constants.Direction.NORTH_WEST)
        {
            transform.position = new Vector3(GetMoveLeft(), GetMoveUp(), transform.position.z);
        } 
    }

    public void SetDirection(Constants.Direction direction)
    {
        this.direction = direction;
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

    private float GetMoveUp()
    {
        return speed * Time.deltaTime + transform.position.y;
    }

    public float GetMoveDown()
    {
        return -speed * Time.deltaTime + transform.position.y;
    }

    public float GetMoveLeft()
    {
        return -speed * Time.deltaTime + transform.position.x;
    }

    public float GetMoveRight()
    {
        return speed * Time.deltaTime + transform.position.x;
    }
    
}

