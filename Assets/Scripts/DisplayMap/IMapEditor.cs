using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapEditor
{
    void DrawMap();
    
    IMapItem[,] GetEditedMap();
    void DrawWay( IMapItem[] way);

    void SetStart(IMapItem item);
    void SetFinish(IMapItem item);
    
}
