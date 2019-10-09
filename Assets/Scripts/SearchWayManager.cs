using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SearchWayManager : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    private IMapEditor Editor;
    [SerializeField] private GridMap map;
    
    [SerializeField] private A_Star _SearchAlgoritm;
    [SerializeField] private UnityEvent OnCanCalculatePath;

    public IMapItem _Start { get; set; }
    public IMapItem _Finish { get; set; }
    
    private void Start()
    {
        Editor = _gridManager;
        _SearchAlgoritm.Map = map;
        
        Editor.OnChangeStartPoint += ChangeStartItem;
        Editor.OnChangeFinishPoint += ChangeFinishItem;
    }

    // Start is called before the first frame update
    public void ChangeStartItem( IMapItem newItem)
    {
        _Start = newItem;
        CheckCanCalculateWay();
    }
    
    public void ChangeFinishItem( IMapItem newItem)
    {
        _Finish = newItem;
        CheckCanCalculateWay();
    }

    private void CheckCanCalculateWay()
    {
        if( !ReferenceEquals(_Start, null) && !ReferenceEquals(_Finish, null))
            OnCanCalculatePath.Invoke();
    }

    public void Calculate()
    {
        _SearchAlgoritm.CalculateWay( _Start, _Finish);
        Editor.DrawWay(_SearchAlgoritm.BuildPath().ToArray());
    }
    
    
}
