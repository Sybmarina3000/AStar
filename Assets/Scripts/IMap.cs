using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMapItem : IStarACalculable
{
    Vector2Int Position { get; set; }
    bool IsPassable { get; set; }
}

public interface IMap
{
    IMapItem[,] Create( int size);
    
    IMapItem[] GetNeighbors(IMapItem current);
    int GetDistance(IMapItem one, IMapItem two);
}
