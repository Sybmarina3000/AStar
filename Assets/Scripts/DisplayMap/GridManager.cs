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
    
    private GameObject[,] _sprites;

    [SerializeField] private GridMap myGridMap;
    

    [ExecuteInEditMode]
    public void BuildGrid( IMapItem[,] map)
    {
        DeleteLastGrid();
        _sprites = new GameObject[_Size, _Size];
        
        for (int i = 0; i < _Size; i++)
        {
            for (int j = 0; j < _Size; j++)
            {
                _sprites[i, j] = Instantiate(_SpriteGridPrefab,this.transform);
                _sprites[i, j].transform.position = new Vector2( i, j );

                _sprites[i, j].GetComponent<GridItem>().SetCell ( (AbstractIMapItem)map[i, j] ) ;
                Debug.Log(" Map return " + map[i,j].Position);
            }    
        }
    }
    private void DeleteLastGrid( )
    {
       if( ReferenceEquals( _sprites, null))
           return;

       int sizeMass = (int)Mathf.Sqrt(_sprites.Length);
       for (int i = 0; i < sizeMass; i++)
       {
           for (int j = 0; j < sizeMass; j++)
           {
               DestroyImmediate(_sprites[i, j]);
           }    
       }
       _sprites = null;
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

    public void LoadMap(IMap map)
    {
        throw new System.NotImplementedException();
    }

    [ExecuteInEditMode]
    public void LoadMap()
    {
        var items = myGridMap.Create(_Size);
        BuildGrid(items);
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
