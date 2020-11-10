using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Tower tower;

    private bool mouseOver;

    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Random.value > 0.5 ? Color.gray : Color.white);
    }

    void Update()
    {
        
    }

    void OnMouseOver()
    {
        mouseOver = true;
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }

    public bool isMouseOver()
    {
        return mouseOver;
    }

    public Tower GetTower()
    {
        return tower;
    }

    public void SetTower(Tower tower)
    {
        this.tower = tower;
    }
}
