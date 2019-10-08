using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMapItem : IStarACalculable
{
    bool IsAvailable { get; set; }
}

public interface IMap
{
    IMapItem[] GetNeighbors(IMapItem current);
    int GetDistance(IMapItem one, IMapItem two);
}
