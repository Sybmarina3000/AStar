using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class GridMap : IMap
{
    private int _size;
    
    [Serializable]
    public class Point: IMapItem 
    {
        public Vector2Int Position { get; set; }
        public bool IsPassable { get; set; }

        // for A*
        public IMapItem Last { get; set; }
        public int Cost { get; set; }

        public Point( int x, int y)
        {
            Position = new Vector2Int(x,y);
        }
    }

    private void Start()
    {
        Debug.Log("Dick " + _neighborsMap.Count);
        
    }

    private IMapItem[,] _grid;
    private Dictionary<IMapItem, IMapItem[]> _neighborsMap = new Dictionary<IMapItem, IMapItem[]>();

    private IMapEditor _EditorMap;
    
    
    [ExecuteInEditMode]
    public override IMapItem[] Create(int size)
    {
        _size = size;
        _grid = new IMapItem[size , size];
        
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                _grid[i ,j] = new Point(i,j);
                _grid[i ,j].Position = new Vector2Int(i,j);
            }
        }

        GenerateNeighborsMass();
        return _neighborsMap.Keys.ToArray();
    }

    [ExecuteInEditMode]
    private void GenerateNeighborsMass()
    {
       // _neighborsMap?.Clear();
//        _neighborsMap = new Dictionary<IMapItem, IMapItem[]>();
        
        List<IMapItem> neighbor = new List<IMapItem>();
        for (var i = 0; i < _size; i++)
        {
            for (var j = 0; j < _size; j++)
            {
                neighbor.Clear();
                if (i > 0)
                    neighbor.Add(_grid[i - 1, j]);
                if (i < _size - 1)
                    neighbor.Add(_grid[i + 1, j]);
                if (j < _size - 1)
                    neighbor.Add(_grid[i, j + 1]);
                if (j > 0)
                    neighbor.Add(_grid[i, j - 1]);
                
                _neighborsMap.Add(_grid[i, j], neighbor.ToArray());
            }
        }
        
        Debug.Log(" nee " + _neighborsMap.Count);
    }
    
    public override IMapItem[] GetNeighbors(IMapItem current)
    {
        List<IMapItem> neighbors = new List<IMapItem>();
        
        return _neighborsMap[current];
    }

    public override int GetDistance(IMapItem one, IMapItem two)
    {
        return Mathf.Abs((one).Position.x - (one).Position.x ) 
               + Mathf.Abs((one).Position.y - (one).Position.y );
    }
}
