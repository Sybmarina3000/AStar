using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, IMap
{
    private int size;
    public class Point: IMapItem
    {
        public Vector2Int Position { get; set; }
        public bool IsPassable { get; set; }

        // for A*
        public IMapItem Last { get; set; }
        public int Cost { get; set; }
    }
    
    private Point[,] _TestMap;
    private Dictionary<Point, Point[]> _map;

    private
    void Start()
    {
        _TestMap = new Point[5,5];
        
        for (var i = 0; i < _TestMap.GetLength(0); i++)
        {
            for (var j = 0; j < _TestMap.GetLength(0); j++)
            {
                var point = _TestMap[i, j];
                point = new Point();
            }
        }
    }

    public IMapItem[] GetNeighbors(IMapItem current)
    {
        return _map[(Point)current];
    }

    public int GetDistance(IMapItem one, IMapItem two)
    {
        return Mathf.Abs(((Point)one).Position.x - ((Point)one).Position.x ) 
               + Mathf.Abs(((Point)one).Position.y - ((Point)one).Position.y );
    }
}
