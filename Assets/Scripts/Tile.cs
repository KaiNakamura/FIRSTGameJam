using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Random.value > 0.5 ? Color.gray : Color.white);
    }

    void Update()
    {
        
    }
}
