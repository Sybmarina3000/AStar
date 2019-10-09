using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IStarACalculable{
    IMapItem Last { get; set; }
    int Cost { get; set; }
}

public class A_Star : MonoBehaviour
{
    private IMap _map;
    public IMapItem _start, _finish;
    
    private PriorityQueue<IMapItem> _queue;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void CalculateWay()
    {
        _queue.Clear();
        IMapItem current = _start;
        
        while ( current != _finish)
        {
            IMapItem[] neighbors = _map.GetNeighbors(current);

            foreach (var neighbor in neighbors)
            {
                if( !neighbor.IsPassable)
                    continue;
                
                int cost = Heuristic(current, neighbor);
                if (cost < neighbor.Cost)
                {
                    neighbor.Cost = cost;
                    neighbor.Last = current;
                    
                    _queue.Push(neighbor, neighbor.Cost);
                }
            }
        }
    }

    private int Heuristic(IMapItem current, IMapItem next)
    {
        return current.Cost + _map.GetDistance(current, next);
    }

    private Stack<IMapItem> BuildPath()
    {
        Stack<IMapItem> path = new Stack<IMapItem>();

        IMapItem current = _finish;
        while (current != _start)
        {
            path.Push(current);
            current = current.Last;
        }

        return path;
    }
}
