using System;
using Map;
using UnityEngine;

namespace DisplayMap
{
    public class GridMapEditor : MonoBehaviour, IMapEditor
    {
        [SerializeField] private int _Size;
        [SerializeField] private GameObject _SpriteGridPrefab;

        [SerializeField] private GridItem[] _GridItems;
        private IMap _Map;

        private IMapItem[] _way;
        // for search way 
        private GridItem _start, _finish;
        public event Action<IMapItem> OnChangeStartPoint;
        public event Action<IMapItem> OnChangeFinishPoint;
    
        private void Start()
        {
            _Map = RealizationBox.Instance.Map;
            LoadMap( _Map);
        }
    
        public void LoadMap(IMap map)
        {
            var items = map.Create(_Size);
        
            for (int i = 0; i < _Size; i++)
            {
                for (int j = 0; j < _Size; j++)
                {
                    _GridItems[i +j * _Size].SetCell ( items[i + j * _Size] ) ;
                }
            }
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

        public bool CheckCanChangeColor(GridItem item)
        {
            if (ReferenceEquals(item, _start) || ReferenceEquals(item, _finish))
                return false;
            return true;
        }
        
        public void ChangeStartItem( GridItem newItem)
        {
            if ( !ReferenceEquals(_start, null))
                _start.UpdateColor();
            
            _start = newItem;
            OnChangeStartPoint.Invoke( _start.Cell);
        }
        
        public void ChangeFinishItem( GridItem newItem)
        {
            if ( !ReferenceEquals(_finish, null))
            {
                _finish.UpdateColor();
            }

            _finish = newItem;
            OnChangeFinishPoint.Invoke( _finish.Cell );
        }
    
        public void ClearWay()
        {
            if (ReferenceEquals(_way, null))
                return;
            
            int i, j;
            foreach (var cell in _way)
            {
                i = cell.Position.x * _Size;
                j = cell.Position.y ;

                _GridItems[i + j].UpdateColor();
            }
        }

        public void DrawWay(IMapItem[] way)
        {
            _way = way;
            int i, j;
            foreach (var cell in way)
            {
                i = cell.Position.x * _Size;
                j = cell.Position.y ;

                _GridItems[i + j].SetColor( Color.magenta);
            }
        }

    }
}
