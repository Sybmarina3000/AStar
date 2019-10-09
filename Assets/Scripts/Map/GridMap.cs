using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    [Serializable]
    public class GridMap : MonoBehaviour, IMap
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
                IsPassable = true;
            }
        }

        private Dictionary<IMapItem, IMapItem[]> _neighborsMap = new Dictionary<IMapItem, IMapItem[]>();
    
        public IEnumerable<IMapItem> GetMapItems() => _neighborsMap.Keys;
        public int GetSize() =>_size;

        public IMapItem[] Create(int size)
        {
            _neighborsMap?.Clear();
        
            _size = size;
            IMapItem[,] grid = new IMapItem[size , size];
        
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    grid[i ,j] = new Point(i,j);
                    grid[i ,j].Position = new Vector2Int(i,j);
                    grid[i, j].Cost = size * 2;
                }
            }

            GenerateNeighborsMass( grid);
            return _neighborsMap.Keys.ToArray();
        }
    
        private void GenerateNeighborsMass( IMapItem[,] grid)
        {
            List<IMapItem> neighbor = new List<IMapItem>();
            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                {
                    neighbor.Clear();
                    if (i > 0)
                        neighbor.Add(grid[i - 1, j]);
                    if (i < _size - 1)
                        neighbor.Add(grid[i + 1, j]);
                    if (j < _size - 1)
                        neighbor.Add(grid[i, j + 1]);
                    if (j > 0)
                        neighbor.Add(grid[i, j - 1]);

                    _neighborsMap.Add(grid[i, j], neighbor.ToArray());
                }
            }
        }
    
        public IMapItem[] GetNeighbors(IMapItem current)
        {
            return _neighborsMap[current];
        }

        public int GetDistance(IMapItem one, IMapItem two)
        {
            return Mathf.Abs((one).Position.x - (one).Position.x ) 
                   + Mathf.Abs((one).Position.y - (one).Position.y );
        }
        
    }
}
