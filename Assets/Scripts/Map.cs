using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, IMap
{
    private int size;
    public class Point: IMapItem
    {
        public Vector2Int _position;
    
        public bool IsAvailable { get; set; }

        // for A*
        public IMapItem Last { get; set; }
        public int Cost { get; set; }

        public Point()
        {
//            Cost = size + size;
        }
    }
    
    private Point[,] _TestMap;
    private Dictionary<Point, Point[]> _map;
    
    private IMap _mapImplementation;


    // Start is called before the first frame update
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
//        _TestMap
        return _map[(Point)current];
    }

    public int GetDistance(IMapItem one, IMapItem two)
    {
        return Mathf.Abs(((Point)one)._position.x - ((Point)one)._position.x ) 
               + Mathf.Abs(((Point)one)._position.y - ((Point)one)._position.y );
    }
}
