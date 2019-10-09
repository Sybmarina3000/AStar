using System;
using Map;
using UnityEngine;

namespace DisplayMap
{
    public class GridItem : MonoBehaviour
    {
        private GridMapEditor _gridMapEditor;
        private SpriteRenderer _sprite;
    
        public IMapItem Cell { get { return _cell;} }
        private IMapItem _cell;
        
        void Start()
        {
            _gridMapEditor = GetComponentInParent<GridMapEditor>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButton(0))
            {
                PaintItem();
            }
        }

        public void PaintItem()
        {
            
            if (!_gridMapEditor.CheckCanChangeColor(this))
                return;
            
            _sprite.color = Brush.Instance.GetCurrentColor();
            
            switch (Brush.Instance.CurrentBrush)
            {
                case ETypeBrush.start:
                {
                    SetIsAvailable(true);
                    _gridMapEditor.ChangeStartItem(this);        
                    break;
                }
                case ETypeBrush.finish:
                {
                    SetIsAvailable(true);
                    _gridMapEditor.ChangeFinishItem(this);
                    break;
                }
                case ETypeBrush.passable:
                {
                    SetIsAvailable(true);
                    break;
                }
                case ETypeBrush.impassable:
                {
                    SetIsAvailable(false);
                    break;
                }
            }
        }

        public void SetCell(IMapItem cell)
        {
            _cell = cell;
        }

        public void SetIsAvailable( bool available)
        {
            Cell.IsPassable = available;
        }
    
        public void UpdateColor()
        {
            _sprite.color = Cell.IsPassable ? Brush.Instance.GetPassableColor() : Brush.Instance.GetImpassableColor();
        }
    
        public void SetColor( Color newColor)
        {
            _sprite.color = newColor;
        }
    
    }
}
