using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapEditor
{
    void DrawMap();

    
    void LoadMap(IMap map);
    
    IMapItem[,] GetEditedMap();
    
    void DrawWay( IMapItem[] way);

    event Action<IMapItem> OnChangeStartPoint;
    event Action<IMapItem> OnChangeFinishPoint;
    
}
