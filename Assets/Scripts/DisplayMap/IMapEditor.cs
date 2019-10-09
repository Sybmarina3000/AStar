using System;
using Map;

namespace DisplayMap
{
    public interface IMapEditor
    {
        void LoadMap(IMap map);

        void ClearWay();
        void DrawWay( IMapItem[] way);

        event Action<IMapItem> OnChangeStartPoint;
        event Action<IMapItem> OnChangeFinishPoint;
    
    }
}
