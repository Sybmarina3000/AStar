using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class IMapItem //: //IStarACalculable
{
    public Vector2Int Position { get; set; }
    public bool IsPassable { get; set; }
    
    public IMapItem Last { get; set; }
    public int Cost { get; set; }
}

[Serializable]
public abstract class IMap : MonoBehaviour
{
    public abstract IMapItem[] Create( int size);
    
    public abstract IMapItem[] GetNeighbors(IMapItem current);
    public abstract int GetDistance(IMapItem one, IMapItem two);
}
