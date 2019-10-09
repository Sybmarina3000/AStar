using DisplayMap;
using Map;
using UnityEngine;
using UnityEngine.Events;
using WayAlgorithm;

public class SearchWayManager : MonoBehaviour
{
    private IMapEditor _mapEditor;
    private ISearchWayAlgorithm _SearchAlgoritm;
    
    [SerializeField] private UnityEvent OnCanCalculatePath;

    public IMapItem _Start { get; set; }
    public IMapItem _Finish { get; set; }
    
    private void Start()
    {
        _mapEditor = RealizationBox.Instance.MapEditor;
        _SearchAlgoritm = RealizationBox.Instance.SearchWayAlgorithm;
        
        _mapEditor.OnChangeStartPoint += ChangeStartItem;
        _mapEditor.OnChangeFinishPoint += ChangeFinishItem;
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
        var way = _SearchAlgoritm.BuildPath()?.ToArray();
        if( way != null)
             _mapEditor.DrawWay( way);
    }
    
}
