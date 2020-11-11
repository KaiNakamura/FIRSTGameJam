using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobBullet : Bullet
{
    public float range;
    public Tile tile;
    private float lobDistance;
    private Vector3 initPos;
    private Vector3 endPos;

    void Start()
    {
        lobDistance = tile.transform.localScale.x * range;
        initPos = transform.position;
        endPos = new Vector3(initPos.x + lobDistance, initPos.y, initPos.z);
    }

    void Update()
    {
        base.BaseUpdate();
        transform.position = MathParabola.Parabola(initPos, endPos, 2f * (range / 8f), runTime / lifespan);
    }
}
