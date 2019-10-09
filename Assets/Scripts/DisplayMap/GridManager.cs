using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GridManager : MonoBehaviour, IMapEditor
{
    [FormerlySerializedAs("size")] [SerializeField] private int _Size;
    [FormerlySerializedAs("SpriteGrid")] [SerializeField] private GameObject _SpriteGridPrefab;

    private GridItem _start, _finish;
    
    private GameObject[,] _sprites;
    // Start is called before the first frame update
    void Start()
    {
        BuildGrid();
    }
    
    public void BuildGrid()
    {
        _sprites = new GameObject[_Size, _Size];
        
        for (int i = 0; i < _Size; i++)
        {
            for (int j = 0; j < _Size; j++)
            {
                _sprites[i, j] = Instantiate(_SpriteGridPrefab,this.transform);
                _sprites[i, j].transform.position = new Vector2( j, i );
            }    
        }
    }

    public void ChangeStartItem( GridItem newItem)
    {
        if ( !ReferenceEquals(_start, null))
        {
            _start.UpdateColor();
        }
        _start = newItem;
    }
    
    public void ChangeFinishItem( GridItem newItem)
    {
        if ( !ReferenceEquals(_finish, null))
        {
            _finish.UpdateColor();
        }

        _finish = newItem;
    }
    
    public void DrawMap()
    {
        throw new System.NotImplementedException();
    }

    public IMapItem[,] GetEditedMap()
    {
        throw new System.NotImplementedException();
    }

    public void DrawWay(IMapItem[] way)
    {
        throw new System.NotImplementedException();
    }

    public void SetStart(IMapItem item)
    {
        throw new System.NotImplementedException();
    }

    public void SetFinish(IMapItem item)
    {
        throw new System.NotImplementedException();
    }
}
