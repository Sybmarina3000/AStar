using System.Collections.Generic;
using Map;

namespace WayAlgorithm
{
    public interface ISearchWayAlgorithm
    {
        IMap Map { get; set; }
        void CalculateWay(IMapItem start, IMapItem finish);
        Stack<IMapItem> BuildPath();
    }
}
