using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    private SpriteRenderer _sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    
    void OnMouseDown()
    {
        // load a new scene
        Debug.Log("my name " + gameObject.name);
    }
    
}
