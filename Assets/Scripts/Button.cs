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
        Debug.Log(mouseOver + ", Mouse Enter");
    }

    void OnMouseExit()
    {
        mouseOver = false;
        Debug.Log(mouseOver + ", MouseExit");
    }

    public bool isMouseOver()
    {
        return mouseOver;
    }
}
