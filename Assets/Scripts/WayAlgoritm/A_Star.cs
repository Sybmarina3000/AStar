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
    public IMap Map { get; set; }
    private IMapItem _start, _finish;
    
    private PriorityQueue<IMapItem> _queue = new PriorityQueue<IMapItem>();

    public void CalculateWay( IMapItem start, IMapItem finish)
    {
        _start = start;
        _finish = finish;
        _queue.Clear();

        _start.Cost = 0;
        IMapItem current = _start;
        
        while ( current != _finish)
        {
            IMapItem[] neighbors = Map.GetNeighbors(current);

            foreach (var neighbor in neighbors)
            {
//                if( !neighbor.IsPassable)
//                    continue;
                
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
        Debug.Log("DONE");
        BuildPath();
    }

    private int Heuristic(IMapItem current, IMapItem next)
    {
        return current.Cost+1 + Map.GetDistance(_finish, next);
    }

    private Stack<IMapItem> BuildPath()
    {
        Stack<IMapItem> path = new Stack<IMapItem>();

        IMapItem current = _finish;
        while (current != _start)
        {
            path.Push(current);
            current = current.Last;
            Debug.Log(" " + current.Position);
        }

        return path;
    }
}
