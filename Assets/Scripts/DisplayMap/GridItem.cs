using UnityEngine;

public class GridItem : MonoBehaviour
{
    private GridManager _gridManager;
    private SpriteRenderer _sprite;
    
    public IMapItem Cell
    {
        get { return _cell;}
        set { _cell = Cell; }
    }
    private IMapItem _cell;


    void Start()
    {
        _gridManager = GetComponentInParent<GridManager>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    
    void OnMouseDown()
    {
        Debug.Log("I am " + _cell.Position.ToString());
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
