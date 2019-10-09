using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GridManager : MonoBehaviour, IMapEditor
{
    [SerializeField] private int _Size;
    [SerializeField] private GameObject _SpriteGridPrefab;

    private GridItem _start, _finish;
    
    [SerializeField] private GridItem[] _GridItems;
    [SerializeField] private GridMap myGridMap;

    private void Start()
    {
        LoadMap( myGridMap);
    }

    #region BUILD GRID IN EDITOR MODE
    [ExecuteInEditMode]
    public void BuildGrid()
    {
        DeleteLastGrid();
        _GridItems = new GridItem[_Size * _Size];
        
        for (int i = 0; i < _Size; i++)
        {
            for (int j = 0; j < _Size; j++)
            {
                _GridItems[i + j * _Size ] = Instantiate(_SpriteGridPrefab, new Vector2( i, j ), Quaternion.identity, this.transform).GetComponent<GridItem>();
            }    
        }
    }
    private void DeleteLastGrid( )
    {
       if( ReferenceEquals( _GridItems, null))
           return;

       foreach (var item in _GridItems)
       {
           DestroyImmediate(item.gameObject);
       }
       _GridItems = null;
    }
    
    #endregion
    
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
    
    public void LoadMap(IMap map)
    {
        Debug.Log( _GridItems.Length);
        var items = map.Create(_Size);
        
        for (int i = 0; i < _Size; i++)
        {
            for (int j = 0; j < _Size; j++)
            {
                _GridItems[i +j * _Size].SetCell ( items[i + j * _Size] ) ;
            }
        }
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
