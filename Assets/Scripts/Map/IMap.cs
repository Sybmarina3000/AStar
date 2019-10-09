using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WayAlgorithm;

namespace Map
{
   public interface IMapItem : IStarACalculable
   {
      Vector2Int Position { get; set; }
      bool IsPassable { get; set; }
   
      IMapItem Last { get; set; }
      int Cost { get; set; }
   }

   public interface IMap
   {
      IMapItem[] Create( int size);
      IEnumerable<IMapItem>  GetMapItems();
      IMapItem[] GetNeighbors(IMapItem current);
      int GetDistance(IMapItem one, IMapItem two);
      int GetSize();
   }
}