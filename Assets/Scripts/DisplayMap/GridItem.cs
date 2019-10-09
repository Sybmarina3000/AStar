using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridItem : MonoBehaviour
{
    private GridManager _gridManager;
    private SpriteRenderer _sprite;
    
    public IMapItem Cell { get; private set; }
    
    void Start()
    {
        _gridManager = GetComponentInParent<GridManager>();
        _sprite = GetComponent<SpriteRenderer>();
        Cell = new Map.Point();
    }
    
    void OnMouseDown()
    {
        _sprite.color = Brush.Instance.GetCurrentColor();

        switch (Brush.Instance.CurrentBrush)
        {
            case ETypeBrush.start:
            {
                SetIsAvailable(true);
                _gridManager.ChangeStartItem(this);        
                break;
            }
            case ETypeBrush.finish:
            {
                SetIsAvailable(true);
                _gridManager.ChangeFinishItem(this);
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

    public void SetCellPosition( int x, int y)
    {
        Cell.Position = new Vector2Int(x,y);
    }
    
    public void SetIsAvailable( bool available)
    {
        Cell.IsPassable = available;
    }
    
    public void UpdateColor()
    {
        _sprite.color = Cell.IsPassable ? Brush.Instance.GetPassableColor() : Brush.Instance.GetImpassableColor();
    }
    
}
