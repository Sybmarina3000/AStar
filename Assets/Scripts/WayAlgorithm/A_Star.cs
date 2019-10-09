using System;
using System.Collections.Generic;
using Helper.Structurs;
using Map;
using UnityEditor;
using UnityEngine;

namespace WayAlgorithm
{
    public interface IStarACalculable{
        IMapItem Last { get; set; }
        int Cost { get; set; }
    }

    public class A_Star : MonoBehaviour, ISearchWayAlgorithm
    {
        public IMap Map { get; set; }
        private IMapItem _start, _finish;
    
        private PriorityQueue<IMapItem> _queue = new PriorityQueue<IMapItem>();
        
        private void Start()
        {
            Map = RealizationBox.Instance.Map;
        }

        public void CalculateWay( IMapItem start, IMapItem finish)
        {
            _start = start;
            _finish = finish;
            _queue.Clear();
            ClearMapItems();

            _start.Cost = 0;
            IMapItem current = _start;
        
            while ( current != _finish && !ReferenceEquals(current, null) )
            {
                IMapItem[] neighbors = Map.GetNeighbors(current);

                foreach (var neighbor in neighbors)
                {
                    if (!neighbor.IsPassable)
                        continue;

                    int cost = Heuristic(current, neighbor);
                    if (cost < neighbor.Cost)
                    {
                        neighbor.Cost = cost;
                        neighbor.Last = current;
                    
                        _queue.Push(neighbor, neighbor.Cost);
                    }
                }
                current = _queue.Pop();
            }
        }

        private int Heuristic(IMapItem current, IMapItem next)
        {
            return current.Cost+1 + Map.GetDistance(_finish, next);
        }

        public Stack<IMapItem> BuildPath()
        {
            if (ReferenceEquals(_finish.Last, null))
                return null;
        
            Stack<IMapItem> path = new Stack<IMapItem>();

            IMapItem current = _finish.Last;
            while (current != _start)
            {
                path.Push(current);
                current = current.Last;
            }
            return path;
        
        }

        private void ClearMapItems()
        {
            int mapSize = Map.GetSize() * Map.GetSize();
            foreach (var item in Map.GetMapItems())
            {
                item.Last = null;
                item.Cost = mapSize;
            }
        }

    }
}