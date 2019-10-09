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
    
    [SerializeField]
    private GameObject[ ] _sprites;

    
    [SerializeField] private GridMap myGridMap;

    private void Start()
    {
        LoadMap();
    }

    #region BUILD GRID IN EDITOR MODE
    [ExecuteInEditMode]
    public void BuildGrid()
    {
        DeleteLastGrid();
        _sprites = new GameObject[_Size * _Size];
        
        for (int i = 0; i < _Size; i++)
        {
            for (int j = 0; j < _Size; j++)
            {
                _sprites[i + j * _Size ] = Instantiate(_SpriteGridPrefab,this.transform);
                _sprites[i+  j * _Size].transform.position = new Vector2( i, j );
            }    
        }
    }
    private void DeleteLastGrid( )
    {
       if( ReferenceEquals( _sprites, null))
           return;

       foreach (var item in _sprites)
       {
           DestroyImmediate(item);
       }
       _sprites = null;
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
        throw new System.NotImplementedException();
    }

   
    public void LoadMap()
    {
        Debug.Log( _sprites.Length);
        var items = myGridMap.Create(_Size);
        
        for (int i = 0; i < _Size; i++)
        {
            for (int j = 0; j < _Size; j++)
            {
                _sprites[i +j * _Size].GetComponent<GridItem>().SetCell ( items[i + j * _Size] ) ;
                Debug.Log("cc " + _sprites[i + j * _Size].GetComponent<GridItem>().Cell.Position.ToString());
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
