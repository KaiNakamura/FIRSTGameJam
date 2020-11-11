using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool mouseOver;

    void update()
    {

    }
    void OnMouseEnter()
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
}
