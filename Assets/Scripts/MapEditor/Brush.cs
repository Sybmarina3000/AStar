using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETypeBrush
{
    empty,
    impassable,
    start,
    finish,
}

public class Brush : Singleton<Brush>
{
    public ETypeBrush CurrentBrush { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentBrush = ETypeBrush.impassable;
    }


    public void ChangeBrush(ETypeBrush newBrush)
    {
        CurrentBrush = newBrush;
    }
    
    public void ChangeBrush(int newBrush)
    {
        CurrentBrush = (ETypeBrush)newBrush;
    }
}
